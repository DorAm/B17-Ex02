using System;
using System.Collections.Generic;


namespace B17_Ex02
{
    class Guess
    {
        public List<eGameSymbols> m_Guess { get; } = null;

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
                    m_Guess.Add((eGameSymbols)Enum.Parse(typeof(eGameSymbols), item.ToString(), ignoreCase));
                }
            }

            return validUserInput;
        }

        private bool checkUserInput(string i_userGuess)
        {
            bool validUserInput = false;
            System.Collections.Generic.HashSet<char> doubleCheck = new HashSet<char>();
            if (i_userGuess.Length == GameConfig.GuessLength)
            {
                foreach (char item in i_userGuess)
                {
                    validUserInput = Char.GetNumericValue(item) >= 'A' && Char.GetNumericValue(item) <= 'H' ? true : false;

                    if (validUserInput = doubleCheck.Contains(item) ? false : true)// check if symbol appears more than once
                    {
                        doubleCheck.Add(item);
                    }

                    if (!validUserInput)
                    {
                        break;
                    }
                }
            }

            return validUserInput;
        }
    }
}

