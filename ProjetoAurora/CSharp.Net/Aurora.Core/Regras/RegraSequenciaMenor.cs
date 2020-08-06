using System.Linq;

namespace Aurora.Core.Regras
{
    public class RegraSequenciaMenor : Regra
    {
        public RegraSequenciaMenor()
        {
            this.NomeRegra = "Sequência Menor";
            this.IdRegra = 11;
        }
        public override void AplicarRegra(int[] valoresDasFaces)
        {
            if (valoresDasFaces.Length < 4)
            {
                this.RegraAplicavel = false;
                this.Pontuacao = 0;
                return;
            }

            this.RegraAplicavel = valoresDasFaces.Contains(1) && valoresDasFaces.Contains(2)
                                  && valoresDasFaces.Contains(3) && valoresDasFaces.Contains(4);
            this.RegraAplicavel = this.RegraAplicavel || (valoresDasFaces.Contains(2) && valoresDasFaces.Contains(3)
                                  && valoresDasFaces.Contains(4) && valoresDasFaces.Contains(5));
            this.RegraAplicavel = this.RegraAplicavel || (valoresDasFaces.Contains(3) && valoresDasFaces.Contains(4)
                                  && valoresDasFaces.Contains(5) && valoresDasFaces.Contains(6));
            this.Pontuacao = this.RegraPodeSerAplicada() ? 15 : 0;
        }
    }
}
