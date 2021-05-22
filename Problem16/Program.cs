using System;
using System.Numerics;

namespace Problem16
{
    // 2ⁿ = 32768  (where n = 15) and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

    // What is the sum of the digits of the number 2ⁿ (where n = 1000)?
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;

            var twoToTheThousand = (BigInteger)Math.Pow(2, 1000);

            var digitCharArray = (twoToTheThousand.ToString()).ToCharArray();

            foreach (var digit in digitCharArray)
            {
                if (double.TryParse(digit.ToString(), out double d))
                {
                    result += d;
                }
            }

            Console.Write("Problem 16: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }
    }
}
