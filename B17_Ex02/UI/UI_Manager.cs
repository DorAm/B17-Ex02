using System;

namespace B17_Ex02
{
    public class UI_Manager
    {
        private const int k_ExitGame = 0;
        private ActiveGame m_ActiveGame = null;
        private bool m_PlayAnotherGame = true;

        public void RunGame()
        {
            while (m_PlayAnotherGame)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Hello! Welcome to bul pgiya{0}Please enter max number of guesses. should be between 4 and 10", Environment.NewLine);
                int maxNumOfGuesses = getUserInput();
                if(maxNumOfGuesses == k_ExitGame)
                {
                    break;
                }

                m_ActiveGame = new ActiveGame(maxNumOfGuesses);
                m_PlayAnotherGame = m_ActiveGame.PlayGame();
            }
            Console.WriteLine("GoodBye!");
        }
        
        // get max num of guesses from user and makes sure it is between 4 and 10
        private int getUserInput()
        {
            bool validUserInput = true;
            int parsedInput;

            do
            {
                if (validUserInput == false)
                {
                    Console.WriteLine("Input is not Valid!{0}max num of guesses should be between 4 and 10", Environment.NewLine);
                }

                string input = Console.ReadLine();
                validUserInput = int.TryParse(input, out parsedInput);
                input = input.ToUpper();

                if (input == ActiveGame.k_QuitGame)
                {
                    parsedInput = k_ExitGame;
                }
                else if (validUserInput)
                {
                    validUserInput = (parsedInput >= Config.k_MinNumOfGusses) && (parsedInput <= Config.k_MaxNumOfGusses);
                }
            }
            while (validUserInput == false);

            return parsedInput;
        }
    }
}
