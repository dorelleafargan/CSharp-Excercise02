using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    public class Bullseye
    {
        internal Player m_Player = new Player();
        private GameScreen m_Screen = new GameScreen();

        public void Run()
        {
            GetNumberOfTries();
            m_Screen.IntilizeScreen();
            char[] randomLetters = GenerateRandomLetters();
            for (int i = 0; i < m_Player.NumberOfTries; i++)
            {
                CheckGuess(randomLetters);
                m_Player.PlayerGuessStringBuilder();
                m_Player.PlayerHitsSringBuilder();
                m_Screen.drawAfterUserInput();
            }
        }

        internal void GetNumberOfTries()
        {
            Console.WriteLine("Enter a number of tries you want to play: (A number between 4-10)");
            int numberOfTries = 0;
            IsANumber(ref numberOfTries, int.TryParse(Console.ReadLine(), out numberOfTries));
            while (numberOfTries < 4 || numberOfTries > 10)
            {
                Console.WriteLine("Wrong input, you should input a number between 4-10.");
                IsANumber(ref numberOfTries, int.TryParse(Console.ReadLine(), out numberOfTries));
            }

            m_Player.NumberOfTries = numberOfTries;
        }

        public static char GuessInput()
        {
            char guess = '0';
            bool isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out guess);
            CheckIfStringOrChar(isOnlyOneChar, ref guess);
            CheckIfUserWantsToCloseProgram(guess);

            while (guess < 'A' || guess > 'Z')
            {
                Console.WriteLine("Wrong input, you should input a character from the ABC.");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out guess);
                CheckIfStringOrChar(isOnlyOneChar, ref guess);
                CheckIfUserWantsToCloseProgram(guess);
            }
            while (guess < 'A' || guess > 'H')
            {
                Console.WriteLine("Wrong Input, You should input only the first 8 characters in ABC.");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out guess);
                CheckIfStringOrChar(isOnlyOneChar, ref guess);
                CheckIfUserWantsToCloseProgram(guess);
            }

            return guess;
        }

        internal static void CheckIfStringOrChar(bool i_IsOnlyOneChar, ref char i_CheckChar)
        {
            while (!i_IsOnlyOneChar)
            {
                Console.WriteLine("Wrong Input, You should input only one character");
                i_IsOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out i_CheckChar);
            }
        }

        private static void CheckIfUserWantsToCloseProgram(char i_Guess)
        {
            if (i_Guess == 'q' || i_Guess == 'Q')
            {
                Environment.Exit(0);
            }
        }

        private static char[] GenerateRandomLetters()
        {
            Random random = new Random();
            char randomChar = (char)random.Next(65, 72);
            char[] randomCharsArray = new char[4];
            randomCharsArray[0] = randomChar;
            for (int i = 1; i < 4; i++)
            {
                randomChar = (char)random.Next(65, 72);
                while (randomCharsArray.Contains(randomChar))
                {
                    randomChar = (char)random.Next(65, 72);
                }

                randomCharsArray[i] = randomChar;
            }

            Console.WriteLine(randomCharsArray);
            return randomCharsArray;
        }

        public void CharGuessToString()
        {
            Console.WriteLine("Please type your next guess: (A B C D) or 'Q' to quit");
            StringBuilder playerGuessCharToString = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                playerGuessCharToString.Append(GuessInput());
            }

            m_Player.PlayerGuess = playerGuessCharToString.ToString();
        }

        public void CheckGuess(char[] i_randomCharsArray)
        {
            CharGuessToString();
            string playerGuess = m_Player.PlayerGuess;
            int[] counterArray = new int[3];  // [V counter, X counter, NoHit]
            for (int i = 0; i < 4; i++)
            {
                if (playerGuess.Contains(i_randomCharsArray[i]))
                {
                    if (i_randomCharsArray[i] == playerGuess[i])
                    {
                        counterArray[0]++;
                    }
                    else
                    {
                        counterArray[1]++;
                    }
                }
                else
                {
                    counterArray[2]++;
                }
            }

            m_Player.PlayerHitsCounter = counterArray;
        }

        public static void IsANumber(ref int io_NumberOfTries, bool io_IsANumber)
        {
            while (!io_IsANumber)
            {
                Console.WriteLine("Wrong input, you should input a number only, Try again.");
                io_IsANumber = int.TryParse(Console.ReadLine(), out io_NumberOfTries);
            }
        }

        public static bool WinOrLose(string i_Hit)
        {
            return i_Hit.Contains("V V V V");
        }
    }

}
