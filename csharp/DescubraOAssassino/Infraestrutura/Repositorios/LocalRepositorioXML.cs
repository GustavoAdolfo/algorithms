using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Misterio.Dominio.Interfaces;

namespace Misterio.Infraestrutura.Repositorios
{
    public class LocalRepositorioXML : IRepositorio
    {
        private readonly XmlDocument _xmlDoc;

        public LocalRepositorioXML(string conexao)
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(conexao);
        }

        public int RetornarTotalDeRegistros()
        {
            var total = 0;
            total = _xmlDoc.SelectNodes("//local").Count;
            return total;
        }

        public Dictionary<int, string> RetornarIdsENomes()
        {
            var dados = new Dictionary<int, string>();
            foreach (XmlNode xmlNode in _xmlDoc.GetElementsByTagName("local"))
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
            var local = _xmlDoc.SelectSingleNode($"//local[id='{id}'");
            if (local == null)
                return null;

            int.TryParse(local.Attributes["id"].Value, out int idLocal);
            string nomeLocal = local.Attributes["nome"].Value;
            if (idLocal < 1 || string.IsNullOrWhiteSpace(nomeLocal))
            {
                return null;
            }
            return new KeyValuePair<int, string>(idLocal, nomeLocal);
        }

        public KeyValuePair<int, string>? ObterPorNome(string nome)
        {
            var local = _xmlDoc.SelectSingleNode($"//local[nome='{nome}'");
            if (local == null)
                return null;

            int.TryParse(local.Attributes["id"].Value, out int idLocal);
            string nomeLocal = local.Attributes["nome"].Value;
            if (idLocal < 1 || string.IsNullOrWhiteSpace(nomeLocal))
            {
                return null;
            }
            return new KeyValuePair<int, string>(idLocal, nomeLocal);
        }
    }
}
