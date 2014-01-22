using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class VBomb : Bomb
    {
        public VBomb()
            : base()
        {
            if(SharedVBombTile==null)
                SharedVBombTile = GetBitmap("VBomb.gif");

            Tile = SharedVBombTile;
        }

        public override void Eat()
        {
            //eating me meams e x p l o d e

            if (Py > 1) // leave outer walls untouched
                World.RemoveAt(Px, Py - 1);

            if (Py < (World.Height - 1)) // leave outer walls untouched
                World.RemoveAt(Px, Py + 1);


            base.Eat();
        }

        public override bool CanMoveTo(int toX, int toY)
        {
            return World.ElementAt(toX, toY) == null;
        }


    }
}
