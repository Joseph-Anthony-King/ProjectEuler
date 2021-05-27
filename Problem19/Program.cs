using System;

namespace Problem19
{
    /* You are given the following information, but you may prefer to do some research for yourself.
    
       1 Jan 1900 was a Monday.
       Thirty days has September,
       April, June and November.
       All the rest have thirty-one,
       Saving February alone,
       Which has twenty-eight, rain or shine.
       And on leap years, twenty-nine.

       A leap year occurs on any year evenly divisible by 4, but not on a century unless it is divisible by 400.
       How many Sundays fell on the first of the month during the twentieth century (1 Jan 1901 to 31 Dec 2000)? */
    class Program
    {
        static void Main(string[] args)
        {
            var currentDate = DateTime.Parse("01/01/1901");
            var finalDate = DateTime.Parse("12/31/2000");
            var result = 0;

            do
            {
                if (currentDate.Day == 1 && currentDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    result++;
                }

                currentDate = currentDate.AddDays(1);

            } while (currentDate <= finalDate);

            Console.Write("Problem 19: ");
            Console.WriteLine("The result is " + result);
            Console.ReadLine();
        }
    }
}
