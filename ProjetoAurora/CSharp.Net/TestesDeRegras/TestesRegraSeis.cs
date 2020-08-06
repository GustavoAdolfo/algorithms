using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraSeis
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraSeis();
            }
        }

        [TestMethod]
        public void TestRegraSeisAplicavel_1()
        {
            int[] valoresDosDados = {2, 3, 2, 6, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 6);
        }

        [TestMethod]
        public void TestRegraSeisAplicavel_2()
        {
            int[] valoresDosDados = { 6, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 12);
        }

        [TestMethod]
        public void TestRegraSeisAplicavel_3()
        {
            int[] valoresDosDados = { 2, 3, 6, 6, 6 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 18);
        }

        [TestMethod]
        public void TestRegraSeisNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 1, 5, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraSeisNaoAplicavel_2()
        {
            int[] valoresDosDados = { 1, 4, 4, 2, 5 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
