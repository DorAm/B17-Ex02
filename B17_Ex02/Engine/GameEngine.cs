﻿using System;
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

        private int m_CurrentRound;
        private Guess m_CurrentGuess;
        private GuessResult m_CurrentGuessResult;      

        // Getters & Setters
        public List<Guess> GuessList { get => m_GuessList; }

        // CTOR
        public GameEngine(int i_NumOfRounds)
        {
            this.m_NumOfRounds = i_NumOfRounds;
            this.m_GeneratedSequence = new Dictionary<eGameSymbols, int>();
            this.m_GuessList = new List<Guess>();

            this.m_CurrentRound = 1;
            this.m_CurrentGuess = null;
            this.m_CurrentGuessResult = new GuessResult();

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
                eGameSymbols randomSymbol = (eGameSymbols) randomNum;
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
            
        }

        // The computer generated sequence is stored as a dictionary
        // key: a generated symbol
        // value: the location of the symbol in the sequence

        private void compareGuess()
        {
            int symbolIndex = 0;
            foreach (eGameSymbols symbol in m_CurrentGuess.Guess)
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

        public bool isGameOver()
        {
            return m_CurrentRound > m_NumOfRounds;
        }

        public bool isVictory()
        {
            
        }

    }
}
