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
                    validUserInput = item >= 'A' && item <= 'H';

                    if(validUserInput == false)
                    {
                        Console.WriteLine("chars have to be between A and H!");
                    }

                    // check if symbol appears more than once
                    if(doubleCheck.Contains(item))
                    {
                        Console.WriteLine("chars cant appear more than once!");
                    }
                    if (validUserInput && doubleCheck.Contains(item) == false)
                    {
                        doubleCheck.Add(item);
                    }
                    else
                    {
                        validUserInput = false;
                        break;
                    }
                }
            }

            return validUserInput;
        }
    }
}
