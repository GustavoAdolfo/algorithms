using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraCinco
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraCinco();
            }
        }

        [TestMethod]
        public void TestRegraCincoAplicavel_1()
        {
            int[] valoresDosDados = {2, 3, 5, 1, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 5);
        }

        [TestMethod]
        public void TestRegraCincoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 3, 2, 5, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 10);
        }

        [TestMethod]
        public void TestRegraCincoAplicavel_3()
        {
            int[] valoresDosDados = { 5, 3, 5, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 15);
        }

        [TestMethod]
        public void TestRegraCincoNaoAplicavel_1()
        {
            int[] valoresDosDados = { 2, 3, 1, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraCincoNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 4, 4, 6, 3 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
