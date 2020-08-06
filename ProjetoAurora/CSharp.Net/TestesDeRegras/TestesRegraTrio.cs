using Aurora.Core.Interfaces;
using Aurora.Core.Regras;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesTestesRegraTrio
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraTrio();
            }
        }

        [TestMethod]
        public void TestTestesRegraTrioAplicavel_1()
        {
            int[] valoresDosDados = { 1, 1, 2, 1, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 3);
        }

        [TestMethod]
        public void TestTestesRegraTrioAplicavel_2()
        {
            int[] valoresDosDados = { 6, 3, 3, 6, 3 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 9);
        }

        [TestMethod]
        public void TestTestesRegraTrioAplicavel_3()
        {
            int[] valoresDosDados = { 1, 2, 2, 3, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 6);
        }

        [TestMethod]
        public void TestTestesRegraTrioNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestTestesRegraTrioNaoAplicavel_2()
        {
            int[] valoresDosDados = { 2, 3, 5, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
