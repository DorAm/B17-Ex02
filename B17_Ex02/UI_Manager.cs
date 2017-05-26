﻿using System;

namespace B17_Ex02
{
    public class UI_Manager
    {
        private ActiveGame m_activeGame = null;
        private bool m_PlayAnotherGame = true;
        public void RunGame()
        {
            while (m_PlayAnotherGame)
            {
                Console.WriteLine("Hello! Welcome to bul pgyaa\nPlease enter max number of guesses. should be between 4 and 10");
                int maxNumOfGuesses = getUserInput();
                m_activeGame = new ActiveGame(maxNumOfGuesses);
                m_PlayAnotherGame = m_activeGame.PlayGame();// for testing
            }
        }

        private int getUserInput()
        {
            bool success = false;
            bool isInRange = true;
            int parsedInput;
            do
            {
                if (!isInRange)
                {
                    Console.WriteLine("Input is not Valid!\nmax num of guesses should be between 4 and 10");
                }

                String input = Console.ReadLine();
                success = int.TryParse(input, out parsedInput);
                if (input == "Q" || input == "q")
                {
                    parsedInput = 0;
                }
                if (success)
                {
                    isInRange = (parsedInput >= 4) && (parsedInput <= 8) ? true : false;
                }

            } while (!isInRange);

            return parsedInput;
        }// get max num of guesses from user and makes sure it is between 4 and 10

            
    }
}


