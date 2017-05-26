using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class ActiveGame
    {
        private IGameInterface m_Game = null;

        public ActiveGame(int maxNumOfGuesses)
        {
            m_Game = new GameEngine(maxNumOfGuesses);
        }

        public bool PlayGame()
        {
            bool exit = false;
            bool success = false;
            m_Game.StartNewGame();

            while(!m_Game.isGameOver() && !exit)
            {
                Console.WriteLine("current board status:\n");
                printBoard(m_Game.GuessList);
                Console.WriteLine("please enter your guess - 4 different letters or 'Q' to exit.\n");
                string currUserInput = Console.ReadLine();
                exit = currUserInput == "Q";
                while (!exit && !success)
                {
                     Guess currentUserGuess = new Guess();
                    if(!(success = currentUserGuess.ConvertToGameSymbols(currUserInput)))
                    {
                        Console.WriteLine("Invalid Input! please enter your guess - 4 different letters or 'Q' to exit.\n");
                        currUserInput = Console.ReadLine();
                        exit = currUserInput == "Q";
                        continue;
                    }
                } 
            }

            printBoard(m_Game.GuessList);

            if(m_Game.isGameOver())
            {
                Console.WriteLine("sorry:( you are out of guesses\n");
            }

            else if(m_Game.isWon())
            {
                Console.WriteLine("congragulation! you have won!!!\n");
            }

            Console.WriteLine("would you like to play another round? press Y for yes\n");
            string userAnswer = Console.ReadLine();
            userAnswer = userAnswer.ToUpper();

            return userAnswer == "Y";
        }

        private void printBoard(List<Guess> status)
        {
            
        }
    }
}