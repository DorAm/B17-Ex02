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
            bool notExit = true;
            bool retVal = true;
            m_Game.StartNewGame();

            while(!m_Game.isGameOver())
            {
                Console.WriteLine("current board status:");
                printBoard(m_Game.GuessList);
                Console.WriteLine("please enter your guess - 4 different letters or 'Q' to exit.");
                string currUserInput = Console.ReadLine();

            }

            return retVal;
        }

        private void printBoard(List<Guess> status)
        {
            
        }
    }
}