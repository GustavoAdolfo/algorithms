using System;
using System.CodeDom;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TesteOitoViagensComLinq()
        {
            var pesosPacotes = new [] { "27", "53", "70", "81", "17", "35", "64", "22", "91", "50", "37", "43", "72", "69"};
            var retornoComLinq = EntregaDePacotes.Program.CalcularViagensUsandoLinq(pesosPacotes);
            Assert.AreEqual(retornoComLinq, 8);
        }

        [TestMethod]
        public void TesteOitoViagensSemLinq()
        {
            var pesosPacotes = new[] { "27", "53", "70", "81", "17", "35", "64", "22", "91", "50", "37", "43", "72", "69" };
            var retornoSemLinq = EntregaDePacotes.Program.CalcularViagensSemLinq(pesosPacotes);
            Assert.AreEqual(retornoSemLinq, 8);
        }

        [TestMethod]
        public void TesteTresViagensComLinq()
        {
            var pesosPacotes = new[] { "29", "80", "31", "3", "69" };
            var retornoComLinq = EntregaDePacotes.Program.CalcularViagensUsandoLinq(pesosPacotes);
            Assert.AreEqual(retornoComLinq, 3);
        }

        [TestMethod]
        public void TesteTresViagensSemLinq()
        {
            var pesosPacotes = new[] { "29", "80", "31", "3", "69" };
            var retornoSemLinq = EntregaDePacotes.Program.CalcularViagensSemLinq(pesosPacotes);
            Assert.AreEqual(retornoSemLinq, 3);
        }

        [TestMethod]
        public void TesteDuasViagensDeUmVolumeCadaComLinq()
        {
            var pesosPacotes = new[] { "74", "89" };
            var retornoComLinq = EntregaDePacotes.Program.CalcularViagensUsandoLinq(pesosPacotes);
            Assert.AreEqual(retornoComLinq, 2);
        }

        [TestMethod]
        public void TesteDuasViagensDeUmVolumeCadaSemLinq()
        {
            var pesosPacotes = new[] { "74", "89" };
            var retornoSemLinq = EntregaDePacotes.Program.CalcularViagensSemLinq(pesosPacotes);
            Assert.AreEqual(retornoSemLinq, 2);
        }
    }
}
