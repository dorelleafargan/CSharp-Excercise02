using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    internal class RandomLettersGenerator
    {
        private static char[] s_RandomCharsLetters = new char[4];

        internal static char[] RandomLetters
        {
            get { return s_RandomCharsLetters; }
            set { s_RandomCharsLetters = value; }
        }

        internal static void GenerateRandomLetters()
        {
            Random random = new Random();
            char randomChar = (char)random.Next(65, 72);
            s_RandomCharsLetters[0] = randomChar;
            for (int i = 1; i < 4; i++)
            {
                randomChar = (char)random.Next(65, 72);
                while (s_RandomCharsLetters.Contains(randomChar))
                {
                    randomChar = (char)random.Next(65, 72);
                }

                s_RandomCharsLetters[i] = randomChar;
            }
        }

        internal static string RandomCharsToStringBuilder()
        {
            StringBuilder randomCharsString = new StringBuilder();
            for (int i = 0; i < s_RandomCharsLetters.Length; i++)
            {
                randomCharsString.Append(s_RandomCharsLetters[i] + " ");
            }

            return randomCharsString.Remove(randomCharsString.Length - 1, 1).ToString();
        }
    }
}
