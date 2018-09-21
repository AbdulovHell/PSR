using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MainModule
{
    public partial class Mod1 : UserControl
    {
        public Mod1()
        {
            InitializeComponent();
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();
            osc.Show();
        }
    }
}
