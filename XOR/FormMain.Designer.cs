namespace XOR
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.mainPNL = new System.Windows.Forms.Panel();
            this.mainMenuL = new System.Windows.Forms.Label();
            this.mazeTitleL = new System.Windows.Forms.Label();
            this.mapsPanel0 = new System.Windows.Forms.Panel();
            this.mapsPanel1 = new System.Windows.Forms.Panel();
            this.mapsPanel2 = new System.Windows.Forms.Panel();
            this.mapsPanel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.mapsGroupP = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.moveL = new System.Windows.Forms.Label();
            this.currentShieldL = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.currMasksNumL = new System.Windows.Forms.Label();
            this.maxMaskNumL = new System.Windows.Forms.Label();
            this.maskL = new System.Windows.Forms.Label();
            this.revealTIM = new System.Windows.Forms.Timer(this.components);
            this.replayTIM = new System.Windows.Forms.Timer(this.components);
            this.renderTIM = new System.Windows.Forms.Timer(this.components);
            this.mainPNL.SuspendLayout();
            this.mapsPanel3.SuspendLayout();
            this.mapsGroupP.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPNL
            // 
            this.mainPNL.BackColor = System.Drawing.Color.Black;
            this.mainPNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mainPNL.Controls.Add(this.mainMenuL);
            this.mainPNL.Location = new System.Drawing.Point(12, 54);
            this.mainPNL.Name = "mainPNL";
            this.mainPNL.Size = new System.Drawing.Size(384, 384);
            this.mainPNL.TabIndex = 0;
            this.mainPNL.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPNL_Paint);
            // 
            // mainMenuL
            // 
            this.mainMenuL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mainMenuL.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainMenuL.ForeColor = System.Drawing.Color.White;
            this.mainMenuL.Location = new System.Drawing.Point(48, 48);
            this.mainMenuL.Name = "mainMenuL";
            this.mainMenuL.Size = new System.Drawing.Size(288, 288);
            this.mainMenuL.TabIndex = 0;
            this.mainMenuL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.mainMenuL.Visible = false;
            // 
            // mazeTitleL
            // 
            this.mazeTitleL.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mazeTitleL.ForeColor = System.Drawing.Color.White;
            this.mazeTitleL.Location = new System.Drawing.Point(13, 13);
            this.mazeTitleL.Name = "mazeTitleL";
            this.mazeTitleL.Size = new System.Drawing.Size(383, 38);
            this.mazeTitleL.TabIndex = 1;
            this.mazeTitleL.Text = "99 Maze Title";
            this.mazeTitleL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mapsPanel0
            // 
            this.mapsPanel0.Location = new System.Drawing.Point(13, 18);
            this.mapsPanel0.Margin = new System.Windows.Forms.Padding(0);
            this.mapsPanel0.Name = "mapsPanel0";
            this.mapsPanel0.Size = new System.Drawing.Size(100, 100);
            this.mapsPanel0.TabIndex = 1;
            this.mapsPanel0.Tag = "-1";
            this.mapsPanel0.Paint += new System.Windows.Forms.PaintEventHandler(this.mapsPanel_Paint);
            // 
            // mapsPanel1
            // 
            this.mapsPanel1.Location = new System.Drawing.Point(113, 18);
            this.mapsPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.mapsPanel1.Name = "mapsPanel1";
            this.mapsPanel1.Size = new System.Drawing.Size(100, 100);
            this.mapsPanel1.TabIndex = 2;
            this.mapsPanel1.Tag = "-1";
            this.mapsPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.mapsPanel_Paint);
            // 
            // mapsPanel2
            // 
            this.mapsPanel2.Location = new System.Drawing.Point(13, 118);
            this.mapsPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.mapsPanel2.Name = "mapsPanel2";
            this.mapsPanel2.Size = new System.Drawing.Size(100, 100);
            this.mapsPanel2.TabIndex = 3;
            this.mapsPanel2.Tag = "-1";
            this.mapsPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.mapsPanel_Paint);
            // 
            // mapsPanel3
            // 
            this.mapsPanel3.Controls.Add(this.panel5);
            this.mapsPanel3.Location = new System.Drawing.Point(113, 118);
            this.mapsPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.mapsPanel3.Name = "mapsPanel3";
            this.mapsPanel3.Size = new System.Drawing.Size(100, 100);
            this.mapsPanel3.TabIndex = 4;
            this.mapsPanel3.Tag = "-1";
            this.mapsPanel3.Paint += new System.Windows.Forms.PaintEventHandler(this.mapsPanel_Paint);
            // 
            // panel5
            // 
            this.panel5.Location = new System.Drawing.Point(97, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(100, 100);
            this.panel5.TabIndex = 5;
            // 
            // mapsGroupP
            // 
            this.mapsGroupP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.mapsGroupP.Controls.Add(this.mapsPanel0);
            this.mapsGroupP.Controls.Add(this.mapsPanel1);
            this.mapsGroupP.Controls.Add(this.mapsPanel3);
            this.mapsGroupP.Controls.Add(this.mapsPanel2);
            this.mapsGroupP.Location = new System.Drawing.Point(409, 54);
            this.mapsGroupP.Name = "mapsGroupP";
            this.mapsGroupP.Size = new System.Drawing.Size(228, 239);
            this.mapsGroupP.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.moveL);
            this.panel1.Controls.Add(this.currentShieldL);
            this.panel1.Location = new System.Drawing.Point(409, 299);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 62);
            this.panel1.TabIndex = 9;
            // 
            // moveL
            // 
            this.moveL.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveL.ForeColor = System.Drawing.Color.White;
            this.moveL.Location = new System.Drawing.Point(76, 4);
            this.moveL.Name = "moveL";
            this.moveL.Size = new System.Drawing.Size(132, 48);
            this.moveL.TabIndex = 1;
            this.moveL.Text = "0";
            this.moveL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // currentShieldL
            // 
            this.currentShieldL.Location = new System.Drawing.Point(11, 4);
            this.currentShieldL.Name = "currentShieldL";
            this.currentShieldL.Size = new System.Drawing.Size(48, 48);
            this.currentShieldL.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.currMasksNumL);
            this.panel2.Controls.Add(this.maxMaskNumL);
            this.panel2.Controls.Add(this.maskL);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(409, 367);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 71);
            this.panel2.TabIndex = 10;
            // 
            // currMasksNumL
            // 
            this.currMasksNumL.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currMasksNumL.ForeColor = System.Drawing.Color.White;
            this.currMasksNumL.Location = new System.Drawing.Point(148, 10);
            this.currMasksNumL.Name = "currMasksNumL";
            this.currMasksNumL.Size = new System.Drawing.Size(60, 48);
            this.currMasksNumL.TabIndex = 2;
            this.currMasksNumL.Text = "0";
            this.currMasksNumL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxMaskNumL
            // 
            this.maxMaskNumL.Font = new System.Drawing.Font("Courier New", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maxMaskNumL.ForeColor = System.Drawing.Color.White;
            this.maxMaskNumL.Location = new System.Drawing.Point(7, 10);
            this.maxMaskNumL.Name = "maxMaskNumL";
            this.maxMaskNumL.Size = new System.Drawing.Size(60, 48);
            this.maxMaskNumL.TabIndex = 1;
            this.maxMaskNumL.Text = "0";
            this.maxMaskNumL.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // maskL
            // 
            this.maskL.Location = new System.Drawing.Point(80, 10);
            this.maskL.Name = "maskL";
            this.maskL.Size = new System.Drawing.Size(48, 48);
            this.maskL.TabIndex = 0;
            // 
            // revealTIM
            // 
            this.revealTIM.Interval = 3000;
            this.revealTIM.Tick += new System.EventHandler(this.revealTIM_Tick);
            // 
            // replayTIM
            // 
            this.replayTIM.Interval = 200;
            this.replayTIM.Tick += new System.EventHandler(this.replayTIM_Tick);
            // 
            // renderTIM
            // 
            this.renderTIM.Tick += new System.EventHandler(this.renderTIM_Tick);
            // 
            // FormMain
            // 
            //this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(650, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mapsGroupP);
            this.Controls.Add(this.mazeTitleL);
            this.Controls.Add(this.mainPNL);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(658, 484);
            this.Name = "FormMain";
            this.Text = "XOR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.mainPNL.ResumeLayout(false);
            this.mapsPanel3.ResumeLayout(false);
            this.mapsGroupP.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPNL;
        private System.Windows.Forms.Label mazeTitleL;
        private System.Windows.Forms.Panel mapsPanel0;
        private System.Windows.Forms.Panel mapsPanel2;
        private System.Windows.Forms.Panel mapsPanel1;
        private System.Windows.Forms.Panel mapsPanel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel mapsGroupP;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label currentShieldL;
        private System.Windows.Forms.Label moveL;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label maskL;
        private System.Windows.Forms.Label currMasksNumL;
        private System.Windows.Forms.Label maxMaskNumL;
        private System.Windows.Forms.Label mainMenuL;
        private System.Windows.Forms.Timer revealTIM;
        private System.Windows.Forms.Timer replayTIM;
        private System.Windows.Forms.Timer renderTIM;
    }
}

