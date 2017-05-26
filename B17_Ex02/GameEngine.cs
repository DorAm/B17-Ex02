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
            List<availableItems> generatedSeries = new List<availableItems>();

            Random rnd = new Random();
            for(int i = 0; i < 4; i++)
            {
                int randomNumber = rnd.Next(0, 7); // TODO: change to (0, availableItems.size)
                generatedSeries.Add((availableItems)randomNumber);
            }
        }

       
    }
}
