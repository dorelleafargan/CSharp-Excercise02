using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    public class Player
    {
        private static int m_NumberOfTries = 0;
        private static string m_PlayerGuess;
        private static int[] m_RandomCharsHitsCounterArray;
        private static List<string> m_PlayerGuessStringList = new List<string>();
        private static List<string> m_PlayerHitsStringList = new List<string>();
  
        public static int NumberOfTries 
        {
            get { return m_NumberOfTries; }
            set { m_NumberOfTries = value; }
        }

        public static string PlayerGuess
        {
            get { return m_PlayerGuess; }
            set { m_PlayerGuess = value; }
        }

        public static int[] PlayerHitsCounter
        {
            get { return m_RandomCharsHitsCounterArray; }
            set { m_RandomCharsHitsCounterArray = value; }
        }

        public static List<string> PlayerGuessesList
        {
            get { return m_PlayerGuessStringList; }
            set { }
        }

        public static List<string> PlayerHitsList
        {
            get { return m_PlayerHitsStringList; }
            set { }
        }

        internal static void PlayerHitsSringBuilder()
        {
            StringBuilder hitString = new StringBuilder();
            int[] playerHitsArray = PlayerHitsCounter;
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

            PlayerHitsList.Add(hitString.Remove(hitString.Length - 1, 1).ToString());
        }

        internal static void PlayerGuessStringList()
        {
            PlayerGuessesList.Add(PlayerGuess + " ");
        }

        public static void PlayerListsReset()
        {
            m_PlayerHitsStringList.Clear();
            m_PlayerGuessStringList.Clear();
        }
    }
}
