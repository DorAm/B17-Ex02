using System;
using System.Collections.Generic;

namespace B17_Ex02
{
    public class GameEngine : IGameInterface
    {

        enum availableItems { c1, c2, c3, c4, c5, c6, c7, c8 };

        availableItems[] generatedString = new availableItems[4];

        items numbers = new int[10];
        items[numbers = new int[10];
        StartNewGame()
        {
           
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
