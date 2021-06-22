using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem25
{
    /* The Fibonacci sequence is defined by the recurrence relation:
     * 
     * Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
     * Hence the first 12 terms will be:
     * 
     * F1 = 1
     * F2 = 1
     * F3 = 2
     * F4 = 3
     * F5 = 5
     * F6 = 8
     * F7 = 13
     * F8 = 21
     * F9 = 34
     * F10 = 55
     * F11 = 89
     * F12 = 144
     * 
     * The 12th term, F12, is the first term to contain three digits.
     * 
     * What is the index of the first term in the Fibonacci sequence to contain 1000 digits? */
    class Program
    {
        static void Main(string[] args)
        {
            /* The do while loop calculates up to the last term to have under
             * 1000 characters, therefore we initialize this value at 1 since
             * we're looking for the first number with 1000 characters */
            int result = 1;

            var fibSequence = new List<BigInteger> { 1, 2 };

            BigInteger newestTerm;

            // Populate the Fibonacci sequence where values have under 1000 characters
            do
            {
                newestTerm = fibSequence[^2] + fibSequence[^1];
                
                fibSequence.Add(newestTerm);

            } while (newestTerm.ToString().Length < 1000);

            result += fibSequence.Count;

            Console.Write("Problem 25: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }
    }
}
