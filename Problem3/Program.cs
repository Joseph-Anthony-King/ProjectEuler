using System;

namespace Problem03
{
    class Program
    {
        // The prime factors of 13195 are 5, 7, 13 and 29.
        // What is the largest prime factor of the number 600851475143?
        static void Main(string[] args)
        {
            double number = 600851475143, factor = 2, result = 0;
            //var factors = new List<double>();

            while (number > 1)
            {
                if (number % factor == 0)
                {
                    result = factor;
                    //factors.Add(factor);
                    number /= factor;
                    while (number % factor == 0)
                    {
                        number /= factor;
                        //factors.Add(factor);
                    }
                }

                factor++;
            }

            Console.Write("Problem 3: ");
            Console.WriteLine("The result is " + result);

            /*Console.Write("Factors: ");

            var index = 0;

            foreach (var f in factors)
            {
                if (index < factors.Count - 1)
                {
                    Console.Write(f + ", ");
                }
                else
                {
                    Console.Write(f);
                }

                index++;
            }*/

            Console.ReadLine();
        }
    }
}
