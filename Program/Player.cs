using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    internal class Player
    {
        private static int s_NumberOfTries = 0;
        private static string s_PlayerGuess;
        private static int[] s_RandomCharsHitsCounterArray;
        private static List<string> s_PlayerGuessStringList = new List<string>();
        private static List<string> s_PlayerHitsStringList = new List<string>();
  
        internal static int NumberOfTries 
        {
            get { return s_NumberOfTries; }
            set { s_NumberOfTries = value; }
        }

        internal static string PlayerGuess
        {
            get { return s_PlayerGuess; }
            set { s_PlayerGuess = value; }
        }

        internal static int[] PlayerHitsCounter
        {
            get { return s_RandomCharsHitsCounterArray; }
            set { s_RandomCharsHitsCounterArray = value; }
        }

        internal static List<string> PlayerGuessesList
        {
            get { return s_PlayerGuessStringList; }
        }

        internal static List<string> PlayerHitsList
        {
            get { return s_PlayerHitsStringList; }
        }

        internal static void PlayerHitsSringBuilder()
        {
            StringBuilder hitString = new StringBuilder();
            for (int i = 0; i < s_RandomCharsHitsCounterArray[0]; i++)
            {
                hitString.Append("V ");
            }

            for (int j = 0; j < s_RandomCharsHitsCounterArray[1]; j++)
            {
                hitString.Append("X ");
            }

            for (int k = 0; k < s_RandomCharsHitsCounterArray[2]; k++)
            {
                hitString.Append("  ");
            }

            s_PlayerHitsStringList.Add(hitString.Remove(hitString.Length - 1, 1).ToString());
        }

        internal static void PlayerGuessStringList()
        {
            s_PlayerGuessStringList.Add(PlayerGuess + " ");
        }

        internal static void PlayerListsReset()
        {
            s_PlayerHitsStringList.Clear();
            s_PlayerGuessStringList.Clear();
        }
    }
}
