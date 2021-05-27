using System;
using System.IO;

namespace Problem18
{
    /* By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.
    
       3
       7 4
       2 4 6
       8 5 9 3
       
       That is, 3 + 7 + 4 + 9 = 23.
       
       Find the maximum total from top to bottom of the triangle below:
       
       75
       95 64
       17 47 82
       18 35 87 10
       20 04 82 47 65
       19 01 23 75 03 34
       88 02 77 73 07 63 67
       99 65 04 28 06 16 70 92
       41 41 26 56 83 40 80 70 33
       41 48 72 33 47 32 37 16 94 29
       53 71 44 65 25 43 91 52 97 51 14
       70 11 33 28 77 73 17 78 39 68 17 57
       91 71 52 38 17 14 91 43 58 50 27 29 48
       63 66 04 68 89 53 67 30 73 16 69 87 40 31
       04 62 98 27 23 09 70 98 73 93 38 53 60 04 23
       
       NOTE: As there are only 16384 routes, it is possible to solve this problem by trying every route.However, Problem 67, is the same challenge with a triangle containing one-hundred rows; it cannot be solved by brute force, and requires a clever method! ;o)

       Used the following blog to solve this:
    
       https://www.mathblog.dk/project-euler-18/#:~:text=Project%20Euler%2018%3A%20Maximum%20Sum%20from%20Top%20to%20Bottom%20of%20the%20Triangle&text=By%20starting%20at%20the%20top,top%20to%20bottom%20is%2023.&text=That%20is%2C%203%20%2B%207%20%2B%204%20%2B%209%20%3D%2023. */
    class Program
    {
        static void Main(string[] args)
        {
            var file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/input.txt";

            try
            {
                var input = ReadFile(file);

                var limit = (int)Math.Sqrt(input.Length);

                string method;

                int result;

                bool useBruteForceMethod = true;

                if (useBruteForceMethod)
                {
                    result = BruteForceMethod(input, limit, out method);
                }
                else
                {
                    result = DynamicProgrammingMethod(input, limit, out method);
                }

                Console.Write("Problem 18: ");
                Console.WriteLine("The result is " + result);
                Console.WriteLine("Calculated using the " + method);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

        private static int BruteForceMethod(int[,] input, int limit, out string method)
        {
            method = "Brute Force Method";

            int posSolutions = (int)Math.Pow(2, input.GetLength(0) - 1);

            int tempSum, index, result = 0;

            for (int i = 0; i <= posSolutions; i++)
            {
                tempSum = input[0, 0];

                index = 0;

                for (int j = 0; j < limit - 1; j++)
                {
                    index = index + (i >> j & 1);
                    tempSum += input[j + 1, index];
                }
                if (tempSum > result)
                {
                    result = tempSum;
                }
            }

            return result;
        }

        private static int DynamicProgrammingMethod(int[,] input, int limit, out string method)
        {
            method = "Dynamic Programming Method";

            int result;

            for (int i = limit - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    input[i, j] += Math.Max(input[i + 1, j], input[i + 1, j + 1]);
                }
            }

            result = input[0, 0];

            return result;
        }

        private static int[,] ReadFile(string filename)
        {
            string line;

            string[] linePieces;

            int lines = 0;

            int[,] result;

            using (StreamReader r = new StreamReader(filename))
            {
                while ((_ = r.ReadLine()) != null)
                {
                    lines++;
                }

                result = new int[lines, lines];

                r.BaseStream.Seek(0, SeekOrigin.Begin);

                int j = 0;

                while ((line = r.ReadLine()) != null)
                {
                    linePieces = line.Split(' ');

                    for (int i = 0; i < linePieces.Length; i++)
                    {
                        try
                        {
                            result[j, i] = int.Parse(linePieces[i]);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    j++;
                }
            }

            return result;
        }
    }
}
