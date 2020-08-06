using System;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using Aplicacao.Facade;
using Aplicacao.Models;
using System.Web.Http.Cors;

namespace Aplicacao.Controllers
{
    //[EnableCors(origins: "http://localhost:8234/", headers: "*", methods: "*")]
    public class MisterioController : ApiController
    {
        private readonly MisterioFacade _facade;

        public MisterioController()
        {
            _facade = new MisterioFacade();
        }

        [HttpGet]
        [Route("api/misterio/")]
        [Route("api/descubraoassassino/")]
        public IHttpActionResult Get()
        {
            try
            {
                var misterio = _facade.ObterNovoMisterio();
                if (misterio == null)
                {
                    return NotFound();
                }

                HttpContext.Current.Session[misterio.IdMisterio.ToString()] = misterio;
                Object obj = new { misterioId = misterio.IdMisterio.ToString() };
                return Ok(JsonConvert.SerializeObject(obj));
            }
            //catch (MisterioException m)
            //{
            //    return new NotFoundMisterioActionResult(m.Message, Request);
            //}
            catch (Exception e)
            {
                Debug.WriteLine($"O verdadeiro erro para um log: {e.Message}");
                var exception = new MisterioException("Estamos tendo problemas de comunicação com nossa central de informações.");
                //return new InternalServerMisterioErrorActionResult(msg, Request);
                return InternalServerError(exception);
            }
        }

        [HttpGet]
        [Route("api/misterio/criminosos/")]
        [Route("api/descubraoassassino/criminosos/")]
        public string ListaDeCriminosos()
        {
            var criminosos = _facade.ListarCriminosos().Select(l => new { Id = l.Key, Nome = l.Value });
            return JsonConvert.SerializeObject(criminosos);
        }

        [HttpGet]
        [Route("api/misterio/armas/")]
        [Route("api/descubraoassassino/armas/")]
        public string ListaDeArmas()
        {
            var armas = _facade.ListarArmas().Select(l => new { Id = l.Key, Nome = l.Value });
            return JsonConvert.SerializeObject(armas);
        }

        [HttpGet]
        [Route("api/misterio/locais/")]
        [Route("api/descubraoassassino/locais/")]
        public string ListaDeLocais()
        {
            var locais = _facade.ListarLocais().Select(l => new { Id = l.Key, Nome = l.Value });
            return JsonConvert.SerializeObject(locais);
        }

        // POST api/values
        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("api/misterio/")]
        [Route("api/descubraoassassino/")]        
        public IHttpActionResult Post([FromBody]SuposicaoModel suposicao)
        {
            if (suposicao == null)
            {
                return BadRequest("Nenhum valor foi enviado para análise");
            }
            if (string.IsNullOrWhiteSpace(suposicao.IdMisterio))
            {
                return NotFound();
            }
            var idMisterio = suposicao.IdMisterio;
            var facade = new MisterioFacade();
            var misterio = facade.ObterMisterio(idMisterio);
            if (misterio != null)
            {                
                if (!misterio.IsValid())
                {
                    return InternalServerError();
                }

                int resposta;

                if (misterio.IdSuspeito == suposicao.IdSuspeito)
                {
                    if (misterio.IdArma == suposicao.IdArma)
                    {
                        if (misterio.IdLocal == suposicao.IdLocal)
                        {
                            //Acerto
                            facade.ExcluirMisterio(misterio.IdMisterio);
                            return Ok(0);
                        }
                        return Ok(2); //Local incorreto
                    }

                    if (misterio.IdArma != suposicao.IdArma && misterio.IdLocal != suposicao.IdLocal)
                    {
                        resposta = new Random().Next(2,3);
                        return Ok(resposta);
                    }
                    return Ok(3); //Arma incorreta
                }
                else
                {
                    if (misterio.IdArma == suposicao.IdArma && misterio.IdLocal == suposicao.IdLocal)
                    {
                        return Ok(1); //Suspeito incorreto
                    }
                    if (misterio.IdArma != suposicao.IdArma && misterio.IdLocal == suposicao.IdLocal)
                    {
                        //Arma ou suspeito incorretos
                        resposta = new Random().Next(1, 3);
                        resposta = resposta == 2 ? 1 : resposta;
                        return Ok(resposta);
                    }
                    if (misterio.IdArma == suposicao.IdArma && misterio.IdLocal != suposicao.IdLocal)
                    {
                        //Local ou suspeito incorretos
                        resposta = new Random().Next(1,2);
                        return Ok(resposta);
                    }
                    //Todos incorretos 
                    resposta = new Random().Next(1,3);
                    return Ok(resposta);
                }
            }

            return Ok();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
