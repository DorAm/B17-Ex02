﻿using System;

namespace B17_Ex02
{
    public class UI_Manager
    {
        private ActiveGame activeGame = null;
        private bool hasEndedCorrectly;
        public void RunGame()
        {
            Console.WriteLine("Hello! Welcome to bul pgyaa\nPlease enter max number of guesses. should be between 4 and 10");
            int maxNumOfGuesses = getUserInput();
            //TODO check if input is Q
            activeGame = new ActiveGame(maxNumOfGuesses);
            hasEndedCorrectly = activeGame.PlayGame();// for testing

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
