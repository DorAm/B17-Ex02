using System;
using System.Collections.Generic;


namespace B17_Ex02
{
    class Guess
    {
        List<eGameSymbols> m_guess = null;

        public bool ConvertToGameSymbols(string[] i_userGuess)
        {
            bool retVal = true;
            bool ignoreCase = true;
            retVal = checkUserInput(i_userGuess);
            foreach (string item in i_userGuess)
            {
                m_guess.Add((eGameSymbols)Enum.Parse(typeof(eGameSymbols), item, ignoreCase));
            }
        }

        private bool checkUserInput(string[] i_userGuess)
        {
            bool retVal = true;
            return retVal;
        }
    }
}
