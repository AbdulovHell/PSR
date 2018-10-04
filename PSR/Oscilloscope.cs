using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MainModule
{
    public partial class Oscilloscope : Form
    {
        System.Windows.Forms.DataVisualization.Charting.Chart chart = new System.Windows.Forms.DataVisualization.Charting.Chart();

        public enum DrawMode
        {
            Simple,
            Envelope
        };

        public Oscilloscope()
        {
            InitializeComponent();

            chart.Dock = DockStyle.Fill;
            chart.ChartAreas.Add("area1");
            chart.Visible = true;

            //chart.Series[0].Points.AddXY(25, 44);
            //chart.Series[0].Points.AddXY(55, 60);
            //sinx/x
            //for (int x = -100; x <= 100; x++)
            //    chart.Series[0].Points.AddXY(x, SimuMod.Signals.Sinc(x));

            this.Controls.Add(chart);
        }

        public void Draw(List<double> x, List<double> y)
        {
            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart.Series[chart.Series.Count - 1].BorderWidth = 1;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            for (int i = 0; i < x.Count; i++)
            {
                chart.Series[chart.Series.Count - 1].Points.AddXY(x[i], y[i]);
            }
        }

        double CalcPoint(ref List<SimuMod.Harmonic> harmonics, double t)
        {
            double res = 0;
            for (int i = 0; i < harmonics.Count; i++)
            {
                res += harmonics[i].Amp * Math.Cos(harmonics[i].Freq * t + harmonics[i].StaPhase);
            }
            return res;
        }

        double CalcPoint(ref List<SimuMod.Harmonic> harmonics, double t, double StartPhase)
        {
            double res = 0;
            for (int i = 0; i < harmonics.Count; i++)
            {
                res += harmonics[i].Amp * Math.Cos(harmonics[i].Freq * t + harmonics[i].StaPhase + StartPhase);
            }
            return res;
        }

        public void Draw(List<SimuMod.Harmonic> harmonics, DrawMode drawMode)
        {
            const int Points = 1000;
            const double Time = 1;
            const double StartTime = -0.5;

            double[] x = new double[Points], y = new double[Points];
            double step = Time / Points;

            for (int i = 0; i < x.Length; i++)
            {
                y[i] = CalcPoint(ref harmonics, StartTime + i * step);
                x[i] = StartTime + i * step;
            }

            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = drawMode == DrawMode.Simple ? System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline : System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart.Series[chart.Series.Count - 1].BorderWidth = drawMode == DrawMode.Simple ? 5 : 1;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            for (int i = 0; i < x.Length; i++)
            {
                chart.Series[chart.Series.Count - 1].Points.AddXY(x[i], y[i]);
            }

            if (drawMode == DrawMode.Envelope)
            {
                for (int i = 0; i < x.Length; i++)
                {
                    y[i] = CalcPoint(ref harmonics, StartTime + i * step, Math.PI);
                    x[i] = StartTime + i * step;
                }

                chart.Series.Add($"Ser{chart.Series.Count}");
                chart.Series[chart.Series.Count - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                chart.Series[chart.Series.Count - 1].BorderWidth = 1;
                chart.Series[chart.Series.Count - 1].Color = Color.Blue;

                for (int i = 0; i < x.Length; i++)
                {
                    chart.Series[chart.Series.Count - 1].Points.AddXY(x[i], y[i]);
                }
            }
        }

        public void Draw(PSR.Form1.Pair<double[], double[]> pair)
        {
            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart.Series[chart.Series.Count - 1].BorderWidth = 1;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            for (int i = 0; i < pair.First.Length; i++)
            {
                chart.Series[chart.Series.Count - 1].Points.AddXY(pair.First[i], pair.Second[i]);
            }
        }
    }
}
