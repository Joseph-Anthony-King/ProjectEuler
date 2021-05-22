using System;
using System.Collections.Generic;

namespace Problem17
{
    /* If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.

       If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?           

       NOTE: Do not count spaces or hyphens.For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen)
       contains 20 letters.The use of "and" when writing out numbers is in compliance with British usage. */
    class Program
    {
        static void Main(string[] args)
        {
            // List of ints for processing
            var numericalDigits = new List<int>();
            // List to hold string representations of the digits
            var numberStrings = new List<string>();
            // Obtain the dictionary of digit to word translations
            var wordDictionary = GetDictionary();
            // The final result will go here
            double result = 0;


            // Populate the int list
            for (var i = 1; i <= 1000; i++)
            {
                numericalDigits.Add(i);
            }

            // Translate the int list into words
            foreach (var digit in numericalDigits)
            {
                var digitString = digit.ToString();
                var digitArray = digitString.ToCharArray();

                var firstDigitCharArrayMember = Convert.ToInt32(digitArray[0].ToString());

                if (digit == 1000)
                {
                    numberStrings.Add(
                        string.Format("{0} thousand", 
                        wordDictionary[firstDigitCharArrayMember]));
                }
                else if (digit >= 100)
                {
                    var tenthValue = Convert.ToInt32(digitArray[1].ToString()) * 10;
                    var onethValue = digit - (firstDigitCharArrayMember * 100) - tenthValue;

                    if (tenthValue != 0 && onethValue != 0)
                    {
                        if (tenthValue != 10)
                        {
                            numberStrings.Add(string.Format("{0} hundred and {1}-{2}",
                                wordDictionary[firstDigitCharArrayMember],
                                wordDictionary[tenthValue],
                                wordDictionary[onethValue]));
                        }
                        else // if the value is a hundred aught value...
                        {
                            var aughtValue = tenthValue + onethValue;

                            numberStrings.Add(string.Format("{0} hundred and {1}",
                                wordDictionary[firstDigitCharArrayMember],
                                wordDictionary[aughtValue]));
                        }
                    }
                    else if (tenthValue != 0 && onethValue == 0)
                    {
                        numberStrings.Add(string.Format("{0} hundred and {1}",
                            wordDictionary[firstDigitCharArrayMember],
                            wordDictionary[tenthValue]));
                    }
                    else if (tenthValue == 0 && onethValue != 0)
                    {
                        numberStrings.Add(string.Format("{0} hundred and {1}",
                            wordDictionary[firstDigitCharArrayMember],
                            wordDictionary[onethValue]));
                    }
                    else
                    {
                        numberStrings.Add(
                            string.Format("{0} hundred", 
                            wordDictionary[firstDigitCharArrayMember]));
                    }

                }
                else if (digit >= 20)
                {
                    var onethValue = digit - (firstDigitCharArrayMember * 10);

                    if (onethValue != 0)
                    {
                        numberStrings.Add(string.Format("{0}-{1}", 
                            wordDictionary[firstDigitCharArrayMember * 10], 
                            wordDictionary[onethValue]));
                    }
                    else
                    {
                        numberStrings.Add(wordDictionary[firstDigitCharArrayMember * 10]);
                    }
                }
                else
                {
                    numberStrings.Add(wordDictionary[digit]);
                }
            }

            // Now calculate the number of alpha characters
            foreach (var numberString in numberStrings)
            {
                var numberStringChars = numberString.ToCharArray();

                foreach (var c in numberStringChars)
                {
                    if (Char.IsLetter(c))
                    {
                        result++;
                    }
                }
            }

            Console.Write("Problem 17: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }

        public static Dictionary<int, string> GetDictionary()
        {
            var result = new Dictionary<int, string>();

            result.Add(1, "one");
            result.Add(2, "two");
            result.Add(3, "three");
            result.Add(4, "four");
            result.Add(5, "five");
            result.Add(6, "six");
            result.Add(7, "seven");
            result.Add(8, "eight");
            result.Add(9, "nine");
            result.Add(10, "ten");
            result.Add(11, "eleven");
            result.Add(12, "twelve");
            result.Add(13, "thirteen");
            result.Add(14, "fourteen");
            result.Add(15, "fifteen");
            result.Add(16, "sixteen");
            result.Add(17, "seventeen");
            result.Add(18, "eighteen");
            result.Add(19, "nineteen");
            result.Add(20, "twenty");
            result.Add(30, "thirty");
            result.Add(40, "forty");
            result.Add(50, "fifty");
            result.Add(60, "sixty");
            result.Add(70, "seventy");
            result.Add(80, "eighty");
            result.Add(90, "ninety");

            return result;
        }
    }
}
