using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace col._2._1
{
    class Program
    {
      
    public class InfixToPrefixConverter
    {
        private static readonly char[] Oper = { '+', '-', '*', '/' };

        public static string Convert(string infixExpression)
        {
            string[] znaki = infixExpression.Split(' ');

            Stack<string> output = new Stack<string>();
            Stack<string> oper = new Stack<string>();

            foreach (string znak in znaki.Reverse())
            {
                if (Oper.Contains(znak[0]))
                {
                    while (oper.Count > 0 && GetPrecedence(znak) >= GetPrecedence(oper.Peek()))
                    {
                        output.Push(oper.Pop() + " " + output.Pop() + " " + output.Pop());
                    }

                    oper.Push(znak);
                }
                else
                {
                    output.Push(znak);
                }
            }

            while (oper.Count > 0)
            {
                output.Push(oper.Pop() + " " + output.Pop() + " " + output.Pop());
            }

            return output.Pop();
        }

        private static int GetPrecedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                default:
                    return 0;
            }
        }
    }
        public static void Main()
        {
            string infix = "2 + 8 * 6 - 7";

            string prefix = InfixToPrefixConverter.Convert(infix);

            Console.WriteLine("инфиксное выражение: " + infix);
            Console.WriteLine("Префиксное выражение: " + prefix);
            Console.ReadKey();
        }
    }

}

