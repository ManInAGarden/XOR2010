namespace XOR
{
    partial class FormDisplayManual
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
            this.manualBrowserWB = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // manualBrowserWB
            // 
            this.manualBrowserWB.AllowNavigation = false;
            this.manualBrowserWB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.manualBrowserWB.Location = new System.Drawing.Point(0, 0);
            this.manualBrowserWB.MinimumSize = new System.Drawing.Size(20, 20);
            this.manualBrowserWB.Name = "manualBrowserWB";
            this.manualBrowserWB.Size = new System.Drawing.Size(794, 431);
            this.manualBrowserWB.TabIndex = 0;
            this.manualBrowserWB.WebBrowserShortcutsEnabled = false;
            // 
            // FormDisplayManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 431);
            this.Controls.Add(this.manualBrowserWB);
            this.Name = "FormDisplayManual";
            this.Text = "XOR Short Manual";
            this.Load += new System.EventHandler(this.FormDisplayManual_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser manualBrowserWB;
    }
}