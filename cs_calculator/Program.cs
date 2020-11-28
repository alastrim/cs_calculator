using System;
using System.Collections.Generic;
using System.Text;

namespace cs_calculator
{
    class Program
    {
        public static void CalculateString (string s, bool debug_print = false)
        {
            var queue = StaticParser.Parse (s);

            Console.WriteLine (String.Format ("Input: {0}", s));

            if (queue == null)
            {
                Console.WriteLine ("Could not parse input");
                return;
            }

            if (debug_print)
            {
                Console.WriteLine ("Parsed input:");
                foreach (Token token in queue)
                    Console.WriteLine (String.Format ("{0}", token.ToString ()));
            }

            SortingStation.SortAndDie (queue);

            if (debug_print)
            {
                Console.WriteLine ("Sorted input:");
                foreach (Token token in queue)
                    Console.WriteLine (String.Format ("{0}", token.ToString ()));
            }

            double result = Calculator.CalculateAndDie (queue);

            Console.WriteLine (String.Format ("Result: {0}\n", result));
        }

        static void Main (string[] args)
        {
            CalculateString ("(-3 + 5) * 2 + 3 * 7");
            CalculateString ("(11 - 12 + 5 * 3 - 2 / 2) / 3");
            CalculateString ("(-3 + 5) * 2 + 3 * 7");
            CalculateString ("(-3 + 5) * 2 + 3 * 7");
            CalculateString ("(-3 + 5) * 2 + 3 * 7");
        }
    }
}
