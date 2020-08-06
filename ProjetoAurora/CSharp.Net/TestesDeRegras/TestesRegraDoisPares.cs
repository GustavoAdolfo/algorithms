using Aurora.Core.Interfaces;
using Aurora.Core.Regras;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraDoisPares
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraDoisPares();
            }
        }

        [TestMethod]
        public void TestRegraDoisParesAplicavel_1()
        {
            int[] valoresDosDados = { 1, 4, 2, 1, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 10);
        }

        [TestMethod]
        public void TestRegraDoisParesAplicavel_2()
        {
            int[] valoresDosDados = { 6, 3, 2, 6, 3 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 18);
        }

        [TestMethod]
        public void TestRegraDoisParesAplicavel_3()
        {
            int[] valoresDosDados = { 1, 3, 1, 3, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 8);
        }

        [TestMethod]
        public void TestRegraDoisParesNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraDoisParesNaoAplicavel_2()
        {
            int[] valoresDosDados = { 2, 3, 5, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
