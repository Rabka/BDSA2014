using System;
using System.Collections.Generic;

namespace Assignment37_ReversePolishCalculator
{
    /// <summary>
    /// A Reversed Polish calculator ther takes input from and writes in the console.
    /// </summary>
    public class ReversePolishCalculator
    {
        Dictionary<string, IOperation> dictionary = new Dictionary<string, IOperation>();

        /// <summary>
        /// Starts the program and asks if you like to use infix notation as input for as lond as the program is running.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("[Polish calculator]");
            Console.WriteLine("Would you like to use infix notation? (YES for yes and NO for reverse polish notation)");
            string choice = Console.ReadLine();
            double result = 0.0;
            Console.WriteLine("Write expression to reversePolishNotation:");
            var rpc = new ReversePolishCalculator();
            rpc.InitOperations();
            if (choice.ToLower() == "yes")
            {
                result = rpc.InfixCalculation(Console.ReadLine());
            }
            else
            {
                result = rpc.Calculation(Console.ReadLine());
            }
            Console.WriteLine("Result is: " + result);
            Console.ReadLine();

        }

        /// <summary>
        /// Prepares all supported operators.
        /// </summary>
        public void InitOperations()
        {
            dictionary.Add("^", new BinaryOperation((x, y) => Math.Pow(x, y)));
            dictionary.Add("/", new BinaryOperation((x, y) => x / y));
            dictionary.Add("+", new BinaryOperation((x, y) => x + y));
            dictionary.Add("-", new BinaryOperation((x, y) => x - y));
            dictionary.Add("*", new BinaryOperation((x, y) => x * y));
            dictionary.Add("sqrt", new UnaryOperation(x => Math.Sqrt(x)));
            dictionary.Add("abs", new UnaryOperation(x => Math.Abs(x)));
        }

        /// <summary>
        /// Returns a double value representing the result of 
        /// the reverse polish mathematical notation param input.
        /// </summary>
        /// <param name="input">reverse polish mathematical notation (string)</param>
        /// <returns>result of the calculation (double)</returns>
        public double Calculation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0d;

            int n = 1;
            Stack<double> stack = new Stack<double>();
            foreach (string piece in input.Split(' '))
            {
                double digit = 0;
                if (Double.TryParse(piece.Replace(".", ","), out digit))
                {
                    //is value
                    stack.Push(digit);
                }
                else
                {

                    double result = stack.Pop();
                    if (dictionary.ContainsKey(piece))
                    {
                        IOperation operation = dictionary[piece];

                        //is operator
                        if (stack.Count < n && operation is BinaryOperation)
                        {
                            throw new Exception("The user has not input sufficient values in the expression.");
                        }
                        if (operation is UnaryOperation)
                            stack.Push(operation.Execute(result));
                        if (operation is BinaryOperation)
                            stack.Push(operation.Execute(stack.Pop(), result));
                    }
                    else
                    {
                        throw new Exception("Expression has an unsupported operator:" + piece);
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
        /// <returns>result of the calculation (double)</returns>
        public double InfixCalculation(string input)
        {
            if (string.IsNullOrEmpty(input))
                return 0d;

            Stack<string> operators = new Stack<string>();
            Queue<string> output = new Queue<string>();
            foreach (string piece in input.Split(new string[]{" "},StringSplitOptions.RemoveEmptyEntries))
            {
                int digit = 0;
                if (int.TryParse(piece, out digit))
                {
                    //is value
                    output.Enqueue(piece);
                }
                else
                {
                    //is operator
                    switch (piece)
                    {
                        case ")":
                            while (operators.Peek() != "(")
                            {
                                output.Enqueue(operators.Pop());
                                if (operators.Count == 0)
                                    throw new Exception("operator not supported, misformed expression!");
                            }
                            operators.Pop();
                            break;
                        case "(":
                            operators.Push(piece);
                            break;
                        default:
                            while (operators.Count > 0)
                            {
                                string o = operators.Peek();
                                if (o == "(" || o == ")" || o == "^" || GetOrderofoperations(piece) > GetOrderofoperations(o))
                                    break;
                                output.Enqueue(operators.Pop());
                            }
                            operators.Push(piece);
                            break;
                    }
                }
            }
            foreach (string o in operators)
            {
                if (o == "(" || o == ")")
                    throw new Exception("operator not supported, misformed expression!");
                output.Enqueue(o);
            }

            return Calculation(string.Join(" ", output));
        }

        /// <summary>
        /// Returns a number describing the order of operations.
        /// A higher value means it has higher priority,
        /// for example: multiplication has higher order than
        /// subtraction.
        /// </summary>
        /// <param name="input">operator (char)</param>
        /// <returns>Order of operations (int)</returns>
        public int GetOrderofoperations(string input)
        {
            switch (input)
            {
                case "+":
                    return 0;
                case "-":
                    return 0;
                case "*":
                    return 1;
                case "/":
                    return 1;
                case "^":
                    return 2;
                case "(":
                    return 3;
                case ")":
                    return 3;
                default:
                    return 0;
            }
        }
    }

    /// <summary>
    /// Implements Ioperation and allows BinaryOperations given
    /// a lambda expression as input.
    /// <param name="input">Func<double, double, double> input</param>
    /// </summary>
    public class BinaryOperation : IOperation
    {

        Func<double, double, double> action = null;
        public BinaryOperation(Func<double, double, double> instruction)
        {
            action = instruction;
        }

        public double Execute(double arg1, params double[] argn)
        {
            return action(arg1, argn[0]);
        }

    }

    /// <summary>
    /// Implements Ioperation and allows UnaryOperation given
    /// a lambda expression as input.
    /// <param name="input">Func<double,double> instruction</param>
    /// </summary>
    public class UnaryOperation : IOperation
    {
        Func<double, double> action = null;
        public UnaryOperation(Func<double, double> instruction)
        {
            action = instruction;
        }
        public double Execute(double arg1, params double[] argn)
        {
            return action(arg1);
        }

    }
}
