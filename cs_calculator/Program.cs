using System;
using System.Collections.Generic;
using System.Text;

namespace cs_calculator
{
    class Program
    {
        static void Main (string[] args)
        {
            string s = "(-3 + 5) * 2 + 3 * 7";
            var queue = StaticParser.Parse (s);

            Console.WriteLine (String.Format ("Input: {0}", s));

            if (queue == null)
            {
                Console.WriteLine ("Could not parse input");
                return;
            }

            //Console.WriteLine ("\nParsed input:");
            //foreach (var token in queue)
            //    Console.WriteLine ($"  {token}");

            SortingStation.SortAndDie (queue);
            Console.WriteLine ("\nSorted input:");
            foreach (var token in queue)
                Console.WriteLine ($"  {token}");
        }
    }
}
