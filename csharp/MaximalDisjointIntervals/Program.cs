using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] { 1, 12, 42, 70, 36, -4, 43, 15 };
            var b = new[] { 5, 15, 44, 72, 36, 2, 69, 24 };
            var result = Solution(a, b);
            Console.WriteLine($"\nResultado = {result}");
            Console.ReadKey();


            //Outra();
            //Console.ReadKey();
        }

        private static void Outra()
        {
            var A = 5;
            var B = 9;

            var sA = new String('a', A);
            var sB = new String('b', B);
            var final = string.Empty;

            if (A == B)
            {
                for (var i = 0; i < A; i++)
                {
                    final += $"ab";
                }
            }
            else
            {
                if ((A - B) > 2)
                {
                    final += "aa";
                    var contB = 1;
                    for (var i = 2; i < A; i++)
                    {
                        if (contB <= B)
                        {
                            final += "b";
                            contB++;
                        }
                        final += "a";
                    }
                }

                else if ((B - A) > 2)
                {
                    var control = B - A;
                    final += "bb";
                    var contA = 1;
                    for (var i = 2; i < B; i++)
                    {
                        if (contA <= A)
                        {
                            final += "a";
                            contA++;
                        }
                        final += "b";
                    }
                }
                else
                {
                    var total = A > B ? A : B;
                    var ctrlA = 0;
                    var ctrlB = 0;
                    for (var i = 1; i < total; i++)
                    {
                        if (i <= A)
                        {
                            if (ctrlA < 3)
                            {
                                final += "a";
                                ctrlA++;
                            }
                            else
                            {
                                ctrlA = 0;
                            }
                        }

                        if (i <= B)
                        {
                            if (ctrlB < 3)
                            {
                                final += "b";
                                ctrlB++;
                            }
                            else
                            {
                                ctrlB = 0;
                            }
                        }
                    }
                }


                Console.WriteLine(final);
            }
        }

        public static int Solution(int[] A, int[] B)
        {
            var orderedIntervals = CreateIntervals(A, B);
            var disjoints = 0;
            var intervalsIndexs = orderedIntervals.Count - 1;
            var intervalTop = orderedIntervals[0];
            var endpoint = orderedIntervals[0][1];

            Console.WriteLine(new string('*', 40));
            Console.WriteLine("Disjunções\n");

            for (var control = 0; control <= intervalsIndexs; control++)
            {
                // O primeiro intervalo sempre será incluído
                // Including the firs interval
                if (intervalTop == orderedIntervals[control])
                {
                    Console.WriteLine($"({intervalTop[0]}, {intervalTop[1]})");
                    disjoints++;
                    continue;
                }

                if (orderedIntervals[control][0] > endpoint)
                {
                    intervalTop = orderedIntervals[control];
                    endpoint = orderedIntervals[control][1];
                    Console.WriteLine($"({intervalTop[0]}, {intervalTop[1]})");
                    disjoints++;
                    continue;
                }

                // If overlap, update interval
                // Atualizando intervalo se houver sobreposição
                intervalTop = new[] { Math.Min(intervalTop[0], orderedIntervals[control][0]), Math.Max(intervalTop[1], orderedIntervals[control][1]) };
            }

            return disjoints;
        }

        public static List<int[]> CreateIntervals(int[] A, int[] B)
        {
            var numberOfIntervals = A.Length > B.Length || A.Length == B.Length ? B.Length : A.Length;
            Console.WriteLine($"{nameof(numberOfIntervals)} = {numberOfIntervals}");

            // equaling number of elements
            if (A.Length > numberOfIntervals)
            {
                Array.Resize(ref A, numberOfIntervals);
            }
            if (B.Length > numberOfIntervals)
            {
                Array.Resize(ref B, numberOfIntervals);
            }

            var intervals = A.Select((x, y) => new[] { x, B[y] }).OrderBy(i => i[0]).ThenBy(i => i[1]).ToList();
            Console.Write("Intervalos: ");
            intervals.ForEach(i => Console.Write($"({i[0]}, {i[1]}) "));
            Console.WriteLine();

            return intervals;
        }

    }
}
