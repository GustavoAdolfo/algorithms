using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraQuatro
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraQuatro();
            }
        }

        [TestMethod]
        public void TestRegraQuatroAplicavel_1()
        {
            int[] valoresDosDados = {2, 3, 2, 1, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 4);
        }

        [TestMethod]
        public void TestRegraQuatroAplicavel_2()
        {
            int[] valoresDosDados = { 4, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 8);
        }

        [TestMethod]
        public void TestRegraQuatroAplicavel_3()
        {
            int[] valoresDosDados = { 4, 3, 4, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 12);
        }

        [TestMethod]
        public void TestRegraQuatroNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 1, 6, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraQuatroNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 3, 3, 6, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
