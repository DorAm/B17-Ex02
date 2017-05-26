using System;

namespace B17_Ex02
{
    public class ActiveGame
    {
        private int m_maxNumOfGuesses;

        public ActiveGame(int maxNumOfGuesses)
        {
            m_maxNumOfGuesses = maxNumOfGuesses;
        }

        public bool PlayGame()
        {
            bool notExit = true;
            bool retVal = true;
<<<<<<< HEAD
            //IGameInterface game = new GameEngine();
            //game.StartNewGame();
=======
            IGameInterface game = new GameEngine();
            game.StartNewGame();
            printBoard(game.getGameStatus());
>>>>>>> 927e95c7109770ebfd0b99933222003482a890ba

            for (int i = 0; i < m_maxNumOfGuesses && notExit; i++)
            {

            }

            return retVal;
        }

        private void printBoard(GameStatus status)
        {
            
        }
    }
}