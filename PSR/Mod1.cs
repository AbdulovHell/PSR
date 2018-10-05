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
        List<MainModule.Harmonic> harmonics = new List<MainModule.Harmonic>();
        MainModule.Harmonic Source = new MainModule.Harmonic(0);

        public Mod1()
        {
            InitializeComponent();
        }

        private void OscAtG1_Click(object sender, EventArgs e)
        {
            if (!G1Set) return;
            Oscilloscope osc = new Oscilloscope();
            osc.Draw(new Painter(Source));
            osc.Show();
        }

        private void OscAtG2_Click(object sender, EventArgs e)
        {
            if (!G2Set) return;
            Oscilloscope osc = new Oscilloscope();
            osc.Draw(new Painter(harmonics));
            osc.Show();
        }

        double ProceedInput(object num)
        {
            if (num.GetType().Name == "Double") return (double)num;

            string num_str = (string)num;

            if (num_str == string.Empty) return 0;

            double res = 0;
            if (!double.TryParse(num_str, out res))
            {
                if (!double.TryParse((num_str).Replace('.', ','), out res))
                {
                    return 0;
                }
                else
                {
                    return res;
                }
            }
            else
            {
                return res;
            }
        }

        private void OscAtEnd_Click(object sender, EventArgs e)
        {
            if (!G2Set || !G1Set) return;
            Oscilloscope osc = new Oscilloscope();
            var painter = new Painter(harmonics, ProceedInput(KEdit.Text), ProceedInput(V0Edit.Text));
            osc.Draw(painter);
            osc.Draw(painter, Oscilloscope.FuncType.Reversed);
            osc.Show();
        }

        double HarmonicSpec()
        {
            return 1;
        }

        List<double> SpecPeriod(double t, List<MainModule.Harmonic> harmonics)
        {
            List<double> y = new List<double>();
            for (int i = -50; i < 51; i++)
            {
                if (i == 0)
                {
                    y.Add(double.Parse(V0Edit.Text));
                }
                else
                {
                    y.Add((double.Parse(KEdit.Text) * HarmonicSpec()) / 2);
                }
            }
            return y;
        }

        Pair<double[], double[]> Spectrum()
        {
            double[] x = new double[50];
            double[] y = new double[50];
            List<MainModule.Harmonic> harmonics = new List<MainModule.Harmonic>();
            harmonics.Add(new MainModule.Harmonic(2000.0));

            for (int i = x.Length / -2; i < x.Length / 2; i++)
            {
                x[i + x.Length / 2] = i;
                y[i + x.Length / 2] = SpecPeriod(i, harmonics)[0];
            }
            return new Pair<double[], double[]>(x, y);
        }

        private void G2SettingsBtn_Click(object sender, EventArgs e)
        {
            HarmonicSettings harmonicSettings = new HarmonicSettings(ref harmonics);
            harmonicSettings.ShowDialog();
            if (harmonics != null)
            {
                HarmonicCountsLbl.Text = $"N = {harmonics.Count}";
                if (harmonics.Count > 0) G2Set = true;
            }
        }

        private void G1SettingsBtn_Click(object sender, EventArgs e)
        {
            SourceSet source = new SourceSet(ref Source);
            source.ShowDialog();
            if (Source != null)
            {
                label3.Text = $"Частота = {Source.Freq} Рад/с";
                label4.Text = $"Амплитуда = {Source.Amp} V";
                label5.Text = $"Начальная фаза = {Source.StaPhase} Рад";
                if (Source.Freq != 0) G1Set = true;
            }
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            Oscilloscope osc = new Oscilloscope();
            //osc.Draw(Spectrum());
            osc.Show();
        }


    }
}
