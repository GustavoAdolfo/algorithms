
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraDois : Regra
    {
        public RegraDois()
        {
            this.NomeRegra = "Dois";
            this.IdRegra = 2;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            this.RegraAplicavel = valoresDasFaces.Any(v => v == 2);
            this.Pontuacao = valoresDasFaces.Where(v => v == 2).Sum();
        }
    }
}
