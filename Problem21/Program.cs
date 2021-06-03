using System;
using System.Collections.Generic;

namespace Problem21
{
    /* Let d(n) be defined as the sum of proper divisors of n(numbers less than n which divide evenly into n).
     * 
     * If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.
     * 
     * For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.
     * 
     * Evaluate the sum of all the amicable numbers under 10000. */
    class Program
    {
        static void Main(string[] args)
        {
            var result = 0;
            var amicableNumbers = new List<int>();

            // 1 cannot be an amicable number as it has no proper divisors
            for (var a = 2; a < 10000; a++)
            {
                var b = SumOfProperDivisors(a);

                var sum2 = SumOfProperDivisors(b);


                if (a < 10000 && // values less then 10,000...
                    a == sum2 && // end result of the two functions equals each other...
                    a != b && // a and b are not equal...
                    !amicableNumbers.Contains(a) && // we don't want duplicates...
                    !amicableNumbers.Contains(b)) // we don't want duplicates
                {
                    amicableNumbers.Add(a);
                    amicableNumbers.Add(b);
                }
            }

            if (amicableNumbers.Count > 0)
            {
                foreach (var i in amicableNumbers)
                {
                    result += i;
                }
            }

            Console.Write("Problem 21: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }

        // find and sum the proper divisors
        public static int SumOfProperDivisors (int number)
        {
            var result = 0;
            var divisors = new List<int>();

            for (var i = 1; i <= number; i++)
            {
                if (i != number && number % i == 0)
                {
                    divisors.Add(i);
                }
            }

            foreach (var d in divisors)
            {
                result += d;
            }

            return result;
        }
    }
}
