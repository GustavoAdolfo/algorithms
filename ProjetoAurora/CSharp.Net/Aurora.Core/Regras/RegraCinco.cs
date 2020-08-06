
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraCinco : Regra
    {
        public RegraCinco()
        {
            this.NomeRegra = "Cinco";
            this.IdRegra = 5;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            this.RegraAplicavel = valoresDasFaces.Any(v => v == 5);
            this.Pontuacao = valoresDasFaces.Where(v => v == 5).Sum();
        }
    }
}
