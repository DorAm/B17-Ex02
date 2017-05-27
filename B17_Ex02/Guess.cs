using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class Guess
    {
        private List<Config.eGameSymbols> m_GuessAttempt = null;
        public List<Config.eGameSymbols> GuessAttempt { get => m_GuessAttempt; }

        public Guess()
        {
            m_GuessAttempt = new List<Config.eGameSymbols>();
        }

        public bool ConvertToGameSymbols(string i_UserGuess)
        {
            bool validUserInput = true;
            bool ignoreCase = true;

            i_UserGuess = i_UserGuess.ToUpper();
            validUserInput = checkUserInput(i_UserGuess);

            if (validUserInput)
            {
                foreach (char item in i_UserGuess)
                {                                    
                    m_GuessAttempt.Add((Config.eGameSymbols)Enum.Parse(typeof(Config.eGameSymbols), item.ToString(), ignoreCase));
                }
            }

            return validUserInput;
        }

        private bool checkUserInput(string i_userGuess)
        {
            bool validUserInput = false;

            HashSet<char> doubleCheck = new HashSet<char>();
            if (i_userGuess.Length == Config.k_GuessLength)
            {
                foreach (char item in i_userGuess)
                {
                    validUserInput = Char.GetNumericValue(item) >= 'A' && Char.GetNumericValue(item) <= 'H';
                    if (doubleCheck.Contains(item) == false)// check if symbol appears more than once
                    {
                        doubleCheck.Add(item);
                    }

                    else
                    {
                        validUserInput = false;
                    }
                }
            }

            return validUserInput;
        }
    }
}

