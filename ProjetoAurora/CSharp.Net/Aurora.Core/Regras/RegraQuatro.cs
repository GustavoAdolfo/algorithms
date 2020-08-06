
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraQuatro : Regra
    {
        public RegraQuatro()
        {
            this.NomeRegra = "Quatro";
            this.IdRegra = 4;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            this.RegraAplicavel = valoresDasFaces.Any(v => v == 4);
            this.Pontuacao = valoresDasFaces.Where(v => v == 4).Sum();
        }
    }
}
