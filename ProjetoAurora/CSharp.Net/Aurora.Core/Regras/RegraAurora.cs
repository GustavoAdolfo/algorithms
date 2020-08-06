
using System.Collections.Generic;
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraAurora : Regra
    {
        public RegraAurora()
        {
            this.NomeRegra = "Aurora";
            this.IdRegra = 15;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            var dicionario = new Dictionary<int, int>();
            var quantidade = valoresDasFaces.Length;
            foreach (var valor in valoresDasFaces)
            {
                if (!dicionario.ContainsKey(valor))
                {
                    dicionario.Add(valor, valoresDasFaces.Count(v => v == valor));
                }
            }
            var aurora = dicionario.Where(v => v.Value == quantidade).ToList();
            this.RegraAplicavel = aurora.Count == 1;

            this.Pontuacao = this.RegraPodeSerAplicada() ? 50 : 0;
        }
    }
}
