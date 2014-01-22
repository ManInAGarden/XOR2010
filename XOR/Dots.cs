using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Dots : EatPiece
    {
        public Dots()
            : base()
        {
            if(SharedDotsTile==null)
                SharedDotsTile = GetBitmap("Dots.gif");

            Tile = SharedDotsTile;
        }

        public override bool CanBeEaten(Element by)
        {
            bool answ = false;

            if ((by.Py == Py) && !(by is Doll)) 
                answ = true;

            return answ;
        }
    }
}
