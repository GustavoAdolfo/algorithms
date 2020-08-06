using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraSequenciaMaior : Regra
    {
        public RegraSequenciaMaior()
        {
            this.NomeRegra = "Sequência Maior";
            this.IdRegra = 12;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            if (valoresDasFaces.Length < 5)
            {
                this.RegraAplicavel = false;
                this.Pontuacao = 0;
                return;
            }

            this.RegraAplicavel = valoresDasFaces.Contains(1) && valoresDasFaces.Contains(2)
                                  && valoresDasFaces.Contains(3) && valoresDasFaces.Contains(4) && valoresDasFaces.Contains(5);
            this.RegraAplicavel = this.RegraAplicavel || (valoresDasFaces.Contains(2) && valoresDasFaces.Contains(3)
                                  && valoresDasFaces.Contains(4) && valoresDasFaces.Contains(5) && valoresDasFaces.Contains(6));
            this.Pontuacao = this.RegraPodeSerAplicada() ? 20 : 0;
        }
    }
}
