using System.Collections.Generic;
using System.Linq;
using Misterio.Dominio.Interfaces;

namespace Misterio.Infraestrutura.Repositorios
{
    public class LocalRepositorio : IRepositorio
    {
        private readonly Contexto _ctx;

        public LocalRepositorio(string conexao)
        {
            _ctx = new Contexto(conexao);
        }

        public int RetornarTotalDeRegistros()
        {
            return _ctx.Local.Count();
        }

        public Dictionary<int, string> RetornarIdsENomes()
        {
            var dados = _ctx.Local.ToDictionary(c => c.Id, c => c.Nome);
            return dados;
        }

        public KeyValuePair<int, string>? ObterPorId(int id)
        {
            var local = _ctx.Local.FirstOrDefault(a => a.Id == id);
            if (local != null)
                return new KeyValuePair<int, string>(local.Id, local.Nome);

            return null;
        }

        public KeyValuePair<int, string>? ObterPorNome(string nome)
        {
            var local = _ctx.Local.FirstOrDefault(a => a.Nome == nome);
            if (local != null)
                return new KeyValuePair<int, string>(local.Id, local.Nome);

            return null;
        }
    }
}
