using System;
using System.Collections.Generic;
using System.Text;

namespace cs_calculator
{
    class SortingStation
    {
        Queue<Token> m_input_queue;
        Queue<Token> m_output_queue;
        Stack<Token> m_memory_stack;

        int OperatorPrecedence (OperatorType op)
        {
            switch (op)
            {
                case OperatorType.Add:
                case OperatorType.Subtract:
                    return 1;
                case OperatorType.Multiply:
                case OperatorType.Divide:
                    return 2;
                default:
                    Console.WriteLine ("Something went horribly wrong!");
                    return -1;
            }
        }

        SortingStation (Queue<Token> input_queue)
        {
            m_input_queue = input_queue;
            m_output_queue = new Queue<Token> ();
            m_memory_stack = new Stack<Token> ();
        }

        void Sort ()
        {
            foreach (Token token in m_input_queue)
            {
                if (token is TokenNumber)
                {
                    m_output_queue.Enqueue (token);
                    continue;
                }

                if (token is TokenOperator @op1)
                {
                    while (m_memory_stack.Count > 0 && m_memory_stack.Peek () is TokenOperator @op2 && OperatorPrecedence (op2.Type) >= OperatorPrecedence (op1.Type))
                        m_output_queue.Enqueue (m_memory_stack.Pop ());
                    m_memory_stack.Push (token);

                    continue;
                }

                if (token is TokenBracket @tbracket)
                {
                    if (tbracket.IsOpening)
                    {
                        m_memory_stack.Push (token);
                    }
                    else
                    {
                        while (m_memory_stack.Count > 0 && !(m_memory_stack.Peek () is TokenBracket) || !((TokenBracket)m_memory_stack.Peek ()).IsOpening)
                            m_output_queue.Enqueue (m_memory_stack.Pop ());
                        m_memory_stack.Pop ();
                    }

                    continue;
                }

                Console.WriteLine ("Something went horribly wrong!");
            }

            while (m_memory_stack.Count > 0)
                m_output_queue.Enqueue (m_memory_stack.Pop ());
        }

        public static void SortAndDie (Queue<Token> input)
        {
            SortingStation st = new SortingStation (input);
            st.Sort ();
            input.Clear ();
            foreach (Token token in st.m_output_queue)
                input.Enqueue (token);
        }
    }
}
