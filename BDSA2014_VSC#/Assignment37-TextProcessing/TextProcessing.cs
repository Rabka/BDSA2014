using System;
using System.Text.RegularExpressions;

namespace Assignment37_TextProcessing
{
    /// <summary>
    /// Class for searching in text and displaying the result with highlighting.
    /// </summary>
    public class TextProcessing
    {
        /// <summary>
        /// A method that gives a keyword finds all instances of given keyword and highlight them
        /// (and find all urls/dates and color them) in a text, the method writes in the console.
        /// </summary>
        /// <param name="args"> A keyword to search for in the text </param>
        public static void Main(string[] args)
        {
            string input;
            if (args.Length > 0)
                input = args[0];
            else
            {
                input = "a*+a*+*t";
                Console.WriteLine("Default input: a*+a*+*t");
                Console.WriteLine("");
            }

            var content = TextFileReader.ReadFile("C:/Users/stin7054/Documents/GitHub/BDSA2014/BDSA2013/Assignment37-TextProcessing/TestFile.txt");

            // Makes * work in given keyword. OPTIONAL: can take multiple *'s
            input = input.Replace("*", "\\S*");

            // Makes + work in given keyword. OPTIONAL: can take multiple +'seven together with *'s
            var s = input.Split('+');
            input = "";
            for(int k = 0; k < s.Length - 1; k++)
                input += "\\b" + s[k] + "\\b ";
            input += "\\b" + s[s.Length - 1] + "\\b";

            // Regex for finding urls
            const string url = "http\\S*\\b";

            // Regex for finding dates
            const string date = "\\b\\d\\d[ ]?\\w\\w\\w[ ]?\\d\\d\\d\\d\\b";

            var lines = Regex.Split(content, string.Format(@"({0}|{1}|{2})", input, url, date));
            foreach(string line in lines)
            {
                if (Regex.IsMatch(line,string.Format(@"{0}", input)))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(line);
                    Console.ResetColor();
                    continue;
                }

                if (line.StartsWith("http://"))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(line);
                    Console.ResetColor();
                    continue;
                }

                if (Regex.IsMatch(line, string.Format(@"{0}", date)))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(line);
                    Console.ResetColor();
                    continue;
                }

                Console.Write(line);
            }

            Console.ReadLine();
        }
    }
}
