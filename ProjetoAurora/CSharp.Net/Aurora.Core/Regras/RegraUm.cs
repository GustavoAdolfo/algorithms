
using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraUm : Regra
    {
        public RegraUm()
        {
            this.NomeRegra = "Um";
            this.IdRegra = 1;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            this.RegraAplicavel = valoresDasFaces.Any(v => v == 1);
            this.Pontuacao = valoresDasFaces.Where(v => v == 1).Sum();
        }
    }
}
