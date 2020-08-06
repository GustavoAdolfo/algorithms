
using Aurora.Core.Interfaces;

namespace Aurora.Core.Regras
{
    public abstract class Regra : IRegrasDePontuacao
    {
        protected int IdRegra { get; set; }
        protected string NomeRegra { get; set; }
        protected int Pontuacao { get; set; }
        protected bool RegraAplicavel { get; set; }

        public abstract void AplicarRegra(int[] valoresDasFaces);

        public int ObterPontuacao()
        {
            return Pontuacao;
        }

        public string ObterNomeRegra()
        {
            return NomeRegra;
        }

        public int ObterIdRegra()
        {
            return IdRegra;
        }

        public bool RegraPodeSerAplicada()
        {
            return RegraAplicavel;
        }
    }
}
