using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem07
{
    // By listing the first six prime numbers: 2, 3, 5, 7, 11, and 13, we can see that the 6th prime is 13.

    // What is the 10 001st prime number?
    class Program
    {
        static void Main(string[] args)
        {
            var primes = new List<int>();
            int possiblePrime = 2;

            while (primes.Count < 10001)
            {
                if (IsPrime(possiblePrime))
                {
                    primes.Add(possiblePrime);
                }

                possiblePrime++;
            }

            Console.Write("Problem 7: ");
            Console.WriteLine("The result is " + primes.LastOrDefault());

            Console.ReadLine();
        }

        public static bool IsPrime(int number)
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
