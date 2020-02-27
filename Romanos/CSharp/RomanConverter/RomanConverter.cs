using System.Collections.Generic;
using System.Linq;

namespace RomanConverter
{
    public class RomanConverterImp
    {
        private static Dictionary<char, int> RomanSymbolsDictionary = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public int Convert(string roman)
        {
            if (roman.Length == 1)
            {
                return ConvertUnicSymbol(roman[0]);
            }
            if (roman.Length > 1)
            {
                // return ConvertComplexSymbolRightToLeft(roman);
                return ConvertComplexSymbolLeftToRight(roman);
            }

            return 0;
        }

        public int ConvertComplexSymbolRightToLeft(string roman)
        {
            var symbols = roman.ToArray().Reverse().ToArray();
            var totalSymbols = symbols.Count();
            var numberResult = new List<int>();

            for (var i = 0; i < totalSymbols; i++)
            {
                var rightNumber = ConvertUnicSymbol(symbols[i]);
                if (totalSymbols > (i + 1))
                {
                    var leftNumber = ConvertUnicSymbol(symbols[i + 1]);
                    if (leftNumber < rightNumber)
                    {
                        numberResult.Add(rightNumber - leftNumber);
                        i += 1;
                        continue;
                    }
                }
                numberResult.Add(rightNumber);
            }

            return numberResult.Sum(x => x);
        }

        public int ConvertComplexSymbolLeftToRight(string roman)
        {
            var symbols = roman.ToArray().Reverse().ToArray();
            var totalSymbols = symbols.Count();
            var numberResult = new List<int>();

            for (var i = 0; i < totalSymbols; i++)
            {
                var leftNumber = ConvertUnicSymbol(symbols[i]);
                if (i > 0)
                {
                    var rightNumber = ConvertUnicSymbol(symbols[i - 1]);
                    if (leftNumber < rightNumber)
                    {
                        numberResult.Add(leftNumber * -1);
                        continue;
                    }
                }
                numberResult.Add(leftNumber);
            }

            return numberResult.Sum(x => x);
        }

        private int ConvertUnicSymbol(char roman)
        {
            return RomanSymbolsDictionary[roman];
        }
    }
}
