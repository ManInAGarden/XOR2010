using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace XOR
{
    public class Wall : Element
    {
        static Bitmap m_darkWallSharedTile = null;

        public static Bitmap DarkWallSharedTile
        {
            get { return Wall.m_darkWallSharedTile; }
            set { Wall.m_darkWallSharedTile = value; }
        }

        public Wall() : base()
        {
            if(SharedWallTile==null)
                SharedWallTile = GetBitmap("Wall.gif");

            if(DarkWallSharedTile==null)
                DarkWallSharedTile = GetBitmap("Black.bmp");

            Tile = SharedWallTile;
        }


        internal void SwitchLight(bool m_lightIsOn)
        {
            if (m_lightIsOn)
                Tile = SharedWallTile;
            else
                Tile = DarkWallSharedTile;

        }
    }
}
