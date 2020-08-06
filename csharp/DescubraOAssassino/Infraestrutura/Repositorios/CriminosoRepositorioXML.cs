using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Misterio.Dominio.Entidades;
using Misterio.Dominio.Interfaces;

namespace Misterio.Infraestrutura.Repositorios
{
    public class CriminosoRepositorioXML : IRepositorio
    {
        private readonly XmlDocument _xmlDoc;

        public CriminosoRepositorioXML(string conexao)
        {
            _xmlDoc = new XmlDocument();
            _xmlDoc.Load(conexao);
        }

        public int RetornarTotalDeRegistros()
        {
            var total = 0;
            total = _xmlDoc.SelectNodes("//criminoso").Count;
            return total;
        }

        public Dictionary<int, string> RetornarIdsENomes()
        {
            var dados = new Dictionary<int, string>();
            foreach (XmlNode xmlNode in _xmlDoc.GetElementsByTagName("criminoso"))
            {
                int.TryParse(xmlNode.Attributes["id"].Value, out int id);
                if(id < 1)
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
            var criminoso = _xmlDoc.SelectSingleNode($"//criminoso[id='{id}'");
            if (criminoso == null)
                return null;
            
            int.TryParse(criminoso.Attributes["id"].Value, out int idCriminoso);
            string nomeCriminoso = criminoso.Attributes["nome"].Value;
            if (idCriminoso < 1 || string.IsNullOrWhiteSpace(nomeCriminoso))
            {
                return null;
            }
            return new KeyValuePair<int, string>(idCriminoso, nomeCriminoso);
        }

        public KeyValuePair<int, string>? ObterPorNome(string nome)
        {
            var criminoso = _xmlDoc.SelectSingleNode($"//criminoso[nome='{nome}'");
            if (criminoso == null)
                return null;

            int.TryParse(criminoso.Attributes["id"].Value, out int idCriminoso);
            string nomeCriminoso = criminoso.Attributes["nome"].Value;
            if (idCriminoso < 1 || string.IsNullOrWhiteSpace(nomeCriminoso))
            {
                return null;
            }
            return new KeyValuePair<int, string>(idCriminoso, nomeCriminoso);
        }
    }
}
