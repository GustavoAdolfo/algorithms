using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraAurora
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraAurora();
            }
        }

        [TestMethod]
        public void TestRegraAuroraAplicavel_1()
        {
            int[] valoresDosDados = {1, 1, 1, 1, 1};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 50);
        }

        [TestMethod]
        public void TestRegraAuroraAplicavel_2()
        {
            int[] valoresDosDados = { 2, 2, 2, 2, 2, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 50);
        }

        [TestMethod]
        public void TestRegraAuroraAplicavel_3()
        {
            int[] valoresDosDados = { 1, 1, 1, 1 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 50);
        }

        [TestMethod]
        public void TestRegraAuroraNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraAuroraNaoAplicavel_2()
        {
            int[] valoresDosDados = { 2, 3, 4, 2, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
