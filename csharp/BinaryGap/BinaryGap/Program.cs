using System;
using System.Linq;

namespace BinaryGap
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("3 have {0} binary gap", Solution(3));
            Console.WriteLine("9 have {0} binary gap", Solution(9));
            Console.WriteLine("21 have {0} binary gap", Solution(21));
            Console.WriteLine("101 have {0} binary gap", Solution(101));
            Console.WriteLine("509 have {0} binary gap", Solution(509));
            Console.WriteLine("736 have {0} binary gap", Solution(736));
            Console.WriteLine("529 have {0} binary gap", Solution(529));
            Console.WriteLine("1111 have {0} binary gap", Solution(1111));

            Console.ReadKey();
        }

        public static int Solution(int N)
        {
            var binary = Convert.ToString(N, 2);
            var split = binary.Trim('0').Split(new[] { '1' });
            var result = split.Max(x => x.Length);
            return result;
        }
    }
}
