using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class GameEngine : IGameInterface
    {
        // Game Status:
        private int m_NumOfRounds;
        private int m_CurrentRound;
        private List<Guess> m_GuessList;
        private List<eGameSymbols> m_GeneratedSeries;


        // Getters & Setters
        public List<Guess> GuessList { get => m_GuessList; }

        // CTOR
        public GameEngine(int i_NumOfRounds) 
        {
            this.m_NumOfRounds = i_NumOfRounds;
            this.m_CurrentRound = 1;
            this.m_GuessList = new List<Guess>();
            this.m_GeneratedSeries = new List<eGameSymbols>();
        }

        public void StartNewGame()
        {
            this.generateRandomSymbolSeries();
        }

        // TOOD: test this:
        private void generateRandomSymbolSeries()
        {
            Array symbols = Enum.GetValues(typeof(eGameSymbols));
            int numOfSymbols = symbols.Length;
            Random rand = new Random();

            for (int i = 0; i < GameConfig.GuessLength; i++)
            {
                int randomNum = rand.Next(1, numOfSymbols - 1);
                eGameSymbols randomSymbol = (eGameSymbols)symbols.GetValue(randomNum);
                m_GeneratedSeries.Add(randomSymbol);
            }
        }

        public void addGuess() { }

        // TODO: implement checkguess

        public bool isGameOver()
        {
            return m_CurrentRound > m_NumOfRounds;
        }


    }
}
