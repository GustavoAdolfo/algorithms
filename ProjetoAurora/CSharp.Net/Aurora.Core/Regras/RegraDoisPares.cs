
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Aurora.Core.Regras
{
    public class RegraDoisPares : Regra
    {
        public RegraDoisPares()
        {
            this.NomeRegra = "Dois Pares";
            this.IdRegra = 8;
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
            var pares = dicionario.Where(v => v.Value > 1).ToList(); //.Select(v => v);
            this.RegraAplicavel = pares.Count() > 1;
            this.Pontuacao = this.RegraPodeSerAplicada() ? pares.Sum(d => d.Key * 2) : 0;
        }
    }
}
