using System;

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
            //printBoard(m_Game.getGameStatus());

            //for (int i = 0; i < m_maxNumOfGuesses && notExit; i++)
            //{

            //}

            return retVal;
        }

        //private void printBoard(GameStatus status)
        //{
            
        //}
    }
}