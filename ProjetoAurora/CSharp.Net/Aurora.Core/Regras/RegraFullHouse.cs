
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraFullHouse : Regra
    {
        public RegraFullHouse()
        {
            this.NomeRegra = "Full House";
            this.IdRegra = 14;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            var dicionario = new Dictionary<int, int>();
            foreach (var valor in valoresDasFaces)
            {
                if (!dicionario.ContainsKey(valor))
                {
                    dicionario.Add(valor, valoresDasFaces.Count(v => v == valor));
                }
            }
            var pares = dicionario.Where(v => v.Value == 2).ToList();
            var trios = dicionario.Where(v => v.Value == 3).ToList();
            this.RegraAplicavel = pares.Count() == 1 && trios.Count() == 1;

            this.Pontuacao = this.RegraPodeSerAplicada() ? pares.Sum(d => d.Key * 2) + trios.Sum(d => d.Key * 3): 0;
        }
    }
}
