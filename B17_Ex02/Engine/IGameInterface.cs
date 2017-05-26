using System;
using System.Collections.Generic;

namespace B17_Ex02
{

    public interface IGameInterface
    {
        void StartNewGame();
        bool isGameOver();
        void makeGuess(Guess i_UserGuess);

        List<Guess> GuessList { get; }
        

    }
}
