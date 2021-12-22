using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    internal class GameScreen
    {
        private static StringBuilder s_GameBoardBuilder = new StringBuilder(string.Empty);
        private static List<string> s_PlayerGuesses = Player.PlayerGuessesList;
        private static List<string> s_PlayerHits = Player.PlayerHitsList;
        private static int s_GuessNumber = 0;
        private static int s_NumberOfTries = 0;
        private static bool s_IsGuessedCorrectly = false;

        internal static void DrawOnScreen()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            s_GameBoardBuilder.Clear();
            Console.WriteLine("Current Board Status:\n");
            s_GameBoardBuilder.Append("|Pins:    |Result:|");
            s_GameBoardBuilder.Append(Environment.NewLine);
            s_GameBoardBuilder.Append("|=========|=======|");
            s_GameBoardBuilder.Append(Environment.NewLine);
            s_NumberOfTries = Player.NumberOfTries;
            s_GuessNumber = Player.PlayerHitsList.Count;
            if (s_NumberOfTries == s_GuessNumber)
            {
                s_GameBoardBuilder.Append("| " + RandomLettersGenerator.RandomCharsToStringBuilder() + " |       |");
            }
            else
            {
                s_GameBoardBuilder.Append("| # # # # |       |");
            }

            s_GameBoardBuilder.Append(Environment.NewLine);
            s_GameBoardBuilder.Append("|=========|=======|");
            printPlayerGuessesAndHits();
            printEmptyFields();
            s_GameBoardBuilder.Append(Environment.NewLine);
            Console.WriteLine(s_GameBoardBuilder);
            Bullseye.IfGuessedCorrectly(s_IsGuessedCorrectly);
            if (s_GuessNumber == s_NumberOfTries)
            {
                Bullseye.IfNotGuessedCorrectly(s_IsGuessedCorrectly);
            }
        }

        private static void printPlayerGuessesAndHits()
        {
            for (int i = 0; i < s_GuessNumber; i++)
            {
                s_GameBoardBuilder.Append(Environment.NewLine);
                s_GameBoardBuilder.Append("| " + Player.PlayerGuessesList[i] + "|" + Player.PlayerHitsList[i] + "|");
                s_GameBoardBuilder.Append(Environment.NewLine);
                s_GameBoardBuilder.Append("|=========|=======|");
                s_IsGuessedCorrectly = Bullseye.WinOrLose(Player.PlayerHitsList[i]);
            }
        }

        private static void printEmptyFields()
        {
            for (int i = 0; i < s_NumberOfTries - s_GuessNumber; i++)
            {
                s_GameBoardBuilder.Append(Environment.NewLine);
                s_GameBoardBuilder.Append("|         |       |");
                s_GameBoardBuilder.Append(Environment.NewLine);
                s_GameBoardBuilder.Append("|=========|=======|");
            }
        }
    }
}