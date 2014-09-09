using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment36_ReversePolishCalculator
{
    public class ReversePolishCalculator
    {
        static void Main(string[] args)
        {
            var RPC = new ReversePolishCalculator();

            while (true)
            {
                String s = Console.ReadLine();
                if(s == "quit")
                    break;
                Console.WriteLine("= " + RPC.Calculate(s));
            }
        }

        /// <summary>
        /// Returns a double value representing the result of 
        /// the reverse polish mathematical notation param input.
        /// </summary>
        /// <param name="input">reverse polish mathematical notation (string)</param>
        /// <returns>result of calculation (double)</returns>
        public double Calculate(String input)
        {
            if (input == "" || input == null)
                return 0d;

            int n = 2;
            Stack<double> stack = new Stack<double>();
            foreach (string piece in input.Split(' '))
            {
                int digit = 0;
                if (int.TryParse(piece, out digit))
                {
                    //is value
                    stack.Push(digit);
                }
                else
                {
                    //is operator
                    if (stack.Count < n)
                        throw new Exception("The user has not input sufficient values in the expression.");

                    double result = stack.Pop();
                    switch (piece)
                    {
                        case "+":
                            stack.Push(stack.Pop() + result);
                            break;
                        case "-":
                            stack.Push(stack.Pop() - result);
                            break;
                        case "/":
                            stack.Push(stack.Pop() / result);
                            break;
                        case "*":
                            stack.Push(stack.Pop() * result);
                            break;
                        case "^":
                            stack.Push(Math.Pow(stack.Pop(), result));
                            break;
                        default:
                            throw new Exception("The user has not input sufficient values in the expression.");
                            break;
                    }

                }

            }
            if (stack.Count > 1)
                throw new Exception("The user input has too many values.");
            return stack.Pop();
        }

        /// <summary>
        /// Returns a double value representing the result of 
        /// the infix mathematical notation param input.
        /// </summary>
        /// <param name="input">infix notation (string)</param>
        /// <returns>result of calculation (double)</returns>
        public double InfixCalculate(String input)
        {
            if (input == "" || input == null)
                return 0d;

            Stack<char> operators = new Stack<char>();
            Queue<char> output = new Queue<char>();
            foreach (string piece in input.Split(' '))
            {
                int digit = 0;
                if (int.TryParse(piece, out digit))
                {
                    //is value
                    output.Enqueue(piece[0]);
                }
                else
                {
                    if (piece.Length > 1)
                        throw new Exception("misformet input.");
                    //is operator
                    switch (piece)
                    {
                        case ")":
                            while (operators.Peek() != '(')
                            {
                                output.Enqueue(operators.Pop());
                                if (operators.Count == 0)
                                    throw new Exception("operator not supported, misformed expression!");
                            }
                            operators.Pop();
                            break;
                        case "(":
                            operators.Push(piece[0]);
                            break;
                        default:
                            while (operators.Count > 0)
                            {
                                char o = operators.Peek();
                                if (o == '(' || o == ')' || o == '^' || getOrderofoperations(piece[0]) > getOrderofoperations(o))
                                    break;
                                output.Enqueue(operators.Pop());
                            }
                            operators.Push(piece[0]);
                            break;
                    }
                }
            }
            foreach (char o in operators)
            {
                if (o == '(' || o == ')')
                    throw new Exception("operator not supported, misformed expression!");
                output.Enqueue(o);
            }

            return Calculate(string.Join(" ", output));
        }

        /// <summary>
        /// Returns a number describing the order of operations.
        /// A higher value means it has higher priority,
        /// for example: multiplication has higher order than
        /// subtraction.
        /// </summary>
        /// <param name="input">operator (char)</param>
        /// <returns>Order of operations (int)</returns>
        private static int getOrderofoperations(char input)
        {
            switch (input)
            {
                case '+':
                    return 0;
                    break;
                case '-':
                    return 0;
                    break;
                case '*':
                    return 1;
                    break;
                case '/':
                    return 1;
                    break;
                case '^':
                    return 2;
                    break;
                case '(':
                    return 3;
                    break;
                case ')':
                    return 3;
                    break;
                default:
                    throw new Exception("operator not supported, misformed expression!");
                    break;
            }
        }
    }
}
