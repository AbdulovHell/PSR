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
    public partial class HarmonicSettings : Form
    {
        List<SimuMod.Harmonic> harmonics;

        public HarmonicSettings()
        {
            InitializeComponent();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add($"{i}", true, "0", "0", "0");
            }
        }

        public HarmonicSettings(ref List<SimuMod.Harmonic> harmonics)
        {
            InitializeComponent();
            this.harmonics = harmonics;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add($"{i}", true, "0", "0", "0");
            }
        }

        private void HarmonicSettings_Load(object sender, EventArgs e)
        {

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

        void SaveHarmonics()
        {
            if (harmonics != null)
            {
                harmonics.Clear();
                for (int i = 0; i < 10; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                    {
                        double freq = ProceedInput((string)dataGridView1.Rows[i].Cells[2].Value);
                        double amp = ProceedInput((string)dataGridView1.Rows[i].Cells[3].Value);
                        double phase = ProceedInput((string)dataGridView1.Rows[i].Cells[4].Value);
                        harmonics.Add(new SimuMod.Harmonic(freq, phase, amp));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveHarmonics();
        }

        private void HarmonicSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveHarmonics();
        }
    }
}
