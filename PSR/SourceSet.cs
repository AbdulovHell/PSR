﻿using System;
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
        SimuMod.Harmonic harmonic;

        public SourceSet()
        {
            InitializeComponent();
        }

        public SourceSet(ref SimuMod.Harmonic harmonic)
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
            harmonic.Set(ProceedInput(FreqEd.Text),ProceedInput(PhaseEd.Text) * (Math.PI / 180), ProceedInput(AmpEd.Text));
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
    }
}
