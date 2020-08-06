using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Misterio.Infraestrutura.Repositorios;
using Aplicacao.Models;
using Misterio.Dominio.Interfaces;
using System.Xml;

namespace Aplicacao.Facade
{
    public class MisterioFacade
    {
        private readonly string _conexao;
        private readonly FonteDeDados _fonteDeDados;
        private IRepositorio _repositorio;        

        public MisterioFacade()
        {
            Enum.TryParse<FonteDeDados>(ConfigurationManager.AppSettings["FonteDeDados"], out _fonteDeDados);

            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _conexao = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
                    break;
                default:
                    _conexao = HttpContext.Current.Server.MapPath("~/App_Data/");
                    break;
            }
        }

        public MisterioModel ObterNovoMisterio()
        {
            var misterio = new MisterioModel
            {
                IdSuspeito = EscolherCriminoso(),
                IdArma = EscolherArma(),
                IdLocal = EscolherLocal()
            };

            if (!misterio.IsValid())
            {
                //throw new MisterioException();
                return null;
            }


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/misterios.xml"));
            XmlNode RootNode = xmlDoc.SelectSingleNode("misterios");
            XmlNode misterioNode = RootNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "misterio", ""));
            misterioNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "IdMisterio", "")).InnerText = misterio.IdMisterio;
            misterioNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "IdLocal", "")).InnerText = misterio.IdLocal.ToString();
            misterioNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "IdArma", "")).InnerText = misterio.IdArma.ToString();
            misterioNode.AppendChild(xmlDoc.CreateNode(XmlNodeType.Element, "IdSuspeito", "")).InnerText = misterio.IdSuspeito.ToString();
            xmlDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/misterios.xml"));
            
            return misterio;
        }

        public MisterioModel ObterMisterio(string idMisterio)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/misterios.xml"));
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("descendant::misterio[IdMisterio='"+idMisterio+"']");
            if(nodeList.Count <= 0)
            {
                return null;
            }
            XmlNode noMisterio = nodeList[nodeList.Count - 1]; //mais recente embora improvável que existam nós iguais
            XmlNodeList childs = noMisterio.ChildNodes;

            var misterio = new MisterioModel();

            misterio.IdMisterio = noMisterio.SelectNodes("IdMisterio")[0].InnerText;
            int.TryParse(noMisterio.SelectNodes("IdSuspeito")[0].InnerText, out int idSuspeito);
            int.TryParse(noMisterio.SelectNodes("IdArma")[0].InnerText, out int idArma);
            int.TryParse(noMisterio.SelectNodes("IdLocal")[0].InnerText, out int idLocal);
            misterio.IdArma = idArma;
            misterio.IdLocal = idLocal;
            misterio.IdSuspeito = idSuspeito;

            return misterio;
        }

        public void ExcluirMisterio(string idMisterio)
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("~/App_Data/misterios.xml"));
            XmlNode root = xmlDoc.DocumentElement;
            XmlNodeList nodeList = root.SelectNodes("descendant::misterio[IdMisterio='" + idMisterio + "']");
            foreach(XmlNode no in nodeList)
            {
                root.RemoveChild(no);
            }
            xmlDoc.Save(HttpContext.Current.Server.MapPath("~/App_Data/misterios.xml"));
        }

        private int EscolherCriminoso()
        {
            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _repositorio = new CriminosoRepositorio(_conexao);
                    break;
                default:
                    _repositorio = new CriminosoRepositorioXML($"{_conexao}criminosos.xml");
                    break;
            }

            var criminosos = _repositorio.RetornarIdsENomes();
            var menor = criminosos.Min(c => c.Key);
            var maior = criminosos.Max(c => c.Key);
            System.Threading.Thread.Sleep(100);
            var idAleatorio = new Random().Next(menor, maior);
            var consulta = criminosos.FirstOrDefault(c => c.Key == idAleatorio);
            return consulta.Key;
        }

        private int EscolherArma()
        {
            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _repositorio = new ArmaRepositorio(_conexao);
                    break;
                default:
                    _repositorio = new ArmaRepositorioXML($"{_conexao}armas.xml");
                    break;
            }
            
            var armas = _repositorio.RetornarIdsENomes();
            var menor = armas.Min(c => c.Key);
            var maior = armas.Max(c => c.Key);
            System.Threading.Thread.Sleep(100);
            var idAleatorio = new Random().Next(menor, maior);
            var consulta = armas.FirstOrDefault(a => a.Key == idAleatorio);
            return consulta.Key;
        }

        private int EscolherLocal()
        {
            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _repositorio = new LocalRepositorio(_conexao);
                    break;
                default:
                    _repositorio = new LocalRepositorioXML($"{_conexao}locais.xml");
                    break;
            }

            var locais = _repositorio.RetornarIdsENomes();
            var menor = locais.Min(c => c.Key);
            var maior = locais.Max(c => c.Key);
            System.Threading.Thread.Sleep(100);
            var idAleatorio = new Random().Next(menor, maior);
            var consulta = locais.FirstOrDefault(l => l.Key == idAleatorio);
            return consulta.Key;
        }

        public Dictionary<int, string> ListarCriminosos()
        {
            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _repositorio = new CriminosoRepositorio(_conexao);
                    break;
                default:
                    _repositorio = new CriminosoRepositorioXML($"{_conexao}criminosos.xml");
                    break;
            }

            return _repositorio.RetornarIdsENomes();
        }

        public Dictionary<int, string> ListarArmas()
        {
            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _repositorio = new ArmaRepositorio(_conexao);
                    break;
                default:
                    _repositorio = new ArmaRepositorioXML($"{_conexao}armas.xml");
                    break;
            }
            
            return _repositorio.RetornarIdsENomes();
        }

        public Dictionary<int, string> ListarLocais()
        {
            switch (_fonteDeDados)
            {
                case FonteDeDados.BaseRelacional:
                    _repositorio = new LocalRepositorio(_conexao);
                    break;
                default:
                    _repositorio = new LocalRepositorioXML($"{_conexao}locais.xml");
                    break;
            }
            return _repositorio.RetornarIdsENomes();
        }
    }

    public class MisterioException : Exception
    {
        private string _mensagem;

        public MisterioException()
        {
            _mensagem = "Nossa central de informações está tendo dificuldades para relatar os crimes no momento.";
        }
        public MisterioException(string msg)
        {
            _mensagem = msg;
        }
    }
}