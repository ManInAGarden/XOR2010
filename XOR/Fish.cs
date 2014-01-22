using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Fish : MovePiece
    {
        
        public Fish()
            : base()
        {
            if(SharedFishTile==null)
                SharedFishTile = GetBitmap("Fish.gif");

            Tile = SharedFishTile;
        }

        public override bool CanBePushed(int fromX, int fromY)
        {
            int dirx = Px - fromX;
            bool answ = false;

            if (fromY == Py)
            {
                if ((World.ElementAt(Px + dirx, Py) == null))
                    answ = true;
                else if (World.ElementAt(Px + dirx, Py).CanBeEaten(this))
                {
                    answ = true;
                }
            }

            return answ;
        }

        public override void Push(int fromX, int fromY)
        {
            int diry = Py - fromY;
            int dirx = Px - fromX;
            World.MoveRaw(Px, Py, Px + dirx, Py + diry);
            Px += dirx;
            Py += diry;
        }

        public override bool CanMoveTo(int toX, int toY)
        {
            return World.ElementAt(toX, toY) == null;
        }
    }
}
