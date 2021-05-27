using System;
using System.Numerics;

namespace Problem20
{
    /* n! means n × (n − 1) × ... × 3 × 2 × 1

       For example, 10! = 10 × 9 × ... × 3 × 2 × 1 = 3628800,
       and the sum of the digits in the number 10! is 3 + 6 + 2 + 8 + 8 + 0 + 0 = 27.
       
       Find the sum of the digits in the number 100! */
    class Program
    {
        static void Main(string[] args)
        {
            var result = Bang(new BigInteger(100));
            result = SumOfDigits(result);

            Console.Write("Problem 19: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }

        private static BigInteger Bang(BigInteger number)
        {
            BigInteger result = 1;

            while (number > 0)
            {
                result *= number;
                number -= 1;
            }

            return result;
        }

        private static BigInteger SumOfDigits(BigInteger number)
        {
            BigInteger result = 0;

            var numberString = number.ToString();

            var numberCharArray = numberString.ToCharArray();

            foreach (var n in numberCharArray)
            {
                result += BigInteger.Parse(n.ToString());
            }

            return result;
        }
    }
}
