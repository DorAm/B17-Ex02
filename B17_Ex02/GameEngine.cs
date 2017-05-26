using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class GameEngine : IGameInterface
    {

        void IGameInterface.StartNewGame()
        {
            throw new NotImplementedException();
        }

        // TOOD: test this:
        private void RandomizeItems()
        {
            List<eGameSymbols> generatedSeries = new List<eGameSymbols>();

            Array symbols = Enum.GetValues(typeof(eGameSymbols));
            int numOfSymbols = symbols.Length;
            Random rand = new Random();

            for (int i = 0; i < GuessLength; i++)
            {
                int randomNum = rand.Next(1, numOfSymbols - 1);
                eGameSymbols randomSymbol = (eGameSymbols)symbols.GetValue(randomNum);
                generatedSeries.Add(randomSymbol);       
            }
        }


    }
}
