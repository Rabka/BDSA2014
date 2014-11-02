using System;
using System.Text.RegularExpressions;

namespace Assignment37_TextProcessing
{
    /// <summary>
    ///     Class for searching in text and displaying the result with highlighting.
    /// </summary>
    public class TextProcessing
    {
        // Regexs for finding dates, urls and given input 
        private const string Date = "\\b(\\w{3},?)? ?\\d{1,2}[ ](\\w{3}|(\\d{1,2}))[ ]\\d{4}";
        private const string Url = "\\S*://\\S*\\b";
        private string _input;

        /// <summary>
        ///     A method that gives a keyword finds all instances of given keyword and highlight them
        ///     (and find all urls/dates and color them) in a text, the method writes in the console.
        /// </summary>
        /// <param name="args"> A keyword to search for in the text </param>
        public static void Main(string[] args)
        {
            var TP = new TextProcessing();

            string input = "a*+a*+*t";
            if (args.Length > 0)
                input = args[0];
            else
                Console.WriteLine("Default input: a*+a*+*t");

            string content = TextFileReader.ReadFile("TestFile.txt");
            string[] lines = TP.SpiltTextByRegex(input, content);
            foreach (string line in lines)
            {
                if (TP.RegexUrlTest(line))
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(line);
                    Console.ResetColor();
                    continue;
                }

                if (TP.RegexInputTest(line))
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(line);
                    Console.ResetColor();
                    continue;
                }

                if (TP.RegexDateTest(line))
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

        /// <summary>
        ///     Sets the regex strings
        /// </summary>
        /// <param name="input"> A string to find in the text </param>
        public void SetRegexInput(string input)
        {
            // Makes * work in given keyword. OPTIONAL: can take multiple *'s
            _input = input.Replace("*", "\\S*");

            // Makes + work in given keyword. OPTIONAL: can take multiple +'seven together with *'s
            string[] s = _input.Split('+');
            _input = "";
            for (int k = 0; k < s.Length - 1; k++)
                _input += "\\b" + s[k] + "\\b ";
            _input += "\\b" + s[s.Length - 1] + "\\b";
        }

        /// <summary>
        ///     splits text with the regex'es set in
        /// </summary>
        /// <param name="input"> a text to find in the content </param>
        /// <param name="content"> the content to find it in </param>
        /// <returns></returns>
        public String[] SpiltTextByRegex(string input, string content)
        {
            SetRegexInput(input);
            return Regex.Split(content, string.Format(@"({0}|{1}|{2})", _input, Url, Date),
                RegexOptions.IgnoreCase);
        }

        /// <summary>
        ///     Tests if a string is a match for the regex expression url
        /// </summary>
        /// <param name="s"> The string to test </param>
        /// <returns></returns>
        public bool RegexUrlTest(string s)
        {
            return (s == Regex.Match(s, string.Format(@"{0}", Url)).ToString());
        }

        /// <summary>
        ///     Tests if a string is a match for the regex expression input
        /// </summary>
        /// <param name="s"> The string to test </param>
        /// <returns></returns>
        public bool RegexInputTest(string s)
        {
            return (s == Regex.Match(s, string.Format(@"{0}", _input), RegexOptions.IgnoreCase).ToString());
        }

        /// <summary>
        ///     Tests if a string is a match for the regex expression date
        /// </summary>
        /// <param name="s"> The string to test </param>
        /// <returns></returns>
        public bool RegexDateTest(string s)
        {
            return (s == Regex.Match(s, string.Format(@"{0}", Date), RegexOptions.IgnoreCase).ToString());
        }
    }
}