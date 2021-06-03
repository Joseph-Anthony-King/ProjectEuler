using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Problem22
{
    /* Using names.txt(right click and 'Save Link/Target As...'), a 46K text file containing over five-thousand first names,
     * begin by sorting it into alphabetical order.Then working out the alphabetical value for each name, multiply this value 
     * by its alphabetical position in the list to obtain a name score.
     *
     * For example, when the list is sorted into alphabetical order, COLIN, which is worth 3 + 15 + 12 + 9 + 14 = 53, is the 
     * 938th name in the list. So, COLIN would obtain a score of 938 × 53 = 49714.
     *
     * What is the total of all the name scores in the file? */
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0.0;

            var file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/names.txt";

            Dictionary<char, int> _letterValues = new Dictionary<char, int> {
                { 'A', 1 },
                { 'B', 2 },
                { 'C', 3 },
                { 'D', 4 },
                { 'E', 5 },
                { 'F', 6 },
                { 'G', 7 },
                { 'H', 8 },
                { 'I', 9 },
                { 'J', 10 },
                { 'K', 11 },
                { 'L', 12 },
                { 'M', 13 },
                { 'N', 14 },
                { 'O', 15 },
                { 'P', 16 },
                { 'Q', 17 },
                { 'R', 18 },
                { 'S', 19 },
                { 'T', 20 },
                { 'U', 21 },
                { 'V', 22 },
                { 'W', 23 },
                { 'X', 24 },
                { 'Y', 25 },
                { 'Z', 26 }
            };

            try
            {
                var names = ReadAndAlphabetizeFile(file);

                for (var i = 0; i < names.Count; i++)
                {
                    result += SumOfIndexAndLetterValues(
                        names[i],
                        i,
                        _letterValues);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Write("Problem 21: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }

        private static double SumOfIndexAndLetterValues(
            string name, 
            int index, 
            Dictionary<char, int> letterValues)
        {
            double result = 0;

            var nameCharArray = name.ToCharArray();

            foreach (var n in nameCharArray)
            {
                result += letterValues[n];
            }

            return result * (index + 1);
        }

        private static List<string> ReadAndAlphabetizeFile(string filename)
        {
            List<string> result = new List<string>();

            string contents;

            using (StreamReader r = new StreamReader(filename))
            {

                while ((contents = r.ReadLine()) != null)
                {
                    result = contents.Split(',').ToList();
                }
            }

            for (var i = 0; i < result.Count; i++)
            {
                result[i] = result[i].Replace("\"", "");
            }

            return result.OrderBy(r => r).ToList();
        }
    }
}
