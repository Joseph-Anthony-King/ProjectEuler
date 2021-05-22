using System;
using System.Collections.Generic;

namespace Problem10
{
    // The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.

    // Find the sum of all the primes below two million.
    class Program
    {
        static void Main(string[] args)
        {
            var primes = new List<double>();
            double result = 0;

            for (var i = 2; i < 2000000; i++)
            {
                if (IsPrime(i))
                {
                    primes.Add(i);
                }
            }

            foreach (var prime in primes)
            {
                result += prime;
            }

            Console.Write("Problem 10: ");
            Console.WriteLine("The result is " + result);

            Console.ReadLine();
        }

        public static bool IsPrime(double number)
        {
            if (number <= 1)
            {
                return false;
            }

            if (number == 2)
            {
                return true;
            }

            if (number % 2 == 0)
            {
                return false;
            }

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
