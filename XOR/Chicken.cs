using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Chicken : MovePiece
    {
        public Chicken()
            : base()
        {
            if(SharedChickenTile==null)
                SharedChickenTile = GetBitmap("Chicken.gif");

            Tile = SharedChickenTile;
        }

        public override bool CanBePushed(int fromX, int fromY)
        {
            int diry = Py-fromY;
            bool answ = false;

            if (fromX == Px)
            {
                if (World.ElementAt(Px, Py + diry) == null)
                    answ = true;
                else if (World.ElementAt(Px, Py + diry).CanBeEaten(this))
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
            Element el = null;

            if (World.ElementAt(Px + dirx, Py + diry) != null)
                el = World.ElementAt(Px + dirx, Py + diry);
            
            World.MoveRaw(Px, Py, Px+dirx, Py+diry);

            if(el!=null)
                el.Eat();

            Px += dirx;
            Py += diry;
        }

        public override bool CanMoveTo(int toX, int toY)
        {
            return World.ElementAt(toX, toY) == null;
        }
    }
}
