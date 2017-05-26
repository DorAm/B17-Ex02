using System;
using System.Collections;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class GameEngine : IGameInterface
    {
        // Game Status:

        private int m_NumOfRounds;
        private Dictionary<eGameSymbols, int> m_GeneratedSequence;
        private List<Guess> m_GuessList;
        private List<GuessResult> m_GuessResultList;

        private int m_CurrentRound;
        private Guess m_CurrentGuess;
        private GuessResult m_CurrentGuessResult;
        private bool m_IsVictory;
        private bool m_IsGameOver;

        // Getters
        public bool IsGameOver { get => m_IsGameOver; }
        public bool IsVictory { get => m_IsVictory; }
        public List<Guess> GuessList { get => m_GuessList; }
        public List<GuessResult> GuessResultList { get => m_GuessResultList; }

        // CTOR
        public GameEngine(int i_NumOfRounds)
        {
            this.m_NumOfRounds = i_NumOfRounds;
            this.m_GeneratedSequence = new Dictionary<eGameSymbols, int>();
            this.m_GuessList = new List<Guess>();

            this.m_CurrentRound = 1;
            this.m_CurrentGuess = null;
            this.m_CurrentGuessResult = new GuessResult();
            this.m_IsVictory = false;
            this.m_IsGameOver = false;
        }

        public void StartNewGame()
        {
            this.generateRandomSymbolSeries();
        }

        private void generateRandomSymbolSeries()
        {
            Array symbols = Enum.GetValues(typeof(eGameSymbols));
            int numOfSymbols = symbols.Length;
            Random rand = new Random();

            for (int i = 0; i < GameConfig.GuessLength; i++)
            {
                int randomNum = rand.Next(1, numOfSymbols - 1);
                eGameSymbols randomSymbol = (eGameSymbols)randomNum;
                while (m_GeneratedSequence.ContainsKey(randomSymbol))
                {
                    randomNum = rand.Next(1, numOfSymbols - 1);
                    randomSymbol = (eGameSymbols)randomNum;
                }
                m_GeneratedSequence.Add(randomSymbol, i);
            }
        }

        public void makeGuess(Guess i_UserGuess)
        {
            m_CurrentRound++;
            m_CurrentGuess = i_UserGuess;
            m_GuessList.Add(m_CurrentGuess);
            compareGuess();
            checkVictory();
        }

        // The computer generated sequence is stored as a dictionary
        // key: a generated symbol
        // value: the location of the symbol in the sequence

        private void compareGuess()
        {
            int symbolIndex = 0;
            foreach (eGameSymbols symbol in m_CurrentGuess.GuessAttempt)
            {
                if (m_GeneratedSequence.ContainsKey(symbol))
                {
                    if (m_GeneratedSequence[symbol] == symbolIndex)
                    {
                        this.m_CurrentGuessResult.BulHits++;
                    }
                    else
                    {
                        this.m_CurrentGuessResult.PgiyaHits++;
                    }
                }
            }
        }

        public void checkGameOver()
        {
            m_IsGameOver = m_CurrentRound > m_NumOfRounds;
        }
        public void checkVictory()
        {
            this.m_IsVictory = this.m_CurrentGuessResult.BulHits == GameConfig.GuessLength;
        }

    }
}
