using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGameKata
{
    public class BowlingGame
    {
        private int[] rolls = new int [21];
        private int currentRoll = 0;

        public BowlingGame()
        {
        }

        public void roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int score()
        {
            var score = 0;
            var index = 0;
            for (int frame = 0; frame < 10; frame++ ) // loop through each frame
            {
                if (isStrike(index)) //strike
                {
                    score += 10 + rolls[index + 1] + rolls[index + 2];
                    index++;
                }
                else if (isSpare(index)) //spare
                {
                    score += 10 + rolls[index + 2];
                    index += 2;
                }
                else
                {
                    score += rolls[index] + rolls[index + 1];
                    index += 2;
                }
            }
            return score;
        }

        private bool isSpare(int index)
        {
            return (rolls[index] + rolls[index + 1]) == 10;
        }

        private bool isStrike(int index)
        {
            return rolls[index] == 10;
        }

        static void Main()
        {
        }
    }
}
