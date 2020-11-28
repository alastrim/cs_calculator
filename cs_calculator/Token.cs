using System;
using System.Collections.Generic;
using System.Text;

namespace cs_calculator
{
    enum OperatorType
    {
        UnaryPlus,
        UnaryMinus,
        Add,
        Subtract,
        Multiply,
        Divide
    };

    abstract class Token : Object
    {
    }

    class TokenOperator : Token
    {
        public OperatorType Type { get; }

        public TokenOperator (char ch, bool unary = false)
        {
            switch (ch)
            {
                case '+':
                    Type = unary ? OperatorType.UnaryPlus : OperatorType.Add;
                    break;
                case '-':
                    Type = unary ? OperatorType.UnaryMinus : OperatorType.Subtract;
                    break;
                case '*':
                    Type = OperatorType.Multiply;
                    break;
                case '/':
                    Type = OperatorType.Divide;
                    break;
            }
        }

        public override string ToString ()
        {
            return Type.ToString ();
        }
    }

    class TokenNumber : Token
    {
        public double Value { get; }

        public TokenNumber (double value)
        {
            Value = value;
        }

        public TokenNumber (string value)
        {
            Value = Convert.ToDouble (value);
        }

        public override string ToString ()
        {
            return Value.ToString ();
        }
    }

    class TokenBracket : Token
    {
        public bool IsOpening { get; }

        public TokenBracket (bool isOpening)
        {
            IsOpening = isOpening;
        }

        public override string ToString ()
        {
            return IsOpening ? "(" : ")";
        }
    }
}
