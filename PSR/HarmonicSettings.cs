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
        bool isRad = true;

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
            for (int i = 0; i < harmonics.Count; i++)
            {
                dataGridView1.Rows.Add($"{i}", true, harmonics[i].Amp.ToString(), harmonics[i].Freq.ToString(), harmonics[i].StaPhase.ToString());
            }
            for (int i = dataGridView1.Rows.Count; i < 10; i++)
            {
                dataGridView1.Rows.Add($"{i}", false, "0", "0", "0");
            }
            ChangeCap();
        }

        private void HarmonicSettings_Load(object sender, EventArgs e)
        {

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

        void SaveHarmonics()
        {
            if (harmonics != null)
            {
                harmonics.Clear();
                for (int i = 0; i < 10; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[1].Value == true)
                    {

                        double amp = ProceedInput(dataGridView1.Rows[i].Cells[2].Value);
                        double freq = ProceedInput(dataGridView1.Rows[i].Cells[3].Value);
                        double phase = ProceedInput(dataGridView1.Rows[i].Cells[4].Value);
                        harmonics.Add(new SimuMod.Harmonic(
                            isRad ? freq : freq * 2 * Math.PI,
                            isRad ? phase : phase * (Math.PI / 180),
                            amp));
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveHarmonics();
            Close();
        }

        private void HarmonicSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            //SaveHarmonics();
        }

        private void SinTemplateBtn_Click(object sender, EventArgs e)
        {
            RadMenuItem_Click(sender, e);
            double[] amps = { 0, 0.405, 0.318, 0.045, 0.159, 0.016, 0.106, 0.0083, 0.08, 0.005 };
            double[] freqs = { 0, 6.28319, 12.5664, 18.8496, 25.1328, 31.416, 37.6991, 43.9823, 50.2655, 56.5487 };
            double[] phases = { -1.5708, -1.5708, -1.5708, 1.5708, 1.5708, -1.5708, -1.5708, 1.5708, 1.5708, -1.5708 };
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows[i].SetValues($"{i}", true, amps[i], freqs[i], phases[i]);
        }

        private void ChangeCap()
        {
            dataGridView1.Columns[3].HeaderText = isRad ? "Частота, рад/с" : "Частота, Гц";
            dataGridView1.Columns[4].HeaderText = isRad ? "Начальная фаза, рад" : "Начальная фаза, °";
        }

        private void RadMenuItem_Click(object sender, EventArgs e)
        {
            if (RadMenuItem.Checked) return;
            isRad = true;
            HzMenuItem.Checked = false;
            RadMenuItem.Checked = true;
            ChangeCap();
        }

        private void HzMenuItem_Click(object sender, EventArgs e)
        {
            if (HzMenuItem.Checked) return;
            isRad = false;
            HzMenuItem.Checked = true;
            RadMenuItem.Checked = false;
            ChangeCap();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RadMenuItem_Click(sender, e);
            double[] amps = { 0.5, 0.637, 0, 0.212, 0, 0.127, 0, 0.091, 0, 0.071 };
            double[] freqs = { 0, 6.28319, 12.5664, 18.8496, 25.1328, 31.416, 37.6991, 43.9823, 50.2655, 56.5487 };
            double[] phases = { 0, 0, 0, 3.14159, 3.14159, 0, 0, 3.14159, 3.14159, 0 };
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows[i].SetValues($"{i}", true, amps[i], freqs[i], phases[i]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RadMenuItem_Click(sender, e);
            double[] amps = new double[10];
            double[] freqs = { 0, 6.28319, 12.5664, 18.8496, 25.1328, 31.416, 37.6991, 43.9823, 50.2655, 56.5487 };
            double[] phases = new double[10];
            Random rnd = new Random();
            for (int i = 0; i < amps.Length; i++)
            {
                amps[i] = rnd.NextDouble() * 10;
                phases[i] = (rnd.NextDouble() * 2 - 1.0) * Math.PI;
            }

            for (int i = 0; i < 10; i++)
                dataGridView1.Rows[i].SetValues($"{i}", true, amps[i], freqs[i], phases[i]);
        }
    }
}
