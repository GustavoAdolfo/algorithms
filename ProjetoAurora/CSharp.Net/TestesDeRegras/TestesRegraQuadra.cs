using Aurora.Core.Interfaces;
using Aurora.Core.Regras;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesTestesRegraQuadra
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraQuadra();
            }
        }

        [TestMethod]
        public void TestTestesRegraQuadraAplicavel_1()
        {
            int[] valoresDosDados = { 1, 1, 1, 1, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 4);
        }

        [TestMethod]
        public void TestTestesRegraQuadraAplicavel_2()
        {
            int[] valoresDosDados = { 6, 3, 3, 3, 3 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 12);
        }

        [TestMethod]
        public void TestTestesRegraQuadraAplicavel_3()
        {
            int[] valoresDosDados = { 1, 2, 2, 2, 2, 4, 3, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 8);
        }

        [TestMethod]
        public void TestTestesRegraQuadraNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 2, 6, 4, 3, 5, 6 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestTestesRegraQuadraNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 2, 3, 5, 6, 7, 8, 9, 9, 9 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
