﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainModule
{
    public partial class Mod_BM : UserControl
    {
        bool G1Set = false, G2Set = false;
        const double spacing = 0.0000005;
        List<MainModule.Harmonic> harmonics = new List<MainModule.Harmonic>();
        MainModule.Harmonic Source = new MainModule.Harmonic(0);

        Oscilloscope OG1, OG2, OEnd, OSpec;

        public Mod_BM()
        {
            InitializeComponent();
            FilterKoefLbl.Text = $"Kпн = {FilterKoef.Value / 10.0}";
        }

        private void OscAtG1_Click(object sender, EventArgs e)
        {
            if (!G1Set)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.AddError("Настройки ГВЧ не заданы");
                errorWindow.ShowDialog();
                return;
            }
            OG1 = new Oscilloscope();
            OG1.Draw(new Painter(Source));
            OG1.Show();
        }

        private void OscAtG2_Click(object sender, EventArgs e)
        {
            if (!G2Set)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.AddError("Настройки ГНЧ не заданы");
                errorWindow.ShowDialog();
                return;
            }
            OG2 = new Oscilloscope();
            OG2.Draw(new Painter(harmonics));
            OG2.Show();
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
            if (!G2Set || !G1Set)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                if (!G1Set) errorWindow.AddError("Настройки ГНЧ не заданы");
                if (!G2Set) errorWindow.AddError("Настройки ГВЧ не заданы");
                errorWindow.ShowDialog();
                return;
            }
            OEnd = new Oscilloscope();
            var painter = new Painter(harmonics, Source, ProceedInput(KEdit.Text), ProceedInput(V0Edit.Text), FilterKoef.Value / 10.0);
            OEnd.Draw(painter);
            OEnd.Draw(painter, Oscilloscope.FuncType.Reversed);
            OEnd.Show();
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

        Pair<List<double>, List<double>> Spec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            x.Add(Source.Freq);
            y.Add(Source.Amp * (FilterKoef.Value / 10.0));

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(Source.Freq + harmonics[i].Freq);
                x.Add(Source.Freq - harmonics[i].Freq);
                double amp = (ProceedInput(KEdit.Text) * harmonics[i].Amp) / 2.0;
                y.Add(amp);
                y.Add(amp);
            }

            return new Pair<List<double>, List<double>>(x, y);
        }

        private void FilterKoef_ValueChanged(object sender, EventArgs e)
        {
            FilterKoefLbl.Text = $"Kпн = {FilterKoef.Value / 10.0}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OscAtG1_Click(sender, e);
            OscAtG2_Click(sender, e);
            OscAtEnd_Click(sender, e);
            OscBtn_Click(sender, e);
            Size resolution = Screen.PrimaryScreen.Bounds.Size;
            Size wndSize = new Size(resolution.Width / 2, resolution.Height / 2);
            if (OG1 != null)
            {
                OG1.Location = new Point(0, 0);
                OG1.Size = wndSize;
            }
            if (OG2 != null)
            {
                OG2.Location = new Point(0, resolution.Height / 2);
                OG2.Size = wndSize;
            }
            if (OEnd != null)
            {
                OEnd.Location = new Point(resolution.Width / 2, 0);
                OEnd.Size = wndSize;
            }
            if (OSpec != null)
            {
                OSpec.Location = new Point(resolution.Width / 2, resolution.Height / 2);
                OSpec.Size = wndSize;
            }
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            if (!G2Set || !G1Set)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                if (!G1Set) errorWindow.AddError("Настройки ГНЧ не заданы");
                if (!G2Set) errorWindow.AddError("Настройки ГВЧ не заданы");
                errorWindow.ShowDialog();
                return;
            }
            OSpec = new Oscilloscope();
            //osc.Draw(Spectrum());
            OSpec.Draw(Spec());
            OSpec.Show();
        }


    }
}