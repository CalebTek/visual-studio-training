using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo.OOP.Common
{
    public static class StringHandler
    {
        /// <summary>
        /// Inserts spaces before each capital letter in a string.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string InsertSpaces(this string text)
        {
            string result = string.Empty;
            if (!string.IsNullOrWhiteSpace(text))
            {
                foreach (char letter in text)
                {
                    if (char.IsUpper(letter))
                    {
                        // Trim any spaces already there
                        result = result.Trim();
                        result += " ";
                    }
                    result += letter;
                }
            }
            return result.Trim();
        }
    }
}
