using System;
using System.Collections.Generic;
using System.Text;

namespace XOR
{
    public class Map : EatPiece
    {
        int revealNum = 0;

        public int RevealNum
        {
            get { return revealNum; }
            set { revealNum = value; }
        }

        public Map()
            : base()
        {
            Tile = GetBitmap("Map.gif");
        }

        public override bool CanBeEaten(Element by)
        {
            return (by is Shield);
        }

        public override void Eat()
        {
            MainFrm.RevealMap(revealNum);
        }
    }
}
