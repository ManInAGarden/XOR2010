using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Waves : EatPiece
    {
        public Waves()
            : base()
        {
            if(SharedWavesTile==null)
                SharedWavesTile = GetBitmap("Waves.gif");

            Tile = SharedWavesTile;
        }

        public override bool CanBeEaten(Element by)
        {
            bool answ = false;

            if ((by.Px == Px) && !(by is Doll))
                answ = true;

            return answ;
        }
    }
}
