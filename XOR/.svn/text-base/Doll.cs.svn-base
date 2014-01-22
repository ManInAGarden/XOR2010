using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Doll : MovePiece
    {
        int m_runDirX, m_runDirY;

        public int RunDirY
        {
            get { return m_runDirY; }
            set { m_runDirY = value; }
        }

        public int RunDirX
        {
            get { return m_runDirX; }
            set { m_runDirX = value; }
        }


        public Doll() : base()
        {
            if(SharedDollTile==null)
                SharedDollTile = GetBitmap("Doll.gif");

            Tile = SharedDollTile;
        }

        public override bool CanBePushed(int fromX, int fromY)
        {
            int dirx = Px - fromX;
            int diry = Py - fromY;
            Element el = World.ElementAt(Px + dirx, Py + diry);
            
            return (el==null) || (el.CanBeEaten(this));
        }

        public override void Push(int fromX, int fromY)
        {
            RunDirY = Py - fromY;
            RunDirX = Px - fromX;
            Element el = null;

            if (World.ElementAt(Px + RunDirX, Py + RunDirY) != null)
                el = World.ElementAt(Px + RunDirX, Py + RunDirY);

            World.MoveRaw(Px, Py, Px + RunDirX, Py + RunDirY);

            if (el != null)
                el.Eat();

            Px += RunDirX;
            Py += RunDirY;

            IsMoving = true; //start dollies run here until dollie hits a wall
        }

        public override bool CanMoveTo(int toX, int toY)
        {
            Element el = World.ElementAt(Px + RunDirX, Py + RunDirY);

            return IsMoving && ((el == null) || (el.CanBeEaten(this)));
        }
    }
}
