using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace XOR
{
    public partial class FormFullMap : Form
    {
        FormMain MyMainFrm = null;
        public FormFullMap()
        {
            InitializeComponent();
        }

        private void FormFullMap_Load(object sender, EventArgs e)
        {
         
        }

        public void Show(FormMain mainFrm)
        {
            

            this.Owner = mainFrm;
            MyMainFrm = mainFrm;

            this.Show();
        }

        private void mapPNL_Paint(object sender, PaintEventArgs e)
        {
            Element el;
            Graphics g = e.Graphics;

            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    el = MyMainFrm.World.ElementAt(x, y);
                    if (el != null)
                        g.DrawImageUnscaled(el.Tile, x * 48, y * 48);
                }
            }
        }

        private void sichernToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //mapPDOC.DocumentName = f.Titel;
            mapPPD.ShowDialog();
        }

        private void mapPDOC_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Element el;
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle();
            Bitmap black = new Bitmap(".\\Sprites\\Black.bmp");

            rect.Width = 48 / 2;
            rect.Height = 48 / 2;
                     
            for (int x = 0; x < 32; x++)
            {
                for (int y = 0; y < 32; y++)
                {
                    el = MyMainFrm.World.ElementAt(x, y);
                    rect.X = x * 48 / 2;
                    rect.Y = y * 48 / 2;
                     
                    if (el != null)
                    {
                        g.DrawImage(el.Tile, rect);
                    }
                    else
                    {
                        g.DrawImage(black, rect);
                    }
                }
            }
        }
    }
}
