using System;

namespace Action_Dice
{
    class Dice
    {
        private readonly Random rando = new();

        public int Roll(int diceSize, int numberOfDice = 1)
        {
            int dieSum = 0;

            for (int i = 0; i < numberOfDice; i++)
                dieSum += (rando.Next() % diceSize) + 1;
            return dieSum;
        }
    }
}