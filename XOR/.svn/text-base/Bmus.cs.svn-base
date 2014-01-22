using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace XOR
{
    public class Bmus : EatPiece
    {
        public Bmus()
            : base()
        {
            Tile = GetBitmap("BMUS.gif");
        }

        public override bool CanBeEaten(Element by)
        {
            return false;
        }

        internal void CalcBeamTargetCoords(out int mypxto, out int mypyto)
        {
            //search the other Bmus and transform the shield to a place next to it

            Bmus other = World.FindOtherBmus(this);
            int tox = -1, toy = -1;


            if (other != null)
            {
                //find a spare place in clockwise manner starting at 9 o' clock.
                if (World.ElementAt(other.Px - 1, other.Py) == null)
                {
                    tox = other.Px - 1;
                    toy = other.Py;
                }
                else if (World.ElementAt(other.Px + 1, other.Py) == null)
                {
                    tox = other.Px + 1;
                    toy = other.Py;
                }
                else if (World.ElementAt(other.Px, other.Py - 1) == null)
                {
                    tox = other.Px;
                    toy = other.Py - 1;
                }
                else if (World.ElementAt(other.Px, other.Py + 1) == null)
                {
                    tox = other.Px;
                    toy = other.Py + 1;
                }
                else
                    MessageBox.Show("Fehler in der Levelkarte: Kein Platz neben dem Teleporter an " + Px + "," + Py + " gefunden!");

            }
            else
                MessageBox.Show("Fehler in der Levelkarte: zweiter Teleporter gefunden!");


            mypxto = tox;
            mypyto = toy;


        }
    }
}
