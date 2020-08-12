using NUnit.Framework;
using RomanConverter;

namespace CSharp
{
    public class RomanConverterTest
    {
        private RomanConverterImp Converter;

        [SetUp]
        public void Setup()
        {
            Converter = new RomanConverterImp();
        }

        [Test]
        public void Know_I_Symbol()
        {
            var number = Converter.Convert("I");
            Assert.AreEqual(1, number);
        }

        [Test]
        public void Know_V_Symbol()
        {
            var number = Converter.Convert("V");
            Assert.AreEqual(5, number);
        }

        [Test]
        public void Know_X_Symbol()
        {
            var number = Converter.Convert("X");
            Assert.AreEqual(10, number);
        }

        [Test]
        public void Know_L_Symbol()
        {
            var number = Converter.Convert("L");
            Assert.AreEqual(50, number);
        }

        [Test]
        public void Know_C_Symbol()
        {
            var number = Converter.Convert("C");
            Assert.AreEqual(100, number);
        }

        [Test]
        public void Know_D_Symbol()
        {
            var number = Converter.Convert("D");
            Assert.AreEqual(500, number);
        }

        [Test]
        public void Know_M_Symbol()
        {
            var number = Converter.Convert("M");
            Assert.AreEqual(1000, number);
        }

        [Test]
        public void Know_Two_Equals_Symbols()
        {
            var number = Converter.Convert("II");
            Assert.AreEqual(2, number);
        }

        [Test]
        public void Know_Three_Equals_Symbols()
        {
            var number = Converter.Convert("XXX");
            Assert.AreEqual(30, number);
        }

        [Test]
        public void Know_Groups_Of_Thow_Equals_Symbols()
        {
            var number = Converter.Convert("XXII");
            Assert.AreEqual(22, number);
        }

        [Test]
        public void Know_Symbols_With_Subtraction_Right_To_Left()
        {
            var number = Converter.Convert("CXLIX");
            Assert.AreEqual(149, number);
        }

        [Test]
        public void Know_Symbols_With_Subtraction_Left_To_Right()
        {
            var number = Converter.Convert("CMXLIX");
            Assert.AreEqual(949, number);
        }
    }
}