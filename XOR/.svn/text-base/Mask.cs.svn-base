using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Mask: EatPiece
    {
        public Mask()
            : base()
        {
            if(SharedMaskTile==null)
                SharedMaskTile = GetBitmap("Mask.gif");

            Tile = SharedMaskTile;
        }

        public override void Eat()
        {
            MainFrm.IncrementEatenMasks();
            base.Eat();
        }

        public override bool CanBeEaten(Element by)
        {
            return by is Shield; // we can only be eaten by shields
        }
    }
}
