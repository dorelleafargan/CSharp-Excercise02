using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    internal class Bullseye
    {
        internal void Run()
        {
            numberOfTries();
            GameScreen.DrawOnScreen();
            RandomLettersGenerator.GenerateRandomLetters();
            char[] randomLetters = RandomLettersGenerator.RandomLetters;
            for (int i = 0; i < Player.NumberOfTries; i++)
            {
                checkGuess(randomLetters);
                Player.PlayerGuessStringList();
                Player.PlayerHitsSringBuilder();
                GameScreen.DrawOnScreen();
            }
        }

        private void numberOfTries()
        {
            Console.WriteLine("Enter a number of tries you want to play: (A number between 4-10)");
            int numberOfTries = 0;
            this.isANumber(ref numberOfTries, int.TryParse(Console.ReadLine(), out numberOfTries));
            while (numberOfTries < 4 || numberOfTries > 10)
            {
                Console.WriteLine("\nWrong input, you should input a number between 4-10.\n");
                this.isANumber(ref numberOfTries, int.TryParse(Console.ReadLine(), out numberOfTries));
            }

            Player.NumberOfTries = numberOfTries;
        }

        private void guessInput()
        {
            string guess = string.Empty;
            bool isNotCorrectInput = false;
            Console.WriteLine("Please type your next guess: (A B C D) or 'Q' to quit");
            do
            {
                isNotCorrectInput = false;
                guess = Console.ReadLine().ToUpper();
                this.checkIfUserWantsToCloseProgram(guess[0]);
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

                if ((isNotCorrectInput == false) && !(char.IsLetter(guess[0]) && char.IsLetter(guess[2]) && char.IsLetter(guess[4]) && char.IsLetter(guess[6])))
                {
                    Console.WriteLine("Wrong input, you should input a character from the ABC.\n");
                    isNotCorrectInput = true;
                }

                if ((isNotCorrectInput == false) && !this.checkLettersInCorrectRange(guess))
                {
                    Console.WriteLine("Wrong Input, You should input only the first 8 characters in ABC.\n");
                    isNotCorrectInput = true;
                }
            }
            while (isNotCorrectInput);

            Player.PlayerGuess = guess;
        }

        private bool checkLettersInCorrectRange(string i_LetterString)
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

        private static void checkIfStringOrChar(bool i_IsOnlyOneChar, ref char io_CheckChar)
        {
            while (!i_IsOnlyOneChar)
            {
                Console.WriteLine("\nWrong Input, You should input only one character\n");
                i_IsOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out io_CheckChar);
            }
        }

        private void checkIfUserWantsToCloseProgram(char i_UserInput)
        {
            if (i_UserInput == 'Q')
            {
                Console.WriteLine("\nThanks for playing. Goodbye.\n");
                Environment.Exit(0);
            }
        }

        private void checkGuess(char[] i_RandomCharsArray)
        {
            this.guessInput();
            string playerGuess = Player.PlayerGuess.Replace(" ", string.Empty);
            int[] counterArray = new int[3];  // [V counter, X counter, NoHitCounter]
            for (int i = 0; i < 4; i++)
            {
                if (playerGuess.Contains(i_RandomCharsArray[i]))
                {
                    if (i_RandomCharsArray[i] == playerGuess[i])
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

        private void isANumber(ref int io_numberOfTries, bool i_isANumber)
        {
            while (!i_isANumber)
            {
                Console.WriteLine("\nWrong input, you should input a number only, Try again.\n");
                i_isANumber = int.TryParse(Console.ReadLine(), out io_numberOfTries);
            }
        }

        internal static bool WinOrLose(string i_Hit)
        {
            return i_Hit.Contains("V V V V");
        }

        internal static void IfGuessedCorrectly(bool i_IsGueesedCorrectly)
        {
            char startGameOrNot = '0';
            bool isOnlyOneChar = false;
            if (i_IsGueesedCorrectly)
            {
                Console.WriteLine("\nYou guessed correctly after " + Player.PlayerHitsList.Count() + " Steps!\n");
                Console.WriteLine("Would you like to start a new game? (Y/N)");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                checkIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                while (!(startGameOrNot == 'Y' || startGameOrNot == 'N'))
                {
                    Console.WriteLine("\nWrong input, you should enter only Y or N letter.\n");
                    isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                    checkIfStringOrChar(isOnlyOneChar, ref startGameOrNot);

                }

                if (startGameOrNot == 'N')
                {
                    Console.WriteLine("Thanks for playing, have a nice day.\n");
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

        internal static void IfNotGuessedCorrectly(bool i_m_IsGuessedCorrectly)
        {
            char startGameOrNot = '0';
            bool isOnlyOneChar = false;
            if (i_m_IsGuessedCorrectly == false)
            {
                Console.WriteLine("No more guesses allowed. You Lost.\n");
                Console.WriteLine("Would you like to start a new game? (Y/N)");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                checkIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                while (!(startGameOrNot == 'Y' || startGameOrNot == 'N'))
                {
                    Console.WriteLine("Wrong input, you should enter only Y or N letter.\n");
                    isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                    checkIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                }

                if (startGameOrNot == 'N')
                {
                    Console.WriteLine("Thanks for playing, have a nice day.\n");
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