using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Media;
using System.Threading;

namespace XOR
{
    public enum ReplayTypeEnum { complete, death };

    public partial class FormMain : Form
    {
        static string m_spritePath = "Sprites" + Path.DirectorySeparatorChar;
        static string m_mapPath = "LMaps" + Path.DirectorySeparatorChar;
        static string m_soundPath = "Sounds" + Path.DirectorySeparatorChar;
        int m_currLevel = 15;
        int m_shieldCount = 2;
        WorldArray m_world;
        const int m_worldWidth = 32,
            m_worldHeight = 32;
        const int m_panWidth = 8,
            m_panHeight = 8;
        Shield m_currShield;
        Point m_topLeft = new Point(0, 0);
        int m_eatenMasks = 0;
        bool ended = true;
        MySounds m_mySounds = new MySounds(SoundPath,
               Properties.Settings.Default.PlaySounds);
        const string solution = "L*BF*T?H*ZC*Z*D";
        const int m_maxMoves = 2000;
        Bitmap m_blackBitmap = new Bitmap(m_spritePath + "Black.bmp", false);
        Font m_oldMenuF;
        string m_mainMenuText = "P - Piano\nF - Forte\nL - Level\nSpace - Start\nR - Replay\nI - Info";
        public List<char> m_movesStorage = new List<char>(2000);
        int m_replayStep;
        ReplayTypeEnum m_replayType;
        bool m_movedChick = false,
            m_movedFish = false,
            m_movedHBomb = false,
            m_movedVBomb = false,
            m_movedDoll = false;
        int m_shieldOoops = 0;
        Shield m_oopsingShield = null;


        public static string MapPath
        {
            get { return ExePath + Path.DirectorySeparatorChar + m_mapPath; }
        }

        public static string ExePath
        {
            get { return Path.GetDirectoryName(Application.ExecutablePath); }
        }

        public static string SoundPath
        {
            get { return ExePath + Path.DirectorySeparatorChar + m_soundPath; }
        }


        public static string SpritePath
        {
            get { return ExePath + Path.DirectorySeparatorChar + m_spritePath; }
        }

        public bool AllsQuiet
        {
            get { return !(m_movedChick || m_movedChick || m_movedHBomb || m_movedVBomb || m_movedDoll); }
        }

        public Shield CurrShield
        {
            get { return m_currShield; }
        }

        public ReplayTypeEnum ReplayType
        {
            get { return m_replayType; }
            set { m_replayType = value; }
        }

        public int ReplayStep
        {
            get { return m_replayStep; }
            set { m_replayStep = value; }
        }

        public MySounds MySounds
        {
            get { return m_mySounds; }
            set { m_mySounds = value; }
        }


        public int PanHeight
        {
            get { return m_panHeight; }
        }



        public int PanWidth
        {
            get { return m_panWidth; }
        }


        public WorldArray World
        {
            get { return m_world; }
        }

        public int EatenMasks
        {
            get { return m_eatenMasks; }
            set { m_eatenMasks = value; }
        }
        int m_moves = 0;


        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            maskL.Image = new Bitmap(SpritePath + "Mask.gif", false);
            mainMenuL.Visible = true;
            mainMenuL.Text = "P - Piano\nF - Forte\nI - Info\nL - Level\nSpace - Start";

            LoadLevel(false);
        }


        public static bool IsRunningOnMono()
        {
            return Type.GetType("Mono.Runtime") != null;
        }

        void LoadLevel(bool complete)
        {

            m_world = new WorldArray(m_worldWidth,
                m_worldHeight,
                m_currLevel,
                this,
                complete);

            maxMaskNumL.Text = m_world.MaxMasks.ToString();

            if (complete)
                SwitchShieldTo(typeof(Questor));

            mazeTitleL.Text = m_world.MazeTitle;

        }

        public void InvalidatePanel()
        {
            mainPNL.Invalidate();
        }

        public void InvalidatePanel(int left, int top, int width, int height)
        {
            Rectangle rect = new Rectangle((left - m_topLeft.X) * 48,
                (top - m_topLeft.Y) * 48,
                width * 48,
                height * 48);

            mainPNL.Invalidate(rect);
        }


        public void DecrementShieldCount()
        {
            m_shieldCount--;

            if (m_shieldCount <= 0)
            {
                EndGame(false);
            }
        }


        public void IncrementEatenMasks()
        {
            m_eatenMasks++;
            currMasksNumL.Text = m_eatenMasks.ToString();
        }

        public void IncrementMoves()
        {
            m_moves++;
            moveL.Text = m_moves.ToString();
        }


        public void SwitchShield()
        {
            if (m_currShield != null)
            {
                if (m_currShield is Questor)
                {
                    SwitchShieldTo(typeof(Magus));
                }
                else if (m_currShield is Magus)
                {
                    SwitchShieldTo(typeof(Questor));
                }
            }
        }

        private void SwitchShieldTo(Type t)
        {
            int newtopx, newtopy;

            if (m_shieldCount > 0)
            {
                Point p = m_world.GetShield(t);

                if (!p.IsEmpty)
                {
                    m_currShield = m_world.ElementAt(p.X, p.Y) as Shield;
                    currentShieldL.Image = m_currShield.Tile;
                    newtopx = p.X - m_panWidth / 2;
                    newtopy = p.Y - m_panHeight / 2;

                    if (newtopx < 0) newtopx = 0;
                    if (newtopy < 0) newtopy = 0;

                    if ((newtopx + m_panWidth) > m_worldWidth) newtopx = m_worldWidth - m_panWidth;
                    if ((newtopy + m_panHeight) > m_worldHeight) newtopy = m_worldHeight - m_panHeight;

                    m_topLeft.X = newtopx;
                    m_topLeft.Y = newtopy;

                    mainPNL.Invalidate();
                }
            }


        }



        private void mainPNL_Paint(object sender, PaintEventArgs e)
        {

            Element currel;
            int clleft, clright, cltop, clbottom;

            if (e.ClipRectangle.IsEmpty)
            {
                //e.Graphics.Clear(Color.Black);
                clleft = 0;
                cltop = 0;
                clright = m_panWidth;
                clbottom = m_panHeight;
            }
            else
            {
                clleft = (int)((double)e.ClipRectangle.Left / 48.0);
                clright = (int)Math.Ceiling((double)e.ClipRectangle.Right / 48.0);
                cltop = (int)((double)e.ClipRectangle.Top / 48.0);
                clbottom = (int)Math.Ceiling((double)e.ClipRectangle.Bottom / 48.0);
            }

            if (clright > m_panWidth) clright = m_panWidth;
            if (clbottom > m_panHeight) clbottom = m_panHeight;

            for (int x = clleft; x < clright; x++)
            {
                for (int y = cltop; y < clbottom; y++)
                {
                    currel = m_world.ElementAt(x + m_topLeft.X, y + m_topLeft.Y);
                    if (currel != null)
                    {
                        e.Graphics.DrawImageUnscaled(currel.Tile,
                            x * 48,
                            y * 48);
                    }
                    else
                    {
                        e.Graphics.DrawImageUnscaled(m_blackBitmap,
                            x * 48,
                            y * 48);
                    }

                }
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (ended)
                    {
                        StartGame();
                    }
                    break;
                case Keys.P:
                    //Leiser drehen
                    MySounds.DecreaseVolume();
                    break;
                case Keys.F:
                    //Lauter drehen
                    MySounds.IncreaseVolume();
                    break;
                case Keys.L:
                    if (ended)
                    {
                        m_currLevel--;
                        if (m_currLevel < 1)
                            m_currLevel = 15;

                        LoadLevel(false);
                        mainPNL.Invalidate();
                    }
                    break;
                case Keys.I:
                    if (ended)
                    {
                        FormAbout fab = new FormAbout();
                        fab.Show();
                    }
                    break;
#if DEBUG
                case Keys.Y:
                    FormFullMap ffm = new FormFullMap();
                    ffm.Show(this);
                    break;
                case Keys.X:
                    if (!ended)
                        EndGame(true);
                    break;
                case Keys.G:
                    if (!ended)
                    {
                        m_world.GodModeOn = !m_world.GodModeOn;
                        if (m_world.GodModeOn)
                        {
                            //this.TransparencyKey = Color.Black;
                            this.Opacity = 0.7F;
                        }
                        else
                        {
                            this.Opacity = 1.0F;
                            //this.TransparencyKey = Color.Empty;
                        }
                    }
                    break;

#endif

                case Keys.R:
                    if (ended)
                        StartReplay(ReplayTypeEnum.complete);
                    break;

                case Keys.E:
                    if (!ended)
                        EndGame(false);
                    break;
                case Keys.Return: //switch questor<->magus
                    if (!ended && AllsQuiet)
                    {
                        m_movesStorage.Add('X');
                        SwitchShield();
                    }
                    break;
                case Keys.Down:
                    if (!ended && AllsQuiet && (m_moves < m_maxMoves))
                    {
                        m_movesStorage.Add('D');
                        MoveDown();
                    }
                    break;
                case Keys.Up:
                    if (!ended && AllsQuiet && (m_moves < m_maxMoves))
                    {
                        m_movesStorage.Add('U');
                        MoveUp();
                    }
                    break;
                case Keys.Right:
                    if (!ended && AllsQuiet && (m_moves < m_maxMoves))
                    {
                        m_movesStorage.Add('R');
                        MoveRight();
                    }
                    break;
                case Keys.Left:
                    if (!ended && AllsQuiet && (m_moves < m_maxMoves))
                    {
                        m_movesStorage.Add('L');
                        MoveLeft();
                    }
                    break;
            }
        }

        private void MoveLeft()
        {
            m_world.Move(m_currShield.Px, m_currShield.Py, m_currShield.Px - 1, m_currShield.Py);

            if (!m_world.Beamed)
            {
                if ((m_currShield.Px - m_topLeft.X) == 0)
                {
                    m_topLeft.X--;
                    mainPNL.Invalidate();
                }
            }
            else
                PositionFrame(m_currShield);

            MoveOthers();
        }

        public void OoopsShield(Shield sh)
        {
            m_oopsingShield = sh;
            m_shieldOoops = 10; //let it oops for ten cycles
            m_mySounds.Play(MySounds.XorSound.death);
            World.OoopsAt(sh.Px, sh.Py);
        }

        private void MoveRight()
        {
            m_world.Move(m_currShield.Px, m_currShield.Py, m_currShield.Px + 1, m_currShield.Py);

            if (!m_world.Beamed)
            {
                if ((m_currShield.Px - m_topLeft.X + 1) == m_panWidth)
                {
                    m_topLeft.X++;
                    mainPNL.Invalidate();
                }
            }
            else
                PositionFrame(m_currShield);


            MoveOthers();
        }

        private void MoveUp()
        {
            m_world.Move(m_currShield.Px, m_currShield.Py, m_currShield.Px, m_currShield.Py - 1);

            if (!m_world.Beamed)
            {
                if ((m_currShield.Py - m_topLeft.Y) == 0)
                {
                    m_topLeft.Y--;
                    mainPNL.Invalidate();
                }
            }
            else
                PositionFrame(m_currShield);



            MoveOthers();
        }

        private void MoveDown()
        {
            m_world.Move(m_currShield.Px, m_currShield.Py, m_currShield.Px, m_currShield.Py + 1);

            if (!m_world.Beamed)
            {
                if ((m_currShield.Py - m_topLeft.Y + 1) == m_panHeight)
                {
                    m_topLeft.Y++;
                    mainPNL.Invalidate();
                }
            }
            else
                PositionFrame(m_currShield);

            MoveOthers();
        }

        /// <summary>
        /// Position the open part of the mapp around a shield
        /// </summary>
        /// <param name="s">the shield</param>
        private void PositionFrame(Shield s)
        {
            int topx, topy;

            if (IsOutOfSight(s))
            {
                topx = s.Px % m_panWidth;
                topy = s.Py % m_panHeight;

                m_topLeft.X = (s.Px / m_panWidth) * m_panWidth;
                m_topLeft.Y = (s.Py / m_panHeight) * m_panHeight;

                if (topx == 0)
                    m_topLeft.X--;
                if (topy == 0)
                    m_topLeft.Y--;
                if (topx >= (m_panWidth - 1))
                    m_topLeft.X++;
                if (topy >= (m_panHeight - 1))
                    m_topLeft.Y++;

                if (m_topLeft.X < 0)
                    m_topLeft.X = 0;
                if (m_topLeft.Y < 0)
                    m_topLeft.Y = 0;

                m_world.Beamed = false;

            }

            mainPNL.Invalidate();
        }

        private bool IsOutOfSight(Shield s)
        {
            return (s.Px - m_topLeft.X) < 0
                || ((s.Px - m_topLeft.X + 1) == m_panWidth)
                || (s.Py - m_topLeft.Y) < 0
                || ((s.Py - m_topLeft.Y + 1) == m_panHeight);
        }


        /// <summary>
        /// Move all those self moving things around. The coding looks strange but it 
        /// enforces the movement precedence of chicken over fish, fish over vertical bombs, 
        /// of...
        /// </summary>
        private void MoveOthers()
        {

            m_movedVBomb = m_world.AlleMeineVBoembchen();

            if (m_movedVBomb)
                return;

            m_movedChick = m_world.AlleMeineEntchen();

            if (m_movedChick)
                return;


            m_movedHBomb = m_world.AlleMeineHBoembchen();

            if (m_movedHBomb)
                return;

            m_movedFish = m_world.AlleMeineFischlein();

            if (m_movedFish)
                return;

            m_movedDoll = m_world.AlleMeinePueppchen();



        }

        private void StartGame()
        {
            m_movesStorage.Clear();
            m_shieldCount = 2;

            ended = false;
            mainMenuL.Visible = false;
            m_eatenMasks = 0;
            m_moves = 0;
            moveL.Text = m_moves.ToString();
            currMasksNumL.Text = m_eatenMasks.ToString();
            mapsPanel0.Tag = "-1"; mapsPanel0.Invalidate();
            mapsPanel1.Tag = "-1"; mapsPanel1.Invalidate();
            mapsPanel2.Tag = "-1"; mapsPanel2.Invalidate();
            mapsPanel3.Tag = "-1"; mapsPanel3.Invalidate();

            LoadLevel(true);
            renderTIM.Enabled = true;

        }

        internal void EndGame(bool successful)
        {
            ended = true;

            LoadLevel(true);

            m_topLeft.X = 0;
            m_topLeft.Y = 0;
            mainPNL.Invalidate();
            mainMenuL.Visible = true;

            if (successful)
                RevealALetter();
            else
            {
                mainMenuL.Text = m_mainMenuText;
            }
        }

        private void RevealALetter()
        {
            m_oldMenuF = mainMenuL.Font;
            FontFamily ff = mainMenuL.Font.FontFamily;
            mainMenuL.Text = solution.Substring(15 - m_currLevel, 1);
            mainMenuL.Font = new Font(ff, 80F);

            revealTIM.Enabled = true;
        }

        internal void RevealMap(int revealNum)
        {
            Panel p = null;
            switch (revealNum)
            {
                case 0:
                    p = mapsPanel0;
                    break;
                case 1:
                    p = mapsPanel1;
                    break;
                case 2:
                    p = mapsPanel2;
                    break;
                case 3:
                    p = mapsPanel3;
                    break;

            }

            if (p != null)
                p.Tag = revealNum.ToString();

            p.Invalidate();
        }


        private void mapsPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;

            if ((p.Tag as string) == "-1") return;

            Graphics g = e.Graphics;
            int left = 0, right = 0, top = 0, bottom = 0;

            switch (p.Tag as string)
            {
                case "0":
                    left = 0;
                    top = 0;
                    right = m_worldWidth / 2;
                    bottom = m_worldHeight / 2;
                    break;
                case "1":
                    left = m_worldWidth / 2;
                    top = 0;
                    right = m_worldWidth;
                    bottom = m_worldHeight / 2;
                    break;
                case "2":
                    left = 0;
                    top = m_worldHeight / 2;
                    right = m_worldWidth / 2;
                    bottom = m_worldHeight;
                    break;
                case "3":
                    left = m_worldWidth / 2;
                    top = m_worldHeight / 2;
                    right = m_worldWidth;
                    bottom = m_worldHeight;
                    break;
            }

            Brush wallb = Brushes.Red;
            Brush maskb = Brushes.White;
            Brush doorb = Brushes.Magenta;

            Element el = null;
            for (int x = left; x < right; x++)
            {
                for (int y = top; y < bottom; y++)
                {
                    el = m_world.ElementAt(x, y);
                    if (el is Wall)
                        g.FillRectangle(wallb, (float)((x - left) * 6.25), (float)((y - top) * 6.25), 6.25F, 6.25F);
                    else if (el is Mask)
                        g.FillRectangle(maskb, (float)((x - left) * 6.25), (float)((y - top) * 6.25), 6.25F, 6.25F);
                    else if (el is Door)
                        g.FillRectangle(doorb, (float)((x - left) * 6.25), (float)((y - top) * 6.25), 6.25F, 6.25F);

                }
            }
        }

        internal void InvalidateMaps()
        {
            mapsPanel0.Invalidate();
            mapsPanel1.Invalidate();
            mapsPanel2.Invalidate();
            mapsPanel3.Invalidate();
        }


        internal void PlaybackExplosion()
        {
            m_mySounds.Play(MySounds.XorSound.explode);
        }


        private void revealTIM_Tick(object sender, EventArgs e)
        {
            revealTIM.Enabled = false;
            mainMenuL.Font = m_oldMenuF;
            mainMenuL.Text = m_mainMenuText;
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_mySounds.StopBgMusic();
            revealTIM.Enabled = false;
            replayTIM.Enabled = false;
        }



        public void StartReplay(ReplayTypeEnum repType)
        {
            ReplayType = repType;
            ReplayStep = 0;
            replayTIM.Enabled = true;

            switch (repType)
            {
                case ReplayTypeEnum.complete:
                    mainMenuL.Visible = false;
                    m_eatenMasks = 0;
                    m_shieldCount = 2;
                    m_moves = 0;
                    moveL.Text = m_moves.ToString();
                    currMasksNumL.Text = m_eatenMasks.ToString();
                    mapsPanel0.Tag = "-1"; mapsPanel0.Invalidate();
                    mapsPanel1.Tag = "-1"; mapsPanel1.Invalidate();
                    mapsPanel2.Tag = "-1"; mapsPanel2.Invalidate();
                    mapsPanel3.Tag = "-1"; mapsPanel3.Invalidate();

                    LoadLevel(true);
                    break;
                case ReplayTypeEnum.death:
                    break;

            }
        }


        //Replay next Step when active
        private void replayTIM_Tick(object sender, EventArgs e)
        {
            switch (ReplayType)
            {
                case ReplayTypeEnum.complete:
                    ReplayCompleteStep();
                    break;
                case ReplayTypeEnum.death:
                    break;
            }

            if (!(ReplayStep < m_movesStorage.Count))
            {
                replayTIM.Enabled = false;
                if (ReplayType == ReplayTypeEnum.complete)
                    EndGame(false);
            }
            else
                ReplayStep++;
        }

        private void ReplayCompleteStep()
        {
            if (ReplayStep >= m_movesStorage.Count)
                return;

            char c = m_movesStorage[ReplayStep];

            switch (c)
            {
                case 'U':
                    MoveUp();
                    break;
                case 'D':
                    MoveDown();
                    break;
                case 'L':
                    MoveLeft();
                    break;
                case 'R':
                    MoveRight();
                    break;
                case 'X':
                    SwitchShield();
                    break;
            }
        }

        


        /// <summary>
        /// Main render loop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void renderTIM_Tick(object sender, EventArgs e)
        {
            

            if (m_shieldOoops > 0)
            {
                m_shieldOoops--;

                if (m_shieldOoops == 0)
                {
                    World.EndOoops();
                    DecrementShieldCount();
                    MoveOthers();

                    if(m_currShield==m_oopsingShield)
                        SwitchShield();
                }
            } else
                MoveOthers();


        }
    }
}