using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    public class GameScreen
    {
        public static void IntilizeScreen()
        {
            Bullseye.GetNumberOfTries();
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder gameBoardBuilder = new StringBuilder(string.Empty);
            Console.WriteLine("Current Board Status:\n");

            gameBoardBuilder.Append("|Pins:    |Result:|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("|=========|=======|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("| # # # # |       |");
            gameBoardBuilder.Append(Environment.NewLine);
            for (int i = 0; i < Player.GetNumberOfTries(); i++)
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
            List<string> playerGuesses = Player.GetPlayerGuessesStringArray();
            List<string> playerHits = Player.GetPlayerHitsStringArray();
            int guessNumber = Player.GetPlayerHitsStringArray().Count;
            int numberOfTries = Player.GetNumberOfTries();
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
                gameBoardBuilder.Append("| " + Player.GetPlayerGuessesStringArray()[i] + "|" + Player.GetPlayerHitsStringArray()[i] + "|");
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("|=========|=======|");
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
        }

        public static void PlayerHitsSringBuilder()
        {
            StringBuilder hitString = new StringBuilder();
            int[] playerHitsArray = Player.GetPlayerHitsCounterArray();
            for (int i = 0; i < playerHitsArray[0]; i++)
            {
                hitString.Append("V ");
            }

            for (int j = 0; j < playerHitsArray[1]; j++)
            {
                hitString.Append("X ");
            }

            for (int k = 0; k < playerHitsArray[2]; k++)
            {
                hitString.Append("  ");
            }

            Player.SetPlayerHitsStringArray(hitString.Remove(hitString.Length-1, 1));
        }
        
        public static void PlayerGuessStringBuilder()
        {
            StringBuilder PlayerGuessString = new StringBuilder();
            for (int i = 0; i < Player.GetPlayerGuess().Length; i++)
            {
                PlayerGuessString.Append(Player.GetPlayerGuess()[i] + " ");
            }
            Player.SetPlayerGuessesStringArray(PlayerGuessString);
        }
    }
}
