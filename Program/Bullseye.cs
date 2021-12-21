using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    public class Bullseye
    {
        private static char[] m_RandomCharsLetters = new char[4];
        public void Run()
        {
            GetNumberOfTries();
            GameScreen.DrawOnScreen();
            m_RandomCharsLetters = GenerateRandomLetters();
            for (int i = 0; i < Player.NumberOfTries; i++)
            {
                CheckGuess(m_RandomCharsLetters);
                Player.PlayerGuessStringList();
                Player.PlayerHitsSringBuilder();
                GameScreen.DrawOnScreen();
            }
        }

        internal static void GetNumberOfTries()
        {
            Console.WriteLine("Enter a number of tries you want to play: (A number between 4-10)");
            int numberOfTries = 0;
            IsANumber(ref numberOfTries, int.TryParse(Console.ReadLine(), out numberOfTries));
            while (numberOfTries < 4 || numberOfTries > 10)
            {
                Console.WriteLine("\nWrong input, you should input a number between 4-10.\n");
                IsANumber(ref numberOfTries, int.TryParse(Console.ReadLine(), out numberOfTries));
            }

            Player.NumberOfTries = numberOfTries;
        }

        public static void GuessInput()
        {
            string guess = String.Empty;
            bool isNotCorrectInput = false;
            Console.WriteLine("Please type your next guess: (A B C D) or 'Q' to quit");
            do
            {
                isNotCorrectInput = false;
                guess = Console.ReadLine().ToUpper();
                CheckIfUserWantsToCloseProgram(guess[0]);
                if (guess.Length != 7)
                {
                    Console.WriteLine("\nWrong input, you should input letters in the following format:\nX X X X");
                    isNotCorrectInput = true;
                }

                if ((isNotCorrectInput == false) && !(guess[1] == ' ' && guess[3] == ' ' && guess[5] == ' '))
                {
                    Console.WriteLine("\nWrong input, you should input spaces between the letters.\n");
                    isNotCorrectInput = true;
                }

                if ((isNotCorrectInput == false) && !((char.IsLetter(guess[0]) && char.IsLetter(guess[2]) && char.IsLetter(guess[4]) && char.IsLetter(guess[6]))))
                {
                    Console.WriteLine("Wrong input, you should input a character from the ABC.\n");
                    isNotCorrectInput = true;
                }

                if ((isNotCorrectInput == false) && !(CheckLettersInCorrectRange(guess)))
                {
                    Console.WriteLine("Wrong Input, You should input only the first 8 characters in ABC.\n");
                    isNotCorrectInput = true;
                }
            }
            while (isNotCorrectInput);

            Player.PlayerGuess = guess;
        }

        private static bool CheckLettersInCorrectRange(string i_LetterString)
        {
            bool isCorrectLetter = true;
            foreach (char letter in i_LetterString)
            {
                if (letter == ' ')
                {
                    continue;
                }
                else if (letter < 'A' || letter > 'H')
                {
                    isCorrectLetter = false;
                    break;
                }
            }
            return isCorrectLetter;
        }

        internal static void CheckIfStringOrChar(bool i_IsOnlyOneChar, ref char i_CheckChar)
        {
            while (!i_IsOnlyOneChar)
            {
                Console.WriteLine("\nWrong Input, You should input only one character\n");
                i_IsOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out i_CheckChar);
            }
        }

        private static void CheckIfUserWantsToCloseProgram(char i_Guess)
        {
            if (i_Guess == 'q' || i_Guess == 'Q')
            {
                Console.WriteLine("\nThanks for playing. Goodbye.\n");
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

            return randomCharsArray;
        }

        public static string RandomCharsToStringBuilder()
        {
            StringBuilder randomCharsString = new StringBuilder();
            for (int i = 0; i < m_RandomCharsLetters.Length; i++)
            {
                randomCharsString.Append(m_RandomCharsLetters[i] + " ");
            }
            return randomCharsString.Remove(randomCharsString.Length - 1, 1).ToString();
        }

        public void CheckGuess(char[] i_randomCharsArray)
        {
            GuessInput();
            string playerGuess = Player.PlayerGuess.Replace(" ", "");
            Console.WriteLine(playerGuess);
            int[] counterArray = new int[3];  // [V counter, X counter, NoHitCounter]
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

            Player.PlayerHitsCounter = counterArray;
        }

        public static void IsANumber(ref int io_NumberOfTries, bool io_IsANumber)
        {
            while (!io_IsANumber)
            {
                Console.WriteLine("\nWrong input, you should input a number only, Try again.\n");
                io_IsANumber = int.TryParse(Console.ReadLine(), out io_NumberOfTries);
            }
        }

        public static bool WinOrLose(string i_Hit)
        {
            return i_Hit.Contains("V V V V");
        }

        public static void IfGuessedCorrectly(bool i_IsGueesedCorrectly)
        {
            char startGameOrNot = '0';
            bool isOnlyOneChar = false;
            if (i_IsGueesedCorrectly == true)
            {
                Console.WriteLine("\nYou guessed correctly after " + Player.PlayerHitsList.Count() + " Steps!\n");
                Console.WriteLine("Would you like to start a new game? (Y/N)");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                Bullseye.CheckIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                while (!(startGameOrNot == 'Y' || startGameOrNot == 'N'))
                {
                    Console.WriteLine("\nWrong input, you should enter only Y or N characters.\n");
                    isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                    Bullseye.CheckIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                }

                if (startGameOrNot == 'N')
                {
                    Console.WriteLine("Thanks for playing have a nice day, see you soon.\n");
                    Environment.Exit(0);
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    Player.PlayerListsReset();
                    Program.Main();
                }
            }
        }

        public static void IfNotGuessedCorrectly(bool i_IsGuessedCorrectly)
        {
            char startGameOrNot = '0';
            bool isOnlyOneChar = false;
            if (i_IsGuessedCorrectly == false)
            {
                Console.WriteLine("No more guesses allowed. You Lost.\n");
                Console.WriteLine("Would you like to start a new game? (Y/N)");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                Bullseye.CheckIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                while (!(startGameOrNot == 'Y' || startGameOrNot == 'N'))
                {
                    Console.WriteLine("Wrong input, you should enter only Y or N characters.\n");
                    isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                    Bullseye.CheckIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                }

                if (startGameOrNot == 'N')
                {
                    Console.WriteLine("Thanks for playing have a nice day, see you soon.\n");
                    Environment.Exit(0);
                }
                else
                {
                    Ex02.ConsoleUtils.Screen.Clear();
                    Player.PlayerListsReset();
                    Program.Main();
                }
            }
        }
    }
}