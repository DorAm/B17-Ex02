using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    
    public interface IGameInterface
    {
        void StartNewGame();
        void makeGuess(Guess i_UserGuess);
        void printSequence();

        int NumOfRounds { get; }
        bool IsGameOver { get; }
        bool IsVictory { get; }        
        List<Guess> GuessList { get; }
        List<GuessResult> GuessResultList { get; }        
    }
}
