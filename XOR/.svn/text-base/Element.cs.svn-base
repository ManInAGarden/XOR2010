using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


namespace XOR
{
    public abstract class Element
    {
        int m_px, m_py;
        Bitmap m_tile;
        WorldArray m_world;
        FormMain m_mainFrm;
        static Bitmap m_SharedWallTile = null,
            m_SharedFishTile = null,
            m_sharedChickenTile = null,
            m_sharedDollTile = null,
            m_sharedDotsTile = null,
            m_sharedWavesTile = null,
            m_sharedMaskTile = null,
            m_sharedVBombTile = null,
            m_sharedHBombTile = null;

        public static Bitmap SharedHBombTile
        {
            get { return Element.m_sharedHBombTile; }
            set { Element.m_sharedHBombTile = value; }
        }

        public static Bitmap SharedVBombTile
        {
            get { return Element.m_sharedVBombTile; }
            set { Element.m_sharedVBombTile = value; }
        }

        public static Bitmap SharedMaskTile
        {
            get { return Element.m_sharedMaskTile; }
            set { Element.m_sharedMaskTile = value; }
        }

        public static Bitmap SharedWavesTile
        {
            get { return Element.m_sharedWavesTile; }
            set { Element.m_sharedWavesTile = value; }
        }

        public static Bitmap SharedDotsTile
        {
            get { return Element.m_sharedDotsTile; }
            set { Element.m_sharedDotsTile = value; }
        }

        public static Bitmap SharedDollTile
        {
            get { return Element.m_sharedDollTile; }
            set { Element.m_sharedDollTile = value; }
        }

        public static Bitmap SharedChickenTile
        {
            get { return Element.m_sharedChickenTile; }
            set { Element.m_sharedChickenTile = value; }
        }

        public static Bitmap SharedFishTile
        {
            get { return Element.m_SharedFishTile; }
            set { Element.m_SharedFishTile = value; }
        }

        public static Bitmap SharedWallTile
        {
            get { return Element.m_SharedWallTile; }
            set { Element.m_SharedWallTile = value; }
        }

        public FormMain MainFrm
        {
            get { return m_mainFrm; }
            set { m_mainFrm = value; }
        }

        public WorldArray World
        {
            get { return m_world; }
            set { m_world = value; }
        }

        public Bitmap Tile
        {
            get { return m_tile; }
            set { m_tile = value; }
        }

        public int Py
        {
            get { return m_py; }
            set { m_py = value; }
        }

        public int Px
        {
            get { return m_px; }
            set { m_px = value; }
        }



        public virtual void Push(int toX, int toY)
        {
           
        }

        protected Bitmap GetBitmap(string name)
        {
            return new Bitmap(FormMain.SpritePath + name);
        }

        /// <summary>
        /// Can thist tile be moved from the current position to the planned position
        /// </summary>
        /// <param name="toX"></param>
        /// <param name="toY"></param>
        /// <returns></returns>
        public virtual bool CanMoveTo(int toX, int toY)
        {
            //Movement has to be supported by the inheriting class. Will be overwritten for moveable objects
            return false;
        }


        public virtual bool CanBeEaten(Element by)
        {
            return false;
        }

        public virtual void Eat()
        {
            MainFrm.InvalidateMaps();           
        }

        public virtual bool CanBePushed(int fromX, int fromY)
        {
            return false;
        }

        public virtual void Push()
        {
        }

        protected void InvalidateMe()
        {
            MainFrm.InvalidatePanel(m_px, m_py, 1, 1);
        }
    }
}
