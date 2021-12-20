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
        private static int[] m_RandomCharsCounterArray;
        private static List<string> m_PlayerGuessStringArray = new List<string>();
        private static List<string> m_PlayerHitsStringArray = new List<string>();

        public int NumberOfTries 
        {
            get { return m_NumberOfTries; }
            set { m_NumberOfTries = value; }
        }

        public string PlayerGuess
        {
            get { return m_PlayerGuess; }
            set { m_PlayerGuess = value; }
        }

        public int[] PlayerHitsCounter
        {
            get { return m_RandomCharsCounterArray; }
            set { m_RandomCharsCounterArray = value; }
        }

        public List<string> PlayerGuessesList
        {
            get { return m_PlayerGuessStringArray; }
            set { }
        }

        public List<string> PlayerHitsList
        {
            get { return m_PlayerHitsStringArray; }
            set { }
        }

        public void PlayerHitsSringBuilder()
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

        public void PlayerGuessStringBuilder()
        {
            StringBuilder PlayerGuessString = new StringBuilder();
            for (int i = 0; i < PlayerGuess.Length; i++)
            {
                PlayerGuessString.Append(PlayerGuess[i] + " ");
            }

            PlayerGuessesList.Add(PlayerGuessString.ToString());
        }
    }
}
