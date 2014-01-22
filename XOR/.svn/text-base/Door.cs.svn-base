using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Door : EatPiece
    {
        public Door()
            : base()
        {
            Tile = GetBitmap("Door.gif");
        }

        public override void Eat()
        {
            MainFrm.EndGame(true);
        }


        public override bool CanBeEaten(Element by)
        {
            return (World.MaxMasks<=MainFrm.EatenMasks) && (by is Shield);
        }
    }
}
