using System;
using System.Linq;
using System.Collections.Generic;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace Aurora.Core
{
    public class Jogo
    {
        public int QuantidadeDeDados { get; private set; }
        public List<IDado> Dados { get; private set; }

        public IList<IRegrasDePontuacao> RegrasDePontuacao { get; }

        public Jogo(int qtdeDadosNoJogo)
        {
            QuantidadeDeDados = qtdeDadosNoJogo;
            for (var i = 0; i < QuantidadeDeDados; i++)
            {
                Dados.Add(new Dado());
            }
            if (RegrasDePontuacao == null)
            {
                RegrasDePontuacao = new List<IRegrasDePontuacao>();
            }

            //TODO Refatorar e aplicar builder se possível
            DefinirRegrasDoJogo(new RegraUm());
            DefinirRegrasDoJogo(new RegraDois());
            DefinirRegrasDoJogo(new RegraTres());
            DefinirRegrasDoJogo(new RegraQuatro());
            DefinirRegrasDoJogo(new RegraCinco());
            DefinirRegrasDoJogo(new RegraSeis());
            DefinirRegrasDoJogo(new RegraPar());
            DefinirRegrasDoJogo(new RegraDoisPares());
            DefinirRegrasDoJogo(new RegraTrio());
            DefinirRegrasDoJogo(new RegraSequenciaMenor());
            DefinirRegrasDoJogo(new RegraSequenciaMaior());
            DefinirRegrasDoJogo(new RegraFullHouse());
            DefinirRegrasDoJogo(new RegraAurora());
        }

        public void DefinirRegrasDoJogo(IRegrasDePontuacao regra)
        {
            RegrasDePontuacao.Add(regra);
        }

        public void LancarDados()
        {
            Dados.ForEach(d =>
            {
                d.LancarDado();
            });
            var valoresDasFaces = LerFacesDosDados();
            foreach (var regra in RegrasDePontuacao)
            {
                regra.AplicarRegra(valoresDasFaces);
            }
        }

        public int[] LerFacesDosDados()
        {
            var valores = Dados.Select(d => d.LerValorDaFace()).ToArray();
            return valores;
        }

        public Dictionary<KeyValuePair<int, string>, int> ListarRegrasAplicaveis()
        {
            return RegrasDePontuacao.Where(regra => regra.RegraPodeSerAplicada())
                .ToDictionary(
                    regra => new KeyValuePair<int, string>(regra.ObterIdRegra(), regra.ObterNomeRegra()), 
                    regra => regra.ObterPontuacao()
                );
        }
    }
}
