using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class EatPiece : Element
    {
        public EatPiece() : base() { }


        public override bool CanBeEaten(Element by)
        {
            return true;
        }

        public override void Eat()
        {
            base.Eat();
        }

    }
}
