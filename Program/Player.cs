using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A22_Ex02
{
    internal class Player
    {
        private static int m_NumberOfTries = 0;
        private static string m_PlayerGuess;
        private static int[] m_RandomCharsHitsCounterArray;
        private static List<string> m_PlayerGuessStringList = new List<string>();
        private static List<string> m_PlayerHitsStringList = new List<string>();
  
        internal static int NumberOfTries 
        {
            get { return m_NumberOfTries; }
            set { m_NumberOfTries = value; }
        }

        internal static string PlayerGuess
        {
            get { return m_PlayerGuess; }
            set { m_PlayerGuess = value; }
        }

        internal static int[] PlayerHitsCounter
        {
            get { return m_RandomCharsHitsCounterArray; }
            set { m_RandomCharsHitsCounterArray = value; }
        }

        internal static List<string> PlayerGuessesList
        {
            get { return m_PlayerGuessStringList; }
        }

        internal static List<string> PlayerHitsList
        {
            get { return m_PlayerHitsStringList; }
        }

        internal static void PlayerHitsSringBuilder()
        {
            StringBuilder hitString = new StringBuilder();
            for (int i = 0; i < m_RandomCharsHitsCounterArray[0]; i++)
            {
                hitString.Append("V ");
            }

            for (int j = 0; j < m_RandomCharsHitsCounterArray[1]; j++)
            {
                hitString.Append("X ");
            }

            for (int k = 0; k < m_RandomCharsHitsCounterArray[2]; k++)
            {
                hitString.Append("  ");
            }

            m_PlayerHitsStringList.Add(hitString.Remove(hitString.Length - 1, 1).ToString());
        }

        internal static void PlayerGuessStringList()
        {
            m_PlayerGuessStringList.Add(PlayerGuess + " ");
        }

        internal static void PlayerListsReset()
        {
            m_PlayerHitsStringList.Clear();
            m_PlayerGuessStringList.Clear();
        }
    }
}
