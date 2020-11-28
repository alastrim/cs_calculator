using System;
using System.Collections.Generic;
using System.Text;

namespace cs_calculator
{
    class SortingStation
    {
    }

    class Program
    {
        static void Main (string[] args)
        {
            string s = "(-3 + 5) * 2 + 3 * 7";
            var queue = InputParser.Parse (s);

            if (queue == null)
            {
                Console.WriteLine ("Could not parse input");
                return;
            }

            Console.WriteLine ("Parsed input:");
            foreach (var token in queue)
                Console.WriteLine ($"  {token}");
        }
    }
}
