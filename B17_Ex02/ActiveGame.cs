using System;
using System.Collections.Generic;
using System.Text;

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

            while(!m_Game.IsGameOver && !exit)
            {
                Console.WriteLine("current board status:\n");
                printBoard(m_Game.GuessList, m_Game.GuessResultList);
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
                    m_Game.makeGuess(currentUserGuess);
                } 
            }

            printBoard(m_Game.GuessList, m_Game.GuessResultList);

            if(m_Game.IsGameOver)
            {
                Console.WriteLine("sorry:( you are out of guesses\n");
            }

            else if(m_Game.IsVictory)
            {
                Console.WriteLine("congragulation! you have won!!!\n");
            }

            Console.WriteLine("would you like to play another round? press Y for yes\n");
            string userAnswer = Console.ReadLine();
            userAnswer = userAnswer.ToUpper();

            return userAnswer == "Y";
        }

        private void printBoard(List<Guess> i_GuessList, List<GuessResult> i_Results)
        {
            for (int i = 0; i < GameConfig.GuessLength; i++)
            {

            }
            
        }

        private void printBoardLine(Guess i_Guess)
        {
            string.Format("| {0} |", i_Guess.GuessAttempt.ToString());
        }

        private void printBoardLine(GuessResult i_GuessResult)
        {
            StringBuilder guessResulString = new StringBuilder(GameConfig.GuessLength);

            for (int i = 0; i < i_GuessResult.BulHits; i++)
            {
                guessResulString.Append("V");
            }

            for (int i = 0; i < i_GuessResult.PgiyaHits; i++)
            {
                guessResulString.Append("X");
            }

            for (int i = 0; i < GameConfig.GuessLength - (i_GuessResult.PgiyaHits + i_GuessResult.BulHits); i++)
            {
                guessResulString.Append(" ");
            }

            string.Format("| {0} |\n", guessResulString);
        }

        private void printBoardLine()
        {
            StringBuilder guessResulString = new StringBuilder(GameConfig.GuessLength);
            for (int i = 0; i < GameConfig.GuessLength; i++)
            {
                guessResulString.Append(" ");
            }
            string.Format("| {0} |\n", guessResulString);
        }
    }
}