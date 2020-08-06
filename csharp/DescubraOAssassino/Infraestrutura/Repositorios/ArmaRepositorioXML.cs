using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Misterio.Dominio.Interfaces;

namespace Misterio.Infraestrutura.Repositorios
{
    public class ArmaRepositorioXML : IRepositorio
    {
        private readonly XmlDocument _xmlDoc;

        public ArmaRepositorioXML(string conexao)
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(conexao);
        }

        public int RetornarTotalDeRegistros()
        {
            var total = 0;
            total = _xmlDoc.SelectNodes("//arma").Count;
            return total;
        }

        public Dictionary<int, string> RetornarIdsENomes()
        {
            var dados = new Dictionary<int, string>();
            foreach (XmlNode xmlNode in _xmlDoc.GetElementsByTagName("arma"))
            {
                int.TryParse(xmlNode.Attributes["id"].Value, out int id);
                if (id < 1)
                {
                    continue;
                }
                var nome = xmlNode.Attributes["nome"].Value;
                dados.Add(id, nome);
            }
            return dados;
        }

        public KeyValuePair<int, string>? ObterPorId(int id)
        {
            var arma = _xmlDoc.SelectSingleNode($"//arma[id='{id}'");
            if (arma == null)
                return null;

            int.TryParse(arma.Attributes["id"].Value, out int idArma);
            string nomeArma = arma.Attributes["nome"].Value;
            if (idArma < 1 || string.IsNullOrWhiteSpace(nomeArma))
            {
                return null;
            }
            return new KeyValuePair<int, string>(idArma, nomeArma);
        }

        public KeyValuePair<int, string>? ObterPorNome(string nome)
        {
            var arma = _xmlDoc.SelectSingleNode($"//arma[nome='{nome}'");
            if (arma == null)
                return null;

            int.TryParse(arma.Attributes["id"].Value, out int idArma);
            string nomeArma = arma.Attributes["nome"].Value;
            if (idArma < 1 || string.IsNullOrWhiteSpace(nomeArma))
            {
                return null;
            }
            return new KeyValuePair<int, string>(idArma, nomeArma);
        }
    }
}
