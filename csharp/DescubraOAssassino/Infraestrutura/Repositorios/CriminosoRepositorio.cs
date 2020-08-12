using System;
using System.Collections.Generic;
using System.Linq;
using Misterio.Dominio.Entidades;
using Misterio.Dominio.Interfaces;

namespace Misterio.Infraestrutura.Repositorios
{
    public class CriminosoRepositorio : IRepositorio
    {
        private readonly Contexto _ctx;

        public CriminosoRepositorio(string conexao)
        {
            _ctx = new Contexto(conexao);
        }

        public int RetornarTotalDeRegistros()
        {
            return _ctx.Criminoso.Count();
        }

        public Dictionary<int, string> RetornarIdsENomes()
        {
            var dados = _ctx.Criminoso.ToDictionary(c => c.Id, c => c.Nome);
            return dados;
        }

        public KeyValuePair<int, string>? ObterPorId(int id)
        {
            var criminoso = _ctx.Criminoso.FirstOrDefault(c => c.Id == id);
            if(criminoso != null) 
                return new KeyValuePair<int, string>(criminoso.Id, criminoso.Nome);

            return null;
        }

        public KeyValuePair<int, string>? ObterPorNome(string nome)
        {
            var criminoso = _ctx.Criminoso.FirstOrDefault(c => c.Nome.Equals(nome, StringComparison.CurrentCultureIgnoreCase));
            if (criminoso != null)
                return new KeyValuePair<int, string>(criminoso.Id, criminoso.Nome);

            return null;
        }
    }
}
