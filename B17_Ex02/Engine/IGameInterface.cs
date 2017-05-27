using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public interface IGameInterface
    {
        int NumOfRounds { get; }

        bool IsGameOver { get; }

        bool IsVictory { get; }

        List<Guess> GuessList { get; }

        List<GuessResult> GuessResultList { get; }

        Dictionary<Config.eGameSymbols, int> GeneratedSequence { get; }

        void StartNewGame();

        void makeGuess(Guess i_UserGuess);       
    }
}
