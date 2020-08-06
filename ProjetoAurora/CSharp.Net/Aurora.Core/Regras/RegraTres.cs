
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraTres : Regra
    {
        public RegraTres()
        {
            this.NomeRegra = "Três";
            this.IdRegra = 3;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            this.RegraAplicavel = valoresDasFaces.Any(v => v == 3);
            this.Pontuacao = valoresDasFaces.Where(v => v == 3).Sum();
        }
    }
}
