﻿using System;
using System.Collections.Generic;

namespace Problem02
{
    class Program
    {
        /* Each new term in the Fibonacci sequence is generated by adding the previous two terms.By starting with 1 and 2, the first 10 terms will be:

            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...

            By considering the terms in the Fibonacci sequence whose values do not exceed four million, find the sum of the even-valued terms. */
        static void Main(string[] args)
        {
            var fibSequence = new List<int> { 1, 2 };
            int newestTerm;
            var result = 0;

            // Populate the Fibonacci sequence where values do not exceed four million
            do
            {
                newestTerm = fibSequence[fibSequence.Count - 2] + fibSequence[fibSequence.Count - 1];

                if (newestTerm < 4000000)
                {
                    fibSequence.Add(newestTerm);
                }

            } while (newestTerm < 4000000);

            // Find the sum of the even valued terms
            foreach (var fib in fibSequence)
            {
                if (fib % 2 == 0)
                {
                    result += fib;
                }
            }

            Console.Write("Problem 2: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }
    }
}