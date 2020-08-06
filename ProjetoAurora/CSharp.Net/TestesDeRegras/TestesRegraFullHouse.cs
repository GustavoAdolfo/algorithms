using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aurora.Core.Interfaces;
using Aurora.Core.Regras;

namespace TestesDeRegras
{
    [TestClass]
    public class TestesRegraFullHouse
    {
        private IRegrasDePontuacao _regra;

        [TestInitialize]
        public void Iniciliazar()
        {
            if (_regra == null)
            {
                _regra = new RegraFullHouse();
            }
        }

        [TestMethod]
        public void TestRegraFullHouseAplicavel_1()
        {
            int[] valoresDosDados = {1, 1, 4, 1, 4};
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 11);
        }

        [TestMethod]
        public void TestRegraFullHouseAplicavel_2()
        {
            int[] valoresDosDados = { 2, 3, 2, 3, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 12);
        }

        [TestMethod]
        public void TestRegraFullHouseAplicavel_3()
        {
            int[] valoresDosDados = { 1, 3, 1, 3, 1 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsTrue(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 9);
        }

        [TestMethod]
        public void TestRegraFullHouseNaoAplicavel_1()
        {
            int[] valoresDosDados = { 5, 3, 2, 6, 4 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }

        [TestMethod]
        public void TestRegraFullHouseNaoAplicavel_2()
        {
            int[] valoresDosDados = { 2, 3, 4, 6, 2 };
            _regra.AplicarRegra(valoresDosDados);
            Assert.IsFalse(_regra.RegraPodeSerAplicada());
            Assert.AreEqual(_regra.ObterPontuacao(), 0);
        }
    }
}
