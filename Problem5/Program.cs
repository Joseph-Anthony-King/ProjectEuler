using System;

namespace Problem5
{
    class Program
    {
        // 2520 is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
        // What is the smallest positive number that is evenly divisible by all of the numbers from 1 to 20?
        static void Main(string[] args)
        {
            var continueLoop = true;
            var result = 0;

            do
            {
                result++;
                bool remainderFound = false;

                for (var i = 1; i <= 20; i++)
                {
                    if (result % i != 0)
                    {
                        remainderFound = true;
                    }
                }

                if (!remainderFound)
                {
                    continueLoop = false;
                }

            } while (continueLoop);

            Console.Write("Problem 4: ");
            Console.WriteLine("The final result is " + result);
            Console.ReadLine();
        }
    }
}
