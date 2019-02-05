using MainModule.Signals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainModule
{
    public partial class Mod_BM : UserControl
    {
        bool G1Set = false, G2Set = false;
        const double spacing = 0.0000005;
        List<Harmonic> harmonics = new List<Harmonic>();
        Harmonic Source = new Harmonic(0);

        Oscilloscope OG1, OG2, OEnd;

        public Mod_BM()
        {
            InitializeComponent();
            UpdateG1Info();
            FilterKoefLbl.Text = $"Kпн = {FilterKoef.Value / 10.0}";
        }

        void DrawG1Osc( int OscPage = 0)
        {
            if (!G1Set)
            {
                var p = Parent.Parent.Parent as Form1;
                p.SetLastError("Настройки ГВЧ не заданы");
                return;
            }
            var signal = new SingleToneSignal(Source);
            OG1 = new Oscilloscope("ГВЧ", signal, OscPage);
            OG1.DrawOsc();
            OG1.DrawSpec();
            OG1.DrawPhaseSpec();
            OG1.Show();
        }

        private void OscAtG1_Click(object sender, EventArgs e)
        {
            DrawG1Osc();
        }

        void DrawG2Osc(int OscPage = 0)
        {
            if (!G2Set)
            {
                var p = Parent.Parent.Parent as Form1;
                p.SetLastError("Настройки ГНЧ не заданы");
                return;
            }
            var signal = new MultiToneSignal(harmonics, ProceedInput(KEdit.Text));
            OG2 = new Oscilloscope("ГНЧ", signal, OscPage);
            OG2.DrawOsc();
            OG2.DrawSpec();
            OG2.DrawPhaseSpec();
            OG2.Show();
        }

        private void OscAtG2_Click(object sender, EventArgs e)
        {
            DrawG2Osc();
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

        void DrawEndOsc(int OscPage = 0)
        {
            if (!G2Set || !G1Set)
            {
                var p = Parent.Parent.Parent as Form1;
                if (!G1Set) p.SetLastError("Настройки ГВЧ не заданы");
                if (!G2Set) p.SetLastError("Настройки ГНЧ не заданы");
                return;
            }
            var signal = new BM(harmonics, Source, ProceedInput(KEdit.Text), FilterKoef.Value / 10.0);
            OEnd = new Oscilloscope("BМ сигнал", signal, OscPage);
            OEnd.DrawOsc(Oscilloscope.FuncType.Modulated);
            OEnd.DrawPhaseSpec();
            OEnd.DrawSpec();
            OEnd.Show();
        }

        private void OscAtEnd_Click(object sender, EventArgs e)
        {
            DrawEndOsc();
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
            label4.Text = $"Амплитуда = {Source.Amp} В";
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

        private void FilterKoef_ValueChanged(object sender, EventArgs e)
        {
            FilterKoefLbl.Text = $"Kпн = {FilterKoef.Value / 10.0}";
        }

        public void BuildAll(int OscPage)
        {
            DrawG1Osc(OscPage);
            DrawG2Osc(OscPage);
            DrawEndOsc(OscPage);
            //OscBtn_Click(sender, e);
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
            
        }

        private void OscBtn_Click(object sender, EventArgs e)
        {
            //if (!G2Set || !G1Set)
            //{
            //    ErrorWindow errorWindow = new ErrorWindow();
            //    if (!G1Set) errorWindow.AddError("Настройки ГНЧ не заданы");
            //    if (!G2Set) errorWindow.AddError("Настройки ГВЧ не заданы");
            //    errorWindow.ShowDialog();
            //    return;
            //}
            //OSpec = new Oscilloscope("Спектр АМ сигнала");
            ////osc.Draw(Spectrum());
            //OSpec.Draw(Spec());
            //OSpec.Show();
        }


    }
}
