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
        bool G1Set = false, G2Set = false;
        const double spacing = 0.0000005;

        public Mod1()
        {
            InitializeComponent();
        }

        private void OscAtG1_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();

            var point = SimuMod.Signals.SineWave(50000, 20);
            List<double> x, y;
            x = new List<double>();
            y = new List<double>();
            for(int i = 0,j=0; i < point.Length*10; i++)
            {
                x.Add(i*spacing);
                y.Add(point[j++]);
                if (j > point.Length - 1) j = 0;
            }
            osc.Draw(x,y);
            osc.Show();
        }

        private void OscAtG2_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();

            var point = SimuMod.Signals.SineWave(2000, 20);
            List<double> x, y;
            x = new List<double>();
            y = new List<double>();
            for (int i = 0, j = 0; i < point.Length * 10; i++)
            {
                x.Add(i * spacing);
                y.Add(point[j++]);
                if (j > point.Length - 1) j = 0;
            }
            osc.Draw(x, y);
            osc.Show();
        }

        private void OscAtEnd_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();

            {
                var point = SimuMod.Signals.SineWave(2000, 20);
                List<double> x, y;
                x = new List<double>();
                y = new List<double>();
                for (int i = 0, j = 0; i < point.Length * 5+1; i++)
                {
                    x.Add(i);
                    y.Add(point[j++]);
                    if (j > point.Length - 1) j = 0;
                }
                osc.Draw(x, y);
            }
            {
                var point = SimuMod.Signals.SineWave(2000, 20,Math.PI);
                List<double> x, y;
                x = new List<double>();
                y = new List<double>();
                for (int i = 0, j = 0; i < point.Length * 5+1; i++)
                {
                    x.Add(i);
                    y.Add(point[j++]);
                    if (j > point.Length - 1) j = 0;
                }
                osc.Draw(x, y);
            }

            osc.Show();
        }

        double CalcM(int n)
        {
            return 0.5 / 0;
        }

        List<double> Spectrum()
        {
            double V0 = 0;
            List<double> res = new List<double>();
            for(int i = -50; i < 50; i++)
            {
                if (i == 0)
                {
                    res.Add(V0);
                }
                else
                {
                    res.Add((CalcM(i) * V0) / 2.0);
                }
            }
            return res;
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();



            osc.Show();
        }

        
    }
}
