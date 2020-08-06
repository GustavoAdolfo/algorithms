
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraQuadra : Regra
    {
        public RegraQuadra()
        {
            this.NomeRegra = "Quadra";
            this.IdRegra = 10;
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
            var quadra = dicionario.Where(v => v.Value > 3).ToList(); 
            this.RegraAplicavel = quadra.Count() == 1;
            this.Pontuacao = this.RegraPodeSerAplicada() ? quadra.Sum(d => d.Key * 4) : 0;
        }
    }
}
