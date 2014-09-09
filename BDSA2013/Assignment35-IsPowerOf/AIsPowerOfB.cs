using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment35_IsPowerOf
{
    class AIsPowerOfB
    {

        static bool IsPowerOf(int a, int b)
        {
            if (a == 1 || b == 1)
                return true;

            if (a % b > 0)
                return false;

            a = a / b;

            return IsPowerOf(a, b);
        }

        static void Main(string[] args)
        {

            if (args.Length == 2)
            {
                Console.WriteLine("Is {0} a power of {1}:", args[0], args[1]);

                int a = 0, b = 0;
                try
                {
                    a = Convert.ToInt32(args[0]);
                    b = Convert.ToInt32(args[1]);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }

                Console.Out.WriteLine(IsPowerOf(a, b));
            }
            else
            {
                Console.WriteLine("Not enough arguments / or to many");
            }
            Console.ReadKey();
        }
    } 
}
