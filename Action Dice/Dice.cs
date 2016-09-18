using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class Dice
    {

        private Random rando = new Random();

        public int roll(int diceSize, int numberOfDice = 1)
        {
            int dieSum = 0;

            for (int i = 0; i<numberOfDice; i++)
            {
                dieSum += (rando.Next() % diceSize) + 1;
            }

            return dieSum;
        }

    }
}
