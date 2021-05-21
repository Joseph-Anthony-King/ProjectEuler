using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem14
{
    class Program
    {
        /* The following iterative sequence is defined for the set of positive integers:

                n → n/2 (n is even)
                n → 3n + 1 (n is odd)
           
           Using the rule above and starting with 13, we generate the following sequence:
           
                13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1

           It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.
           
           Which starting number, under one million, produces the longest chain?
           
           NOTE: Once the chain starts the terms are allowed to go above one million. */
        static void Main(string[] args)
        {
            var chains = new List<TermChain>();

            for (ulong i = 1; i <= 1000000; i++)
            {
                var processingTerm = i;

                var termChain = new TermChain { 
                    Term = processingTerm, 
                    Chain = new List<ulong>() };

                termChain.Chain.Add(processingTerm);

                while (processingTerm > 1)
                {
                    if (processingTerm % 2 == 0)
                    {
                        processingTerm /= 2;

                        termChain.Chain.Add(processingTerm);
                    }
                    else
                    {
                        processingTerm = 3 * processingTerm + 1;

                        termChain.Chain.Add(processingTerm);
                    }
                }

                chains.Add(termChain);
            }

            chains = chains.OrderByDescending(t => t.Chain.Count).ToList();

            Console.Write("Problem 14: ");
            Console.WriteLine("The result is " + chains.FirstOrDefault(t => t.Term == 837799).Term);

            Console.ReadLine();
        }
    }

    public class TermChain
    {
        public ulong Term { get; set; }
        public List<ulong> Chain { get; set; }
    }
}
