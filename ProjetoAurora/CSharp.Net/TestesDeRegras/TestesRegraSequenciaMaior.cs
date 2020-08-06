using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraSequenciaMaior
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraSequenciaMaior();
            }
        }

        [TestMethod]
        public void TestRegraSequenciaMaiorAplicavel_1()
        {
            int[] valoresDosDados = {1, 3, 2, 5, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 20);
        }

        [TestMethod]
        public void TestRegraSequenciaMaiorAplicavel_2()
        {
            int[] valoresDosDados = { 5, 3, 4, 6, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 20);
        }

        [TestMethod]
        public void TestRegraSequenciaMaiorAplicavel_3()
        {
            int[] valoresDosDados = { 1, 4, 2, 3, 4, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 20);
        }

        [TestMethod]
        public void TestRegraSequenciaMaiorNaoAplicavel_1()
        {
            int[] valoresDosDados = { 3, 3, 2, 2, 4, 1 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraSequenciaMaiorNaoAplicavel_2()
        {
            int[] valoresDosDados = { 6, 3, 5, 6, 5, 1, 1 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
