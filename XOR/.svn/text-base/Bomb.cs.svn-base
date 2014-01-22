using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Bomb : EatPiece
    {
        bool m_isMoving = false;

        public bool IsMoving
        {
            get { return m_isMoving; }
            set { m_isMoving = value; }
        }

        public Bomb()
            : base()
        {
        }

        public override bool CanBeEaten(Element by)
        {
            bool answ = false;
            MovePiece mp = by as MovePiece;

            if ((mp != null) && (mp.IsMoving && !(mp is Doll)))
                answ = true;
            else
            {
                Bomb bomb = by as Bomb;
                if ((bomb != null) && (bomb.IsMoving))
                    answ = true;
            }

            return answ;
        }

        public override void Eat()
        {
            MainFrm.PlaybackExplosion();
            base.Eat();
        }

        public override bool CanBePushed(int fromX, int fromY)
        {
            int dirx = Px - fromX;
            int diry = Py - fromY;

            Element el = World.ElementAt(Px + dirx, Py + diry);

            return (el==null) || el.CanBeEaten(this);
        }


        public override void Push(int fromX, int fromY)
        {
            int diry = Py - fromY;
            int dirx = Px - fromX;
            Element el = null;

            if (World.ElementAt(Px + dirx, Py + diry) != null)
                el = World.ElementAt(Px + dirx, Py + diry);

            World.MoveRaw(Px, Py, Px + dirx, Py + diry);

            if (el != null)
                el.Eat();

            Px += dirx;
            Py += diry;
        }

    }
}
