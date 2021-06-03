using System;
using System.Collections.Generic;

namespace Problem23
{
    /* A perfect number is a number for which the sum of its proper divisors is exactly equal to the number.
     * For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 
     * 28 is a perfect number.
     *
     * A number n is called deficient if the sum of its proper divisors is less than n and it is called 
     * abundant if this sum exceeds n.
     *
     * As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written 
     * as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers 
     * greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot 
     * be reduced any further by analysis even though it is known that the greatest number that cannot be 
     * expressed as the sum of two abundant numbers is less than this limit.
     *
     * Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers. */
    class Program
    {
        static void Main(string[] args)
        {
            const int limit = 28123;

            int result = 0;

            var abundents = new List<int>();

            for (var i = 1; i <= limit; i++)
            {
                var numericalType = GetNumericalType(i);

                if (numericalType == NumericalType.ABUNDANT)
                {
                    abundents.Add(i);
                }
            }

            bool[] canBeWrittenasAbundent = new bool[limit + 1];

            for (var i = 0; i < abundents.Count; i++)
            {
                for (var j = 0; j < abundents.Count; j++)
                {
                    if (abundents[i] + abundents[j] <= limit)
                    {
                        canBeWrittenasAbundent[abundents[i] + abundents[j]] = true;
                    }                    
                }
            }

            //Sum the numbers which are not sums of two abundant numbers
            for (int i = 1; i <= limit; i++)
            {
                if (!canBeWrittenasAbundent[i])
                {
                    result += i;
                }
            }

            Console.Write("Problem 23: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }

        // find and sum the proper divisors
        private static NumericalType GetNumericalType(int number)
        {
            var properDivisors = new List<int>();
            var sum = 0;

            for (var i = 1; i <= number; i++)
            {
                if (i != number && number % i == 0)
                {
                    properDivisors.Add(i);
                }
            }

            foreach (var divisor in properDivisors)
            {
                sum += divisor;
            }

            if (sum < number)
            {
                return NumericalType.DEFICIENT;
            }
            else if (sum == number)
            {
                return NumericalType.PERFECT;
            }
            else
            {
                return NumericalType.ABUNDANT;
            }
        }

        private enum NumericalType
        {
            DEFICIENT,
            PERFECT,
            ABUNDANT
        }
    }
}
