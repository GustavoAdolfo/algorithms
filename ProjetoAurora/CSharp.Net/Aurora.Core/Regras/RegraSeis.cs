
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraSeis : Regra
    {
        public RegraSeis()
        {
            this.NomeRegra = "Seis";
            this.IdRegra = 6;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            this.RegraAplicavel = valoresDasFaces.Any(v => v == 6);
            this.Pontuacao = valoresDasFaces.Where(v => v == 6).Sum();
        }
    }
}
