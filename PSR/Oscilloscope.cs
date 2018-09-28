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
            chart.Series[chart.Series.Count - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart.Series[chart.Series.Count - 1].BorderWidth = 5;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            for (int i = 0; i < x.Count; i++)
            {
                chart.Series[chart.Series.Count - 1].Points.AddXY(x[i], y[i]);
            }
        }

        public void Draw(PSR.Form1.Pair<double[], double[]> pair)
        {
            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            chart.Series[chart.Series.Count - 1].BorderWidth = 5;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            for (int i = 0; i < pair.First.Length; i++)
            {
                chart.Series[chart.Series.Count - 1].Points.AddXY(pair.First[i], pair.Second[i]);
            }
        }
    }
}
