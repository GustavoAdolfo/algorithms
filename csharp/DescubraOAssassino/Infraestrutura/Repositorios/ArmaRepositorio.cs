using System.Collections.Generic;
using System.Linq;
using Misterio.Dominio.Interfaces;

namespace Misterio.Infraestrutura.Repositorios
{
    public class ArmaRepositorio : IRepositorio
    {
        private readonly Contexto _ctx;

        public ArmaRepositorio(string conexao)
        {
            _ctx = new Contexto(conexao);
        }

        public int RetornarTotalDeRegistros()
        {
            return _ctx.Arma.Count();
        }

        public Dictionary<int, string> RetornarIdsENomes()
        {
            var dados = _ctx.Arma.ToDictionary(c => c.Id, c => c.Nome);
            return dados;
        }

        public KeyValuePair<int, string>? ObterPorId(int id)
        {
            var arma = _ctx.Arma.FirstOrDefault(a => a.Id == id);
            if(arma != null)
                return new KeyValuePair<int, string>(arma.Id, arma.Nome);

            return null;
        }

        public KeyValuePair<int, string>? ObterPorNome(string nome)
        {
            var arma = _ctx.Arma.FirstOrDefault(a => a.Nome == nome);
            if (arma != null)
                return new KeyValuePair<int, string>(arma.Id, arma.Nome);

            return null;
        }
    }
}
