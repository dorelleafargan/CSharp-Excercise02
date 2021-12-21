using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    public class GameScreen
    {
        internal static void DrawOnScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            StringBuilder gameBoardBuilder = new StringBuilder(string.Empty);
            List<string> playerGuesses = Player.PlayerGuessesList;
            List<string> playerHits = Player.PlayerHitsList;
            int guessNumber = Player.PlayerHitsList.Count;
            int numberOfTries = Player.NumberOfTries;
            bool isGuessedCorrectly = false;
            Console.WriteLine("Current Board Status:\n");
            gameBoardBuilder.Append("|Pins:    |Result:|");
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("|=========|=======|");
            gameBoardBuilder.Append(Environment.NewLine);
            if (numberOfTries == guessNumber)
            {
                gameBoardBuilder.Append("| " + Bullseye.RandomCharsToStringBuilder() + " |       |");
            }
            else
            {
                gameBoardBuilder.Append("| # # # # |       |");

            }
            gameBoardBuilder.Append(Environment.NewLine);
            gameBoardBuilder.Append("|=========|=======|");

            for (int i = 0; i < guessNumber; i++)
            {
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("| " + Player.PlayerGuessesList[i] + "|" + Player.PlayerHitsList[i] + "|");
                gameBoardBuilder.Append(Environment.NewLine);
                gameBoardBuilder.Append("|=========|=======|");
                isGuessedCorrectly = Bullseye.WinOrLose(Player.PlayerHitsList[i]);
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
            Bullseye.IfGuessedCorrectly(isGuessedCorrectly);
            if (guessNumber == numberOfTries)
            {
                Bullseye.IfNotGuessedCorrectly(isGuessedCorrectly);
            }
        }
    }
}