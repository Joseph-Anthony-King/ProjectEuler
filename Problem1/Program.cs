using System;
using System.Collections.Generic;

namespace Problem01
{
    // If we list all the natural numbers below 10 that are multiples of 3 or 5, we get 3, 5, 6 and 9. The sum of these multiples is 23.
    // Find the sum of all the multiples of 3 or 5 below 1000.
    class Program
    {
        static void Main(string[] args)
        {
            var multiples = new List<int>();
            var result = 0;

            for (var i = 1; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    multiples.Add(i);
                }
            }

            foreach (var multiple in multiples)
            {
                result += multiple;
            }

            Console.Write("Problem 1: ");
            Console.WriteLine("The final result is " + result);
            Console.ReadLine();
        }
    }
}
