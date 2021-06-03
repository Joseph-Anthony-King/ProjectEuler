using System;

namespace Problem06
{
    /* The sum of the squares of the first ten natural numbers is,
     *
     *      1² + 2² + ... + 10² = 385
     *
     * The square of the sum of the first ten natural numbers is,
     *
     *      (1 + 2 + ... + 10)² = 55² = 3025
     *
     * Hence the difference between the sum of the squares of the first ten natural numbers and the square of the sum is.
     *
     *      3025 - 385 = 2640
     *
     * Find the difference between the sum of the squares of the first one hundred natural numbers and the square of the sum.*/
    class Program
    {
        static void Main(string[] args)
        {
            double sumOfTheSquares = 0, squareOfTheSums = 0, result;

            for (var i = 1; i <= 100; i++)
            {
                sumOfTheSquares += Math.Pow(i, 2);
                squareOfTheSums += i;
            }

            squareOfTheSums = Math.Pow(squareOfTheSums, 2);

            result = squareOfTheSums - sumOfTheSquares;

            Console.Write("Problem 6: ");
            Console.WriteLine("The final result is " + result);
            Console.ReadLine();
        }
    }
}
