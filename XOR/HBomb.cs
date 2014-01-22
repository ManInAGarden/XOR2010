using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class HBomb : Bomb
    {
        public HBomb()
            : base()
        {
            if(SharedHBombTile==null)
                SharedHBombTile = GetBitmap("HBomb.gif");

            Tile = SharedHBombTile;
        }


        public override void Eat()
        {
            //eating meams e x p l o d e

            if(Px>1) // leave outer walls untouched
                World.RemoveAt(Px - 1, Py);

            if (Px < (World.Width - 1)) // leave outer walls untouched
                World.RemoveAt(Px + 1, Py);

            base.Eat(); //invalidates map
        }

        public override bool CanMoveTo(int toX, int toY)
        {
            return World.ElementAt(toX, toY) == null;
        }
    }
}
