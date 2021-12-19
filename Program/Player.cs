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
        private static string m_PlayerHits;
        private static int[] m_RandomCharsCounterArray;
        private static List<string> m_PlayerGuessStringArray = new List<string>();
        private static List<string> m_PlayerHitsStringArray = new List<string>();

        public static int GetNumberOfTries()
        {
            return m_NumberOfTries;
        }

        public static void SetNumberOfTries(int i_NumberOfTries)
        {
            m_NumberOfTries = i_NumberOfTries;
        }

        public static string GetPlayerGuess()
        {
            return m_PlayerGuess;
        }

        public static void SetPlayerGuess(StringBuilder i_PlayerGuess)
        {
            m_PlayerGuess = i_PlayerGuess.ToString();
        }

        public static string GetPlayerHits()
        {
            return m_PlayerHits;
        }

        public static void SetPlayerHits(string i_PlayerHits)
        {
            m_PlayerHits = i_PlayerHits;
        }
            
        public static int[] GetPlayerHitsCounterArray()
        {
            return m_RandomCharsCounterArray;
        }

        public static void SetPlayerHitsCounterArray(int[] i_PlayerHitsCounterArray)
        {
            m_RandomCharsCounterArray = i_PlayerHitsCounterArray;
        }

        public static List<string> GetPlayerGuessesStringArray()
        {
            return m_PlayerGuessStringArray;
        }

        public static void SetPlayerGuessesStringArray(StringBuilder i_PlayerGuessForPrint)
        {
            m_PlayerGuessStringArray.Add(i_PlayerGuessForPrint.ToString());
        }

        public static List<string> GetPlayerHitsStringArray()
        {
            return m_PlayerHitsStringArray;
        }

        public static void SetPlayerHitsStringArray(StringBuilder i_PlayerHitsForPrint)
        {
            m_PlayerHitsStringArray.Add(i_PlayerHitsForPrint.ToString());
        }
    }
}
