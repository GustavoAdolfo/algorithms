
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraTrio : Regra
    {
        public RegraTrio()
        {
            this.NomeRegra = "Trio";
            this.IdRegra = 9;
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
            var trios = dicionario.Where(v => v.Value > 2).ToList(); 
            this.RegraAplicavel = trios.Count() == 1;
            this.Pontuacao = this.RegraPodeSerAplicada() ? trios.Sum(d => d.Key * 3) : 0;
        }
    }
}
