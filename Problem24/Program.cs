using System;
using System.Collections.Generic;

namespace Problem24
{
    /* A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation 
     * of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, 
     * we call it lexicographic order.The lexicographic permutations of 0, 1 and 2 are:
     *
     * 012   021   102   120   201   210
     *
     * What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9? */
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string result = "";

                List<int> numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

                int limit = 1000000;

                string method = "";

                bool useBruteForceMethod = false;

                if (useBruteForceMethod)
                {
                    result = BruteForceMethod(
                        numbers, 
                        limit,
                        ref method);
                }
                else
                {
                    result = CombinatoricsMethod(
                        numbers,
                        limit,
                        ref method);
                }

                Console.Write("Problem 24: ");
                Console.WriteLine("The result is " + result);
                Console.WriteLine("Calculated using the " + method);
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }

        private static string BruteForceMethod(
            List<int> numbers,
            int limit,
            ref string method)
        {
            method = "Brute Force Method";

            string result = "";

            int count = 1;

            // Cycle through lexicographic permutations until we reach the inidcated limit
            while (count < limit)
            {
                int numbersCount = numbers.Count;

                int i = numbersCount - 1;

                while (numbers[i - 1] >= numbers[i])
                {
                    i -= 1;
                }

                int j = numbersCount;

                while (numbers[j - 1] <= numbers[i - 1])
                {
                    j -= 1;
                }

                // Swap values at position i-1 and j-1
                Swap(i - 1, j - 1, ref numbers);

                i++;

                j = numbersCount;

                while (i < j)
                {
                    Swap(i - 1, j - 1, ref numbers);
                    i++;
                    j--;
                }

                count++;
            }

            /* now that we've reached the limit permutation we output the results
             * as a string */

            for (int k = 0; k < numbers.Count; k++)
            {
                result += numbers[k];
            }

            return result;
        }

        private static string CombinatoricsMethod(
            List<int> numbers,
            int limit,
            ref string method)
        {
            method = "Combinatoric Method";

            string result = "";

            int numbersCount = numbers.Count;

            limit -= 1;

            for (int i = 1; i < numbersCount; i++) {

                var factorial = Factor(numbersCount - i);

                // Ascertain the next value of the result
                int j = limit / factorial;

                // Now that we have the value reset the limit
                limit %= factorial;

                // Add the value to the final result
                result += numbers[j];

                // Remove the value from the available list
                numbers.RemoveAt(j);

                // if limit is at 0 we are at the limit permutation
                if (limit == 0)
                {
                    break;
                }
            }

            for (int i = 0; i < numbers.Count; i++)
            {
                result += numbers[i];
            }

            return result;
        }

        private static void Swap(int i, int j, ref List<int> perm)
        {
            int k = perm[i];

            perm[i] = perm[j];

            perm[j] = k;
        }

        private static int Factor(int i)
        {
            if (i < 0)
            {
                return 0;
            }

            int p = 1;

            for (int j = 1; j <= i; j++)
            {
                p *= j;
            }

            return p;
        }
    }
}
