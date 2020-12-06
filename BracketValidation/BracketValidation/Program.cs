using System;
using System.Collections.Generic;
using System.Linq;

namespace BracketValidation
{
    class Program
    {
        public static void Main(String[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();

                Console.WriteLine(AreBracketsCorrectlyDisplayed(input));
            }
        }
        static bool IsMatchingPair(char char1, char char2)
        {
            if (char1 == '(' && char2 == ')')
                return true;
            else if (char1 == '[' && char2 == ']')
                return true;
            else
                return false;
        }

        static bool AreBracketsCorrectlyDisplayed(string input)
        {
            List<char> ls = new List<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '('
                    || input[i] == '[')
                    ls.Add(input[i]);
                if (input[i] == ')'
                    || input[i] == ']')
                {
                    if (ls.Count == 0)
                    {
                        return false;
                    }
                    else if (!IsMatchingPair(ls.LastOrDefault(), input[i]))
                    {
                        return false;
                    }
                    ls.RemoveAt(ls.Count - 1);
                }
            }
            if (ls.Count == 0)
                return true;
            else
            {
                return false;
            }
        }


    }
}


