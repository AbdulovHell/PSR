using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MainModule
{
    public partial class SourceSet : Form
    {
        Harmonic harmonic;

        public SourceSet(ref Harmonic harmonic)
        {
            InitializeComponent();
            this.harmonic = harmonic;
            
            if (Form1.unitsType == Form1.UnitsType.Radian)
            {
                label1.Text = "Частота, Рад/с";
                label4.Text = "фаза, рад";
                AmpEd.Text = harmonic.Amp.ToString();
                FreqEd.Text = harmonic.Freq.ToString();
                PhaseEd.Text = harmonic.StaPhase.ToString();
            }
            else
            {
                label1.Text = "Частота, Гц";
                label4.Text = "фаза, град";
                AmpEd.Text = harmonic.Amp.ToString();
                FreqEd.Text = (harmonic.Freq/(2*Math.PI)).ToString();
                PhaseEd.Text = (harmonic.StaPhase*(180/Math.PI)).ToString();
            }
        }

        double ProceedInput(string num)
        {
            double res = 0;
            if (num == string.Empty) return res;
            if (!double.TryParse(num, out res))
            {
                if (!double.TryParse(num.Replace('.', ','), out res))
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

        bool SaveHarmonic()
        {
            double Freq = ProceedInput(FreqEd.Text);
            double Phase = ProceedInput(PhaseEd.Text);
            if (Freq <= 0e1 || Freq > 1e9)
            {
                ErrorWindow errorWindow = new ErrorWindow();
                errorWindow.AddError("Ошибка задания частоты, она должна находится в пределах 0 < Freq <= 1e9");
                errorWindow.ShowDialog();
                return false;
            }
            else
            {
                harmonic.Set(Form1.unitsType == Form1.UnitsType.Radian ? Freq : Freq * 2 * Math.PI,
                    Form1.unitsType == Form1.UnitsType.Radian ? Phase : Phase * (Math.PI / 180),
                    ProceedInput(AmpEd.Text));
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (SaveHarmonic())
                this.Close();
        }

        private void SourceSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveHarmonic();
        }
    }
}
