using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XOR
{
    public partial class FormDisplayManual : Form
    {
        public FormDisplayManual()
        {
            InitializeComponent();
        }

        private void FormDisplayManual_Load(object sender, EventArgs e)
        {
            if(!File.Exists("ShortManual.htm"))
                return;

            string uristr = "file://localhost/" + Path.GetFullPath("./ShortManual.htm");
            manualBrowserWB.Url = new Uri(uristr);
            

        }
    }
}
