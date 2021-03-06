using System;
using System.Collections.Generic;

namespace Problem12
{
    /* The sequence of triangle numbers is generated by adding the natural numbers. So the 7th triangle number would be 1 + 2 + 3 + 4 + 5 + 6 + 7 = 28. The first ten terms would be:
     *
     *      1, 3, 6, 10, 15, 21, 28, 36, 45, 55, ...           
     *
     * Let us list the factors of the first seven triangle numbers:
     *
     *      1: 1
     *      3: 1,3
     *      6: 1,2,3,6
     *      10: 1,2,5,10
     *      15: 1,3,5,15
     *      21: 1,3,7,21
     *      28: 1,2,4,7,14,28
     *
     * We can see that 28 is the first triangle number to have over five divisors.
     *
     * What is the value of the first triangle number to have over five hundred divisors? */
    class Program
    {
        static void Main(string[] args)
        {
            var divisors = new List<long>();
            long limit = 1;
            long result = 0;

            while (divisors.Count <= 501)
            {
                result = 0;

                for (var j = 1; j <= limit; j++)
                {
                    result += j;
                }

                divisors = GetDivisors(result);
                limit++;
            }

            Console.Write("Problem 12: ");
            Console.WriteLine("The result is " + result);

            Console.ReadLine();
        }

        static List<long> GetDivisors(long number)
        {
            List<long> divisors = new List<long>();
            
            for (long i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    divisors.Add(i);
                }
            }

            return divisors;
        }
    }
}
