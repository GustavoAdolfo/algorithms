using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraTres
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraTres();
            }
        }

        [TestMethod]
        public void TestRegraTresAplicavel_1()
        {
            int[] valoresDosDados = {2, 3, 2, 1, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 3);
        }

        [TestMethod]
        public void TestRegraTresAplicavel_2()
        {
            int[] valoresDosDados = { 1, 3, 3, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 6);
        }

        [TestMethod]
        public void TestRegraTresAplicavel_3()
        {
            int[] valoresDosDados = { 2, 3, 3, 6, 3 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 9);
        }

        [TestMethod]
        public void TestRegraTresNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 2, 1, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraTresNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 4, 4, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
