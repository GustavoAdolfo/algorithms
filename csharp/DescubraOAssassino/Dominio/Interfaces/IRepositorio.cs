
using System.Collections.Generic;
using Misterio.Dominio.Entidades;

namespace Misterio.Dominio.Interfaces
{
    public interface IRepositorio
    {
        int RetornarTotalDeRegistros();
        Dictionary<int, string> RetornarIdsENomes();
        KeyValuePair<int, string>? ObterPorId(int id);
        KeyValuePair<int, string>? ObterPorNome(string nome);
    }
}
