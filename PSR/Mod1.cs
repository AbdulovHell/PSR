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
        List<SimuMod.Harmonic> harmonics = new List<SimuMod.Harmonic>();
        SimuMod.Harmonic Source=new SimuMod.Harmonic(0);

        public Mod1()
        {
            InitializeComponent();
        }

        private void OscAtG1_Click(object sender, EventArgs e)
        {
            if (!G1Set) return;
            Oscilloscope osc = new Oscilloscope();
            SimuMod.Harmonic harmonic = new SimuMod.Harmonic(50000.0);
            osc.Draw(harmonic.Graphical());
            osc.Show();
        }

        private void OscAtG2_Click(object sender, EventArgs e)
        {
            if (!G2Set) return;
            Oscilloscope osc = new Oscilloscope();
            SimuMod.Harmonic harmonic = new SimuMod.Harmonic(2000.0);
            osc.Draw(harmonic.Graphical());
            osc.Show();
        }

        private void OscAtEnd_Click(object sender, EventArgs e)
        {
            if (!G2Set || !G1Set) return;
            Oscilloscope osc = new Oscilloscope();
            SimuMod.Harmonic harmonic = new SimuMod.Harmonic(2000.0);
            osc.Draw(harmonic.Graphical());
            SimuMod.Harmonic harmonicR = new SimuMod.Harmonic(2000.0, Math.PI);
            osc.Draw(harmonicR.Graphical());
            osc.Show();
        }

        double SpecPeriod(double t, List<SimuMod.Harmonic> harmonics)
        {
            double res = 0;
            //средний уровень огибающей
            double V0 = 0;
            foreach (var h in harmonics)
                V0 += h.Amp;
            V0 /= harmonics.Count;

            for (int i = 0; i < harmonics.Count; i++)
            {
                //коэффициент глубины модуляции
                double Mn = harmonics[i].Amp / V0;
                res += Mn * Math.Cos(harmonics[i].Freq * t + harmonics[i].StaPhase);
            }

            return (res + 1) * V0;
        }

        PSR.Form1.Pair<double[], double[]> Spectrum()
        {
            double[] x = new double[50];
            double[] y = new double[50];
            List<SimuMod.Harmonic> harmonics = new List<SimuMod.Harmonic>();
            harmonics.Add(new SimuMod.Harmonic(2000.0));

            for (int i = x.Length / -2; i < x.Length / 2; i++)
            {
                x[i+x.Length/2] = i;
                y[i+ x.Length / 2] = SpecPeriod(i, harmonics);
            }
            return new PSR.Form1.Pair<double[], double[]>(x, y);
        }

        private void G2SettingsBtn_Click(object sender, EventArgs e)
        {
            HarmonicSettings harmonicSettings = new HarmonicSettings(ref harmonics);
            harmonicSettings.ShowDialog();
            if (harmonics.Count > 0) G2Set = true;
        }

        private void G1SettingsBtn_Click(object sender, EventArgs e)
        {
            SourceSet source = new SourceSet(ref Source);
            source.ShowDialog();
            if (Source != null && Source.Freq != 0) G1Set = true;
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();
            osc.Draw(Spectrum());
            osc.Show();
        }


    }
}
