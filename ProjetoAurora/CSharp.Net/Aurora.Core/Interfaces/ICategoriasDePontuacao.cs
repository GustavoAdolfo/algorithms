namespace Aurora.Core.Interfaces
{
    public interface IRegrasDePontuacao
    {
        void AplicarRegra(int[] valoresDasFaces);
        int ObterPontuacao();
        string ObterNomeRegra();
        int ObterIdRegra();
        bool RegraPodeSerAplicada();
    }
}