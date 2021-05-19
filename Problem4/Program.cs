using System;

namespace Problem4
{
    class Program
    {
        // A palindromic number reads the same both ways. The largest palindrome made from the product of two 2 - digit numbers is 9009 = 91 × 99.
        // Find the largest palindrome made from the product of two 3 - digit numbers.
        static void Main(string[] args)
        {
            int digitOne, digitTwo, result = 0;

            for (var i = 0; i < 1000; i++)
            {
                // Increment through each possible digit one less than 3 digits
                digitOne = i;

                for (var j = 0; j < 1000; j++)
                {
                    // Increment digit two
                    digitTwo = j;

                    // Obtain the product
                    var product = digitOne * digitTwo;

                    // Convert product to string
                    var productString = Convert.ToString(product);

                    // Obtain reversed version of string
                    char[] charArray = productString.ToCharArray();
                    Array.Reverse(charArray);
                    var productStringReversed = new string(charArray);

                    // Is this a palindrome?
                    if (productString.Equals(productStringReversed))
                    {
                        // Is the result less than the product?  If so reassign the result
                        if (result < product)
                        {
                            result = product;
                        }
                    }
                }
            }

            Console.Write("Problem 4: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }
    }
}
