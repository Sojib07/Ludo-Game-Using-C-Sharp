using System;
using System.Collections.Generic;
using System.Text;

namespace ludo
{
    class Dice
    {
        public static int DiceSize { get; set; }
        public Dice(int size)
        {
            DiceSize = size;
        }
        public static int RollDice()
        {
            var rand = new Random();
            return rand.Next(1,DiceSize+1);
        }
    }
}
