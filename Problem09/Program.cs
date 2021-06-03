using System;

namespace Problem09
{
    /* A Pythagorean triplet is a set of three natural numbers, a < b<c, for which,
     *
     * a2 + b2 = c2
     * For example, 32 + 42 = 9 + 16 = 25 = 52.
     *
     *
     * There exists exactly one Pythagorean triplet for which a + b + c = 1000.
     *
     * Find the product abc. */
    class Program
    {
        static void Main(string[] args)
        {
            int a = 0, b = 0, c = 0, sum = 1000, result = 0;

            for (var i = 1; i < sum; i++)
            {
                for (var j = 1; j < sum; j++)
                {
                    for (var k = 1; k < sum; k++)
                    {
                        if (i + j + k == 1000 && IsPythagorean(i, j, k))
                        {
                            a = i;
                            b = j;
                            c = k;
                            result = a * b * c;
                        }
                    }
                }
            }

            Console.Write("Problem 9: ");
            Console.WriteLine("The result is " + result);

            Console.Write("\nTriplet: " + a + " " + b + " " + c);
            Console.ReadLine();
        }

        static bool IsPythagorean(int a, int b, int c)
        {
            if (Math.Pow(a, 2) + Math.Pow(b, 2) == Math.Pow(c, 2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
