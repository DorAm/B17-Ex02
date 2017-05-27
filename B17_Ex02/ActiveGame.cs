using System;
using System.Collections.Generic;
using System.Text;

namespace B17_Ex02
{
    public class ActiveGame
    {
        public const string k_QuitGame = "Q";
        public const string k_Yes = "Y";

        private IGameInterface m_Game = null;      
        public ActiveGame(int i_MaxNumOfGuesses)
        {
            m_Game = new GameEngine(i_MaxNumOfGuesses);
        }

        public bool PlayGame()
        {
            bool exitGame = false;
            m_Game.StartNewGame();

            while (m_Game.IsGameOver == false && exitGame == false && m_Game.IsVictory == false)
            {
                Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("current board status:");
                printBoard(m_Game.GuessList, m_Game.GuessResultList);
                Console.WriteLine("please enter your guess - 4 different letters or 'Q' to exit");
                string currUserInput = Console.ReadLine();
                currUserInput = currUserInput.ToUpper();
                exitGame = currUserInput == k_QuitGame;
                getUserGuess(currUserInput, ref exitGame);
            }

            Ex02.ConsoleUtils.Screen.Clear();
            printBoard(m_Game.GuessList, m_Game.GuessResultList);
            string userAnswer = finishGameProtocol();
            return userAnswer == k_Yes;
        }

        private string finishGameProtocol()
        {
            if (m_Game.IsGameOver)
            {
                Console.WriteLine("sorry:( you are out of guesses");
            }

            else if (m_Game.IsVictory)
            {
                Console.WriteLine("congragulation! you have won!!!");
            }

            Console.WriteLine("would you like to play another round? press Y for yes");
            string userAnswer = Console.ReadLine();
            return userAnswer = userAnswer.ToUpper();
        }

        private void getUserGuess(string currUserInput, ref bool exitGame)
        {
            bool validUserInput = false;
            while (!exitGame && !validUserInput)
            {
                Guess currentUserGuess = new Guess();

                if ((validUserInput = currentUserGuess.ConvertToGameSymbols(currUserInput)) == false)
                {
                    Console.WriteLine("Invalid Input! please enter your guess - 4 different letters or 'Q' to exit");
                    currUserInput = Console.ReadLine();
                    exitGame = currUserInput == k_QuitGame;
                    continue;
                }
                m_Game.makeGuess(currentUserGuess);
            }
            validUserInput = false;
        }

        private void printBoard(List<Guess> i_GuessList, List<GuessResult> i_Results)
        {
            Console.WriteLine(
@"|Pins:    |Results:|
|=========|========|");

            if (m_Game.GuessList.Count > 0)
            {
                for (int i = 0; i < m_Game.GuessList.Count; i++)
                {
                    printBoardLine(i_GuessList[i]);
                    printBoardLine(i_Results[i]);
                    Console.WriteLine("|=========|========|");
                }
            }

            for (int i = 0; i < m_Game.NumOfRounds - m_Game.GuessList.Count; i++)
            {
                printBoardLine();
                Console.WriteLine("|=========|========|");
            }
        }

        private void printBoardLine(Guess i_Guess)
        {
            StringBuilder myPrintedGuess = new StringBuilder();
            foreach (var item in i_Guess.GuessAttempt)
            {
                myPrintedGuess.Append(" ");
                myPrintedGuess.Append(item.ToString());
            }
            Console.Write(string.Format("|{0} |", myPrintedGuess));
        }

        private void printBoardLine(GuessResult i_GuessResult)
        {
            StringBuilder guessResulString = new StringBuilder(Config.k_GuessLength);

            for (int i = 0; i < i_GuessResult.BulHits; i++)
            {
                guessResulString.Append(" V");
            }

            for (int i = 0; i < i_GuessResult.PgiyaHits; i++)
            {
                guessResulString.Append(" X");
            }

            for (int i = 0; i < Config.k_GuessLength - (i_GuessResult.PgiyaHits + i_GuessResult.BulHits); i++)
            {
                guessResulString.Append("  ");
            }

            Console.WriteLine(string.Format("{0}|", guessResulString));
        }

        private void printBoardLine()
        {
            StringBuilder guessResulString = new StringBuilder(Config.k_GuessLength);
            for (int i = 0; i < Config.k_GuessLength; i++)
            {
                guessResulString.Append(" ");
            }
            Console.WriteLine(string.Format("|   {0}  |   {1} |", guessResulString, guessResulString));
        }
    }
}