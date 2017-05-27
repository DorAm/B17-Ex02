using System;

namespace B17_Ex02
{
    public class UI_Manager
    {
        private ActiveGame m_ActiveGame = null;
        private bool m_PlayAnotherGame = true;
        private const int k_ExitGame = 0;

        public void RunGame()
        {
            while (m_PlayAnotherGame)
            {
                Console.WriteLine("Hello! Welcome to bul pgyaa\nPlease enter max number of guesses. should be between 4 and 10");
                int maxNumOfGuesses = getUserInput();
                if(maxNumOfGuesses == k_ExitGame)
                {
                    break;
                }
                m_ActiveGame = new ActiveGame(maxNumOfGuesses);
                m_PlayAnotherGame = m_ActiveGame.PlayGame();// for testing
            }
        }
        
        // get max num of guesses from user and makes sure it is between 4 and 10
        private int getUserInput()
        {
            bool validUserInput = false;
            bool isInRange = true;
            int parsedInput;

            do
            {
                if (!isInRange)
                {
                    Console.WriteLine("Input is not Valid!{0}max num of guesses should be between 4 and 10", Environment.NewLine);
                }

                String input = Console.ReadLine();
                validUserInput = int.TryParse(input, out parsedInput);
                input.ToUpper();

                if (input == ActiveGame.k_QuitGame)
                {
                    parsedInput = k_ExitGame;
                }

                if (validUserInput || isInRange)
                {
                    isInRange = (parsedInput >= 4) && (parsedInput <= 10);
                }

            } while (!isInRange);

            return parsedInput;
        }
    }
}


