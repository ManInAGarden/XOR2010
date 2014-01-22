using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace XOR
{
    public class WorldArray
    {
        Element[,] m_world;
        string m_mazeTitle;
        int m_maxMasks = 0;
        FormMain m_mainFrm;
        bool m_beamed = false;
        bool m_lightIsOn = true;
        Ooops m_currOoops = null;


        public bool Beamed
        {
            get { return m_beamed; }
            set { m_beamed = value; }
        }

        public FormMain MainFrm
        {
            get { return m_mainFrm; }
            set { m_mainFrm = value; }
        }
        bool m_godModeOn = false;


        public int Width
        {
            get { return m_world.GetLength(0); }
        }

        public int Height
        {
            get { return m_world.GetLength(1); }
        }

        public bool GodModeOn
        {
            get { return m_godModeOn; }
            set { m_godModeOn = value; }
        }

        public int MaxMasks
        {
            get { return m_maxMasks; }
            set { m_maxMasks = value; }
        }

        public string MazeTitle
        {
            get { return m_mazeTitle; }
            set { m_mazeTitle = value; }
        }

        public WorldArray(int sizex, int sizey, int level, FormMain frm, bool complete)
        {
            m_world = new Element[sizex, sizey];
            m_mainFrm = frm;

            ReadLevel(level, frm, complete);
        }

        public Element ElementAt(int px, int py)
        {
            return m_world[px, py];
        }


        public void ReadLevel(int l, FormMain frm, bool complete)
        {
            StreamReader sr = new StreamReader(FormMain.MapPath + l.ToString("d2") + ".txt");
            string line;
            Element el = null;
            int currx = 0, curry = 0;
            int rnum = 0;

            try
            {
                MazeTitle = sr.ReadLine();

                if (!complete)
                {
                    DisplayMenuMap();
                    return;
                }


                while ((line = sr.ReadLine()) != null)
                {
                    currx = 0;
                    foreach (char c in line)
                    {
                        switch (c)
                        {
                            case '#':
                                el = new Wall();
                                break;
                            case '1':
                                el = new Magus();
                                break;
                            case '2':
                                el = new Questor();
                                break;
                            case 'M':
                                el = new Map();
                                (el as Map).RevealNum = rnum;
                                rnum++;
                                break;
                            case 'B':
                                el = new HBomb();
                                break;
                            case 'N':
                                el = new VBomb();
                                break;
                            case '*':
                                el = new Mask();
                                m_maxMasks++;
                                break;
                            case '.':
                                el = new Dots();
                                break;
                            case '~':
                                el = new Waves();
                                break;
                            case 'F':
                                el = new Fish();
                                break;
                            case 'C':
                                el = new Chicken();
                                break;
                            case 'X':
                                el = new Door();
                                break;
                            case 'T':
                                el = new Bmus();
                                break;
                            case 'D':
                                el = new Doll();
                                break;
                            case 'S':
                                el = new Switch();
                                m_maxMasks++;
                                break;
                            default: el = null;
                                break;

                        }

                        if (el != null)
                        {
                            el.Px = currx;
                            el.Py = curry;
                            el.World = this;
                            el.MainFrm = frm;
                        }

                        if (currx < m_world.GetLongLength(0) && curry < m_world.GetLongLength(1))
                            m_world[currx, curry] = el;

                        currx++;
                    }
                    curry++;
                }
            }
            finally
            {
                sr.Close();
            }
        }

        internal Point GetShield(Type t)
        {
            int x = 0;
            int y = 0;
            bool found = false;
            Point pansw = Point.Empty;

            while (!found && (x < m_world.GetLength(0)))
            {
                y = 0;
                while (!found && (y < m_world.GetLength(1)))
                {
                    if (m_world[x, y] != null)
                        found = m_world[x, y].GetType().Name == t.Name;

                    if (found)
                    {
                        pansw = new Point(x, y);
                    }

                    y++;
                }
                x++;
            }

            return pansw;
        }

        internal void Move(int pxFrom, int pyFrom, int pxTo, int pyTo)
        {
            bool doMove = false;
            Element el = m_world[pxFrom, pyFrom];
            if (el == null) return;

            int mypxto = pxTo,
                mypyto = pxFrom;

            if (m_godModeOn || el.CanMoveTo(pxTo, pyTo))
            {
                doMove = true;
            }
            else
            {
                Element inTheWayEl = m_world[pxTo, pyTo];
                if (inTheWayEl != null)
                {
                    if (inTheWayEl.CanBePushed(pxFrom, pyFrom))
                    {
                        inTheWayEl.Push(pxFrom, pyFrom);
                        doMove = true;
                    }
                    else if (inTheWayEl is Bmus)
                    {
                        Bmus beamer = inTheWayEl as Bmus;
                        mypxto = pxFrom;
                        mypyto = pyFrom;
                        beamer.CalcBeamTargetCoords(out mypxto, out mypyto);

                        if (mypxto > 0 && mypyto > 0)
                        {
                            Beam(pxFrom, pyFrom, mypxto, mypyto);
                            m_mainFrm.IncrementMoves();

                            el.Px = mypxto;
                            el.Py = mypyto;
                        }
                        doMove = false;
                    }
                }
            }

            if (doMove)
            {
                MoveRaw(pxFrom, pyFrom, pxTo, pyTo);

                el.Px = pxTo;
                el.Py = pyTo;
                m_mainFrm.IncrementMoves();
            }
        }

        public void MoveRaw(int pxFrom, int pyFrom, int pxTo, int pyTo)
        {
            m_world[pxTo, pyTo] = m_world[pxFrom, pyFrom];
            m_world[pxFrom, pyFrom] = null;
            MainFrm.InvalidatePanel(pxFrom, pyFrom, 1, 1);
            MainFrm.InvalidatePanel(pxTo, pyTo, 1, 1);
        }

        /// <summary>
        /// Move all the chickens which can be moved
        /// </summary>
        /// <returns>true when at leat one chicken moved</returns>
        public bool AlleMeineEntchen() // O.K. wäre eigentlich Hühnchen ich konnte aber nicht widerstehen
        {
            int maxx = m_world.GetLength(0);
            int maxy = m_world.GetLength(1);
            bool didMove = true;
            Chicken chick = null;
            Element elLeftOfChick = null;


            didMove = false;
            for (int x = 0; x < maxx; x++)
            {
                for (int y = 0; y < maxy; y++)
                {
                    if (m_world[x, y] is Chicken)
                    {
                        chick = m_world[x, y] as Chicken;

                        if (x > 0)
                            elLeftOfChick = m_world[x - 1, y];
                        else
                            elLeftOfChick = null;

                        if (chick.Px > 0)
                        {
                            if (chick.CanMoveTo(chick.Px - 1, chick.Py))
                            {
                                MoveRaw(x, y, x - 1, y);
                                chick.Px--;

                                chick.IsMoving = true;
                                didMove = true;

                            }
                            else if ((elLeftOfChick != null) && elLeftOfChick.CanBeEaten(chick))
                            {
                                MoveRaw(x, y, x - 1, y);
                                chick.Px--;

                                elLeftOfChick.Eat();

                                if (elLeftOfChick is Bomb)
                                    m_world[elLeftOfChick.Px, elLeftOfChick.Py] = null;

                                chick.IsMoving = true;
                                didMove = true;
                            }
                            else
                            {
                                chick.IsMoving = false;
                            }

                        }
                    }
                }
            }


            return didMove;
        }

        /// <summary>
        /// Move all the dolls which can be moved
        /// </summary>
        /// <returns>true when at leat one chicken moved</returns>
        public bool AlleMeinePueppchen()
        {
            int maxx = m_world.GetLength(0);
            int maxy = m_world.GetLength(1);
            bool didMove = true;
            Doll doll = null;
            Element elInDolliesWay = null;
            List<Doll> movedDolls = new List<Doll>(5);

            didMove = false;
            for (int x = 0; x < maxx; x++)
            {
                for (int y = 0; y < maxy; y++)
                {
                    if (m_world[x, y] is Doll)
                    {
                        doll = m_world[x, y] as Doll;

                        if (doll.IsMoving && !movedDolls.Contains(doll))
                        {
                            if (((x + doll.RunDirX) > 0) && ((x + doll.RunDirX) < m_world.GetUpperBound(0))
                                && ((y + doll.RunDirY) > 0) && ((y + doll.RunDirY) < m_world.GetUpperBound(1)))
                                elInDolliesWay = m_world[x + doll.RunDirX, y + doll.RunDirY];
                            else
                                elInDolliesWay = null;

                            if ((doll.Px > 0) && (doll.Py > 0) && (doll.Px < (m_world.GetUpperBound(0) - 1) && (doll.Py < (m_world.GetUpperBound(1)))))
                            {
                                if (doll.CanMoveTo(doll.Px + doll.RunDirX, doll.Py + doll.RunDirY))
                                {
                                    MoveRaw(x, y, x + doll.RunDirX, y + doll.RunDirY);
                                    doll.Px += doll.RunDirX;
                                    doll.Py += doll.RunDirY;

                                    doll.IsMoving = true;
                                    movedDolls.Add(doll);
                                    didMove = true;

                                }
                                else if ((elInDolliesWay != null) && elInDolliesWay.CanBeEaten(doll))
                                {
                                    MoveRaw(x, y, x + doll.RunDirX, y + doll.RunDirY);
                                    doll.Px += doll.RunDirX;
                                    doll.Py += doll.RunDirY;

                                    elInDolliesWay.Eat();

                                    if (elInDolliesWay is Bomb)
                                        m_world[elInDolliesWay.Px, elInDolliesWay.Py] = null;

                                    doll.IsMoving = true;
                                    movedDolls.Add(doll);

                                    didMove = true;
                                }
                                else
                                {
                                    doll.IsMoving = false;
                                }

                            }
                        }
                    }
                }
            }


            return didMove;
        }



        /// <summary>
        /// Move all the V-bombs which can be moved
        /// </summary>
        /// <returns>true when at leat one V-bomb moved</returns>
        public bool AlleMeineVBoembchen()
        {
            int maxx = m_world.GetLength(0);
            int maxy = m_world.GetLength(1);
            bool didMove = true;
            VBomb vbomb = null;
            Element elLeftOBomb = null;


            didMove = false;
            for (int x = 0; x < maxx; x++)
            {
                for (int y = maxy - 1; y >= 0; y--) //see moving fish for this strange loop
                {
                    if (m_world[x, y] is VBomb)
                    {
                        vbomb = m_world[x, y] as VBomb;

                        if (x > 0)
                            elLeftOBomb = m_world[x - 1, y];
                        else
                            elLeftOBomb = null;

                        if (vbomb.Px > 0)
                        {
                            if (vbomb.CanMoveTo(vbomb.Px - 1, vbomb.Py))
                            {
                                MoveRaw(x, y, x - 1, y);
                                vbomb.Px--;

                                vbomb.IsMoving = true;
                                didMove = true;

                            }
                            else if ((elLeftOBomb != null) && elLeftOBomb.CanBeEaten(vbomb))
                            {
                                MoveRaw(x, y, x - 1, y);
                                vbomb.Px--;

                                elLeftOBomb.Eat();

                                if (elLeftOBomb is Bomb)
                                    m_world[elLeftOBomb.Px, elLeftOBomb.Py] = null;

                                vbomb.IsMoving = true;
                                didMove = true;
                            }
                            else
                            {
                                vbomb.IsMoving = false;
                            }
                        }
                    }
                }
            }

            return didMove;
        }



        public void DisplayMenuMap()
        {
            for (int x = 0; x < MainFrm.PanWidth; x++)
            {
                for (int y = 0; y < MainFrm.PanHeight; y++)
                {
                    if ((x == 0) || (x == (MainFrm.PanWidth - 1) || (y == 0) || (y == MainFrm.PanHeight - 1)))
                    {
                        m_world[x, y] = new Wall();
                    }
                    else
                        m_world[x, y] = null;
                }
            }

            m_world[10, 10] = new Questor();

        }


        /// <summary>
        /// Move any fhsh that is able to move
        /// </summary>
        /// <returns>true when at least one fish moved</returns>
        public bool AlleMeineFischlein()
        {
            int maxx = m_world.GetLength(0);
            int maxy = m_world.GetLength(1);
            bool didMove = true;
            Fish fish = null;
            Element elUnderFish = null;

            didMove = false;
            for (int x = 0; x < maxx; x++)
            {
                for (int y = maxy-1; y >= 0; y--) // bottom to top prevents moving fish from being found and moved again
                {
                    if (m_world[x, y] is Fish)
                    {
                        fish = m_world[x, y] as Fish;
                        if (y < (maxy - 1))
                            elUnderFish = m_world[x, y + 1];
                        else
                            elUnderFish = null;

                        if (fish.Py < (maxy - 1))
                        {
                            if (fish.CanMoveTo(fish.Px, fish.Py + 1))
                            {
                                MoveRaw(fish.Px, fish.Py, fish.Px, fish.Py + 1);
                                fish.Py++;

                                fish.IsMoving = true;
                                didMove = true;

                            }
                            else if ((elUnderFish != null) && elUnderFish.CanBeEaten(fish))
                            {
                                MoveRaw(x, y, x, y + 1);
                                fish.Py++;

                                elUnderFish.Eat();

                                if (elUnderFish is Bomb)
                                    m_world[elUnderFish.Px, elUnderFish.Py] = null;

                                fish.IsMoving = true;
                                didMove = true;
                            }
                            else
                                fish.IsMoving = false;

                           
                        }
                    }
                }
            }


            return didMove;
        }


        /// <summary>
        /// Move any vertical bomb that is able to move
        /// </summary>
        /// <returns>true when at least one vbomb moved one step</returns>
        public bool AlleMeineHBoembchen()
        {
            int maxx = m_world.GetLength(0);
            int maxy = m_world.GetLength(1);
            bool didMove = true;
            HBomb hbomb = null;
            Element elUnderBomb = null;


            didMove = false;
            for (int x = 0; x < maxx; x++)
            {
                for (int y = 0; y < maxy; y++)
                {
                    if (m_world[x, y] is HBomb)
                    {
                        hbomb = m_world[x, y] as HBomb;
                        if (y < (maxy - 1))
                            elUnderBomb = m_world[x, y + 1];
                        else
                            elUnderBomb = null;

                        if (hbomb.Py < (maxy - 1))
                        {
                            if (hbomb.CanMoveTo(hbomb.Px, hbomb.Py + 1))
                            {
                                MoveRaw(hbomb.Px, hbomb.Py, hbomb.Px, hbomb.Py + 1);
                                hbomb.Py++;

                                hbomb.IsMoving = true;
                                didMove = true;

                            }
                            else if ((elUnderBomb != null) && elUnderBomb.CanBeEaten(hbomb))
                            {
                                MoveRaw(x, y, x, y + 1);
                                hbomb.Py++;

                                elUnderBomb.Eat();

                                if (elUnderBomb is Bomb)
                                    m_world[elUnderBomb.Px, elUnderBomb.Py] = null;

                                hbomb.IsMoving = true;
                                didMove = true;
                            }
                            else
                                hbomb.IsMoving = false;

                            
                        }
                    }
                }
            }


            return didMove;
        }

        internal void RemoveAt(int px, int py)
        {
            Shield sh = m_world[px, py] as Shield;

            if (sh != null)
                sh.Eat();

            m_world[px, py] = null;

            MainFrm.InvalidatePanel(px, py, 1, 1);
        }

        /// <summary>
        /// Find the other bmus (teleporter) and return it to the caller
        /// </summary>
        /// <param name="bmus"></param>
        /// <returns></returns>
        internal Bmus FindOtherBmus(Bmus bmus)
        {
            Bmus answ = null;
            int x = 0, y = 0;

            while ((answ == null) && (x < m_world.GetLength(0)))
            {
                y = 0;
                while ((answ == null) && (y < m_world.GetLength(1)))
                {
                    if ((m_world[x, y] is Bmus) && (m_world[x, y] != bmus))
                        answ = m_world[x, y] as Bmus;

                    y++;
                }

                x++;
            }

            return answ;
        }

        internal void Beam(int fromx, int fromy, int tox, int toy)
        {
            m_world[tox, toy] = m_world[fromx, fromy];
            m_world[fromx, fromy] = null;
            MainFrm.InvalidatePanel(fromx, fromy, 1, 1);
            MainFrm.InvalidatePanel(tox, toy, 1, 1);
            Beamed = true;
        }

        //Flip the switch for the light. Light off means that walls get invisible. Everything else is still visible
        public void SwitchLight()
        {
            Element currEl;

            m_lightIsOn = !m_lightIsOn;

            for (int x = 0; x < m_world.GetLength(0); x++)
            {
                for (int y = 0; y < m_world.GetLength(1); y++)
                {
                    currEl = m_world[x, y];
                    if (currEl is Wall)
                    {
                        (currEl as Wall).SwitchLight(m_lightIsOn);
                    }
                }
            }

            MainFrm.InvalidatePanel();
        }

        internal void OoopsAt(int x, int y)
        {
            m_currOoops = new Ooops();
            m_currOoops.MainFrm = MainFrm;
            m_currOoops.Px = x;
            m_currOoops.Py = y;
            m_world[x, y] = m_currOoops;
            MainFrm.InvalidatePanel(x, y, 1, 1);
        }

        public void EndOoops()
        {
            m_world[m_currOoops.Px, m_currOoops.Py] = null;
            MainFrm.InvalidatePanel(m_currOoops.Px, m_currOoops.Py, 1, 1);
            m_currOoops = null;
        }
    }
}
