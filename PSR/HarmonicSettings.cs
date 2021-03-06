﻿using MainModule.Signals;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule
{
    public partial class HarmonicSettings : Form
    {
        List<Harmonic> harmonics;
        Chart PreviewChart = new Chart();

        public HarmonicSettings()
        {
            InitializeComponent();
            InitChart();
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add($"{i + 1}", true, "0", "0", "0");
            }
        }

        public HarmonicSettings(ref List<Harmonic> harmonics)
        {
            InitializeComponent();
            InitChart();
            this.harmonics = harmonics;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < harmonics.Count; i++)
            {
                dataGridView1.Rows.Add($"{i + 1}", true, harmonics[i].Amp.ToString(),
                    (Form1.unitsType == Form1.UnitsType.Radian ? harmonics[i].Freq : harmonics[i].Freq / (2 * Math.PI)).ToString(),
                    (Form1.unitsType == Form1.UnitsType.Radian ? harmonics[i].StaPhase : harmonics[i].StaPhase * (180 / Math.PI)).ToString());
            }
            for (int i = dataGridView1.Rows.Count; i < 10; i++)
            {
                dataGridView1.Rows.Add($"{i + 1}", false, "0", "0", "0");
            }
            ChangeCap();
        }

        void InitChart()
        {
            PreviewChart.Size = new Size(290, 93);
            PreviewChart.Location = new Point(107, 3);
            PreviewChart.ChartAreas.Add("area1");
            PreviewChart.Visible = true;
            this.splitContainer1.Panel2.Controls.Add(this.PreviewChart);
            PreviewChart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            PreviewChart.ChartAreas[0].AxisY.LabelStyle.Enabled = false;
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
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value != null && (bool)dataGridView1.Rows[i].Cells[1].Value == true)
                    {

                        double amp = ProceedInput(dataGridView1.Rows[i].Cells[2].Value);
                        double freq = ProceedInput(dataGridView1.Rows[i].Cells[3].Value);
                        double phase = ProceedInput(dataGridView1.Rows[i].Cells[4].Value);
                        harmonics.Add(new Harmonic(
                            Form1.unitsType == Form1.UnitsType.Radian ? freq : freq * 2 * Math.PI,
                            Form1.unitsType == Form1.UnitsType.Radian ? phase : phase * (Math.PI / 180),
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
            dataGridView1.Rows.Clear();
            double[] amps = { 0, 0.405, 0.318, 0.045, 0.159, 0.016, 0.106, 0.0083, 0.08, 0.005 };
            double[] freqs = { 0, 6.28319, 12.5664, 18.8496, 25.1328, 31.416, 37.6991, 43.9823, 50.2655, 56.5487 };
            double[] phases = { -1.5708, -1.5708, -1.5708, 1.5708, 1.5708, -1.5708, -1.5708, 1.5708, 1.5708, -1.5708 };
            if (Form1.unitsType == Form1.UnitsType.HzGrad)
                for (int i = 0; i < freqs.Length; i++)
                {
                    freqs[i] /= 2 * Math.PI;
                    phases[i] *= 180 / Math.PI;
                }
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows.Add($"{i + 1}", true, amps[i], freqs[i], phases[i]);

            DrawPreview();
        }

        private void ChangeCap()
        {
            dataGridView1.Columns[3].HeaderText = Form1.unitsType == Form1.UnitsType.Radian ? "Частота, рад/с" : "Частота, Гц";
            dataGridView1.Columns[4].HeaderText = Form1.unitsType == Form1.UnitsType.Radian ? "Начальная фаза, рад" : "Начальная фаза, °";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            double[] amps = { 0.5, 0.637, 0, 0.212, 0, 0.127, 0, 0.091, 0, 0.071 };
            double[] freqs = { 0, 6.28319, 12.5664, 18.8496, 25.1328, 31.416, 37.6991, 43.9823, 50.2655, 56.5487 };
            double[] phases = { 0, 0, 0, 3.14159, 3.14159, 0, 0, 3.14159, 3.14159, 0 };
            if (Form1.unitsType == Form1.UnitsType.HzGrad)
                for (int i = 0; i < freqs.Length; i++)
                {
                    freqs[i] /= 2 * Math.PI;
                    phases[i] *= 180 / Math.PI;
                }
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows.Add($"{i + 1}", true, amps[i], freqs[i], phases[i]);

            DrawPreview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            double[] amps = new double[10];
            double[] freqs = { 0, 6.28319, 12.5664, 18.8496, 25.1328, 31.416, 37.6991, 43.9823, 50.2655, 56.5487 };
            double[] phases = new double[10];
            Random rnd = new Random();
            for (int i = 0; i < amps.Length; i++)
            {
                amps[i] = rnd.NextDouble() * 10;
                phases[i] = (rnd.NextDouble() * 2 - 1.0) * Math.PI;
            }
            if (Form1.unitsType == Form1.UnitsType.HzGrad)
                for (int i = 0; i < freqs.Length; i++)
                {
                    freqs[i] /= 2 * Math.PI;
                    phases[i] *= 180 / Math.PI;
                }
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows.Add($"{i + 1}", true, amps[i], freqs[i], phases[i]);

            DrawPreview();
        }

        private void ChangeNames()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = (i + 1).ToString();
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            ChangeNames();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            ChangeNames();
        }

        private void DrawPreview()
        {
            //Stopwatch stopwatch1 = new Stopwatch();
            //Stopwatch stopwatch2 = new Stopwatch();

            //stopwatch1.Start();
            List<Harmonic> temp = new List<Harmonic>();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells[1].Value != null && (bool)dataGridView1.Rows[i].Cells[1].Value == true)
                {

                    double amp = ProceedInput(dataGridView1.Rows[i].Cells[2].Value);
                    double freq = ProceedInput(dataGridView1.Rows[i].Cells[3].Value);
                    double phase = ProceedInput(dataGridView1.Rows[i].Cells[4].Value);
                    temp.Add(new Harmonic(
                            Form1.unitsType == Form1.UnitsType.Radian ? freq : freq * 2 * Math.PI,
                            Form1.unitsType == Form1.UnitsType.Radian ? phase : phase * (Math.PI / 180),
                            amp));
                }
            }
            if (temp.Where(t => t.Freq != 0).Count() == 0) return;
            var painter = new MultiToneSignal(temp, 1);

            PreviewChart.Series.Clear();

            PreviewChart.Series.Add($"Ser{PreviewChart.Series.Count}");
            PreviewChart.Series[PreviewChart.Series.Count - 1].ChartType = SeriesChartType.Spline;
            PreviewChart.Series[PreviewChart.Series.Count - 1].BorderWidth = 1;
            PreviewChart.Series[PreviewChart.Series.Count - 1].Color = Color.Blue;

            var Points = painter.DrawOsc();

            //stopwatch1.Stop();
            //stopwatch2.Start();

            {
                int index = 0;
                for (int i = 0; i < Points.X.Count; i++)
                {
                    if (Points.X[i] != 0 && Points.Y[i] != 0)
                    {
                        index = i;
                        break;
                    }
                }

                int Xunits = Points.X[index].Reduce().Order;
                //var Yunits = ReduceUnits(Points.Y[index]).Y;

                for (int i = 0; i < Points.X.Count; i++)
                {
                    Points.X[i] = Points.X[i].Reorder(-Xunits).Trim();
                    //Points.Y[i] *= Math.Pow(1000, Yunits / 3);
                }
            }

            for (int i = 0; i < Points.X.Count; i++)
            {
                PreviewChart.Series[PreviewChart.Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i]);
            }
            //stopwatch2.Stop();
            //Text =$"{stopwatch1.ElapsedMilliseconds} {stopwatch2.ElapsedMilliseconds}";
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add($"{i + 1}", true, "0", "0", "0");
            }
            ChangeCap();

            DrawPreview();
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == 3 && e.RowIndex == 1)
            //{
            //    if (dataGridView1.Rows[1].Cells[3].Value != null)
            //    {
            //        double freq = ProceedInput(dataGridView1.Rows[1].Cells[3].Value);
            //        for (int i = 2; i < dataGridView1.Rows.Count-1; i++)
            //        {
            //            dataGridView1.Rows[i].Cells[3].Value = freq * (i);
            //        }
            //    }
            //}
            DrawPreview();
        }

        private void TriangleTemplateBtn_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            double[] amps = { 0.1, 0.194, 0.175, 0.147, 0.115, 0.081, 0.051, 0.027, 0.011, 0.002389 };
            double[] freqs = { 0, 1*(2*Math.PI), 2 * (2 * Math.PI), 3 * (2 * Math.PI), 4 * (2 * Math.PI), 5 * (2 * Math.PI), 6 * (2 * Math.PI), 7 * (2 * Math.PI), 8 * (2 * Math.PI), 9 * (2 * Math.PI) };
            double[] phases = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            if (Form1.unitsType == Form1.UnitsType.HzGrad)
                for (int i = 0; i < freqs.Length; i++)
                {
                    freqs[i] /= 2 * Math.PI;
                    phases[i] *= 180 / Math.PI;
                }
            for (int i = 0; i < 10; i++)
                dataGridView1.Rows.Add($"{i + 1}", true, amps[i], freqs[i], phases[i]);

            DrawPreview();
        }
    }
}

