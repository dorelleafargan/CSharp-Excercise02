using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    public class GameScreen
    {
        internal static void IntilizeScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder gameBoardBuilder = new StringBuilder(string.Empty);
            Console.WriteLine("Current Board Status:\n");

            gameBoardBuilder.Append("|Pins:    |Result:|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("|=========|=======|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("| # # # # |       |");
            gameBoardBuilder.Append(Environment.NewLine);
            for (int i = 0; i < Player.NumberOfTries; i++)
            {
                gameBoardBuilder.Append("|=========|=======|");
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("|         |       |");
                gameBoardBuilder.Append(Environment.NewLine);
            }

            gameBoardBuilder.Append("|=========|=======|");
            gameBoardBuilder.Append(Environment.NewLine);
            Console.WriteLine(gameBoardBuilder);
        }

        internal static void drawAfterUserInput()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder gameBoardBuilder = new StringBuilder(string.Empty);
            List<string> playerGuesses = Player.PlayerGuessesList;
            List<string> playerHits = Player.PlayerHitsList;
            int guessNumber = Player.PlayerHitsList.Count;
            int numberOfTries = Player.NumberOfTries;
            bool isEndGame = false;
            Console.WriteLine("Current Board Status:\n");
            gameBoardBuilder.Append("|Pins:    |Result:|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("|=========|=======|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("| # # # # |       |");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("|=========|=======|");
            for (int i = 0; i < guessNumber; i++)
            {
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("| " + Player.PlayerGuessesList[i] + "|" + Player.PlayerHitsList[i] + "|");
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("|=========|=======|");
                isEndGame = Bullseye.WinOrLose(Player.PlayerHitsList[i]);
            }

            for (int i = 0; i < numberOfTries - guessNumber; i++)
            {
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("|         |       |");
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("|=========|=======|");
            }

            gameBoardBuilder.Append(Environment.NewLine);

            Console.WriteLine(gameBoardBuilder);

            if (isEndGame == true)
            {
                char startGameOrNot = '0';
                bool isOnlyOneChar = false;
                Console.WriteLine("You guessed correctly after " + Player.PlayerHitsList.Count() + " Steps!");
                Console.WriteLine("Would you like to start a new game? (Y/N)");
                isOnlyOneChar = char.TryParse(Console.ReadLine().ToUpper(), out startGameOrNot);
                Bullseye.CheckIfStringOrChar(isOnlyOneChar, ref startGameOrNot);
                while (!(startGameOrNot == 'Y' || startGameOrNot == 'N'))
                {
                    Console.WriteLine("Wrong input, you should enter only Y or N characters.");
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