using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraDois
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraDois();
            }
        }

        [TestMethod]
        public void TestRegraDoisAplicavel_1()
        {
            int[] valoresDosDados = {2, 3, 2, 1, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 4);
        }

        [TestMethod]
        public void TestRegraDoisAplicavel_2()
        {
            int[] valoresDosDados = { 1, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 2);
        }

        [TestMethod]
        public void TestRegraDoisAplicavel_3()
        {
            int[] valoresDosDados = { 2, 3, 2, 6, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 6);
        }

        [TestMethod]
        public void TestRegraDoisNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 1, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraDoisNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 4, 4, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
