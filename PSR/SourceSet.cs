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

        public SourceSet()
        {
            InitializeComponent();
        }

        public SourceSet(ref Harmonic harmonic)
        {
            InitializeComponent();
            this.harmonic = harmonic;
            AmpEd.Text = harmonic.Amp.ToString();
            FreqEd.Text = harmonic.Freq.ToString();
            PhaseEd.Text = harmonic.StaPhase.ToString();
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

        void SaveHarmonic()
        {
            double Freq = ProceedInput(FreqEd.Text);
            double Phase = ProceedInput(PhaseEd.Text);
            harmonic.Set(isRadChk.Checked ? Freq : Freq * 2 * Math.PI, isRadChk.Checked ? Phase : Phase * (Math.PI / 180), ProceedInput(AmpEd.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SaveHarmonic();
            this.Close();
        }

        private void SourceSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHarmonic();
        }

        private void isRadChk_CheckedChanged(object sender, EventArgs e)
        {
            if (isRadChk.Checked)
            {
                label1.Text = "Частота, Рад/с";
                label4.Text = "фаза, рад";
            }
            else
            {
                label1.Text = "Частота, Гц";
                label4.Text = "фаза, град";
            }
        }

        private void SourceSet_Load(object sender, EventArgs e)
        {
            isRadChk_CheckedChanged(sender, e);
        }
    }
}
