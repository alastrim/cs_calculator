using System;
using System.Collections.Generic;
using System.Text;

namespace cs_calculator
{
    class Calculator
    {
        Queue<Token> m_input_queue;
        Stack<Token> m_memory_stack;

        Calculator (Queue<Token> input_queue)
        {
            m_input_queue = input_queue;
            m_memory_stack = new Stack<Token> ();
        }

        void Calculate ()
        {
            foreach (Token token in m_input_queue)
            {
                if (token is TokenNumber)
                {
                    m_memory_stack.Push (token);
                    continue;
                }

                if (token is TokenOperator @toperator)
                {
                    double b = ((TokenNumber)m_memory_stack.Pop ()).Value;
                    double a = ((TokenNumber)m_memory_stack.Pop ()).Value;
                    double c = 0;

                    switch (toperator.Type)
                    {
                        case OperatorType.Add:
                            c = a + b; break;
                        case OperatorType.Subtract:
                            c = a - b; break;
                        case OperatorType.Multiply:
                            c = a * b; break;
                        case OperatorType.Divide:
                            c = a / b; break;
                        default:
                            Console.WriteLine ("Something went horribly wrong!");
                            break;
                    }

                    m_memory_stack.Push (new TokenNumber (c));
                }
            }
        }

        public static double CalculateAndDie (Queue<Token> input)
        {
            Calculator calc = new Calculator (input);
            calc.Calculate ();
            if (calc.m_memory_stack.Count > 1)
                Console.WriteLine ("Something went horribly wrong!");
            return ((TokenNumber)calc.m_memory_stack.Pop ()).Value;
        }
    }
}
