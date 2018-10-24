using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using MainModule.Signals;

namespace MainModule
{
    public partial class Mod_AM : UserControl
    {
        bool G1Set = false, G2Set = false;
        const double spacing = 0.0000005;
        List<Harmonic> harmonics = new List<Harmonic>();
        Harmonic Source = new Harmonic(0);

        public Mod_AM()
        {
            InitializeComponent();
            UpdateG1Info();
        }

        private void OscAtG1_Click(object sender, EventArgs e)
        {
            if (!G1Set) return;
            var signal = new SingleToneSignal(Source);
            Oscilloscope osc = new Oscilloscope("ГВЧ", signal);
            osc.DrawOsc();
            osc.DrawSpec();
            osc.DrawPhaseSpec();
            osc.Show();
        }

        private void OscAtG2_Click(object sender, EventArgs e)
        {
            if (!G2Set) return;
            var signal = new MultiToneSignal(harmonics, ProceedInput(KEdit.Text));
            Oscilloscope osc = new Oscilloscope("ГНЧ", signal);
            osc.DrawOsc();
            osc.DrawSpec();
            osc.DrawPhaseSpec();
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
            var signal = new AM(harmonics,Source, ProceedInput(KEdit.Text), ProceedInput(V0Edit.Text));
            Oscilloscope osc = new Oscilloscope("Модулированный сигнал", signal);
            osc.DrawOsc();
            osc.DrawOsc(Oscilloscope.FuncType.Reversed);
            osc.DrawPhaseSpec();
            osc.DrawSpec();
            osc.Show();
        }

        double HarmonicSpec()
        {
            return 1;
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

        private void UpdateG1Info()
        {
            label3.Text = Form1.unitsType == Form1.UnitsType.Radian ? $"Частота = {Source.Freq} Рад/с" : $"Частота = {Source.Freq / (2 * Math.PI)} Гц";
            label4.Text = $"Амплитуда = {Source.Amp} V";
            label5.Text = Form1.unitsType == Form1.UnitsType.Radian ? $"Начальная фаза = {Source.StaPhase} Рад" : $"Начальная фаза = {Source.StaPhase * (180 / Math.PI)} °";
        }

        private void G1SettingsBtn_Click(object sender, EventArgs e)
        {
            SourceSet source = new SourceSet(ref Source);
            source.ShowDialog();
            if (Source != null)
            {
                UpdateG1Info();
                if (Source.Freq != 0) G1Set = true;
            }
        }

        Pair<List<double>,List<double>> Spec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            x.Add(Source.Freq);
            y.Add(Source.Amp);

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(Source.Freq + harmonics[i].Freq);
                x.Add(Source.Freq - harmonics[i].Freq);
                y.Add(harmonics[i].Amp);
                y.Add(harmonics[i].Amp);
            }

            return new Pair<List<double>, List<double>>(x, y);
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            //Oscilloscope osc = new Oscilloscope("Спектр");
            ////osc.Draw(Spectrum());
            //osc.Draw(Spec());
            //osc.Show();
        }


    }
}
