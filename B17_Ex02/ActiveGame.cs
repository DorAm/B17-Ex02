using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class ActiveGame
    {
        private IGameInterface m_Game = null;

        public ActiveGame(int i_MaxNumOfGuesses)
        {
            m_Game = new GameEngine(i_MaxNumOfGuesses);
        }

        public bool PlayGame()
        {
            bool exit = false; // TODO: change variable name
            bool success = false; // TODO: change variable name
            m_Game.StartNewGame();

            // TODO: change to:
            // while (m_Game.IsGameOver == false && !exit) 
            // GuyRo said he don't like !

            while (!m_Game.IsGameOver && !exit) 
            {
                Console.WriteLine("current board status:\n");
                printBoard(m_Game.GuessList, m_Game.GuessResultList);
                Console.WriteLine("please enter your guess - 4 different letters or 'Q' to exit.\n");
                string currUserInput = Console.ReadLine();
                exit = currUserInput == "Q"; // TODO use constants for Q instead of strings (QUIT_GAME = "Q" ...)

                while (!exit && !success)
                {
                     Guess currentUserGuess = new Guess();
                    if(!(success = currentUserGuess.ConvertToGameSymbols(currUserInput)))
                    {
                        Console.WriteLine("Invalid Input! please enter your guess - 4 different letters or 'Q' to exit.\n"); // TODO - don't use \n for new line (it's not cross platform)
                        currUserInput = Console.ReadLine();
                        exit = currUserInput == "Q";
                        continue;
                    }
                    m_Game.makeGuess(currentUserGuess);
                } 
            }

            printBoard(m_Game.GuessList, m_Game.GuessResultList);

            if(m_Game.IsGameOver)
            {
                Console.WriteLine("sorry:( you are out of guesses\n"); // TODO replace \n
            }

            else if(m_Game.IsVictory)
            {
                Console.WriteLine("congragulation! you have won!!!\n"); // TOOD \n
            }

            Console.WriteLine("would you like to play another round? press Y for yes\n"); // TODO \n
            string userAnswer = Console.ReadLine();
            userAnswer = userAnswer.ToUpper();

            return userAnswer == "Y";
        }

        private void printBoard(List<Guess> i_GuessList, List<GuessResult> i_Results)
        {
            for (int i = 0; i < Config.k_GuessLength; i++)
            {

            }
            
        }

        private void printBoardLine(Guess item)
        {
            string.Format(@"| {0} |");
        }

        private void printBoardLine(GuessResult item)
        {
            string.Format(@"| {0} |");
        }
    }
}