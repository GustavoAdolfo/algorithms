using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraSequenciaMenor
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraSequenciaMenor();
            }
        }

        [TestMethod]
        public void TestRegraSequenciaMenorAplicavel_1()
        {
            int[] valoresDosDados = {1, 3, 2, 1, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 15);
        }

        [TestMethod]
        public void TestRegraSequenciaMenorAplicavel_2()
        {
            int[] valoresDosDados = { 5, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 15);
        }

        [TestMethod]
        public void TestRegraSequenciaMenorAplicavel_3()
        {
            int[] valoresDosDados = { 1, 3, 4, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 15);
        }

        [TestMethod]
        public void TestRegraSequenciaMenorNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 4, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraSequenciaMenorNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 6, 5, 6, 5, 3, 1 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
