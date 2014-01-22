using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Switch : EatPiece
    {

        public Switch()
            : base()
        {
            //Tile = GetBitmap("Switch.gif");
            Tile = GetBitmap("SadMask.bmp");
        }

        public override bool CanBeEaten(Element by)
        {
            return (by is Shield);
        }

        public override void Eat()
        {
            World.SwitchLight();
            MainFrm.IncrementEatenMasks();
            base.Eat();
        }
    }
}
