using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule
{
    public partial class Oscilloscope : Form
    {
        public enum FuncType
        {
            Normal,
            Reversed
        }

        Chart chart = new Chart();

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

        public void Draw(Painter painter, FuncType funcType = FuncType.Normal)
        {
            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = painter.Type;
            chart.Series[chart.Series.Count - 1].BorderWidth = 1;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            var Points = painter.Draw();

            for (int i = 0; i < Points.First.Length; i++)
            {
                if (funcType == FuncType.Normal)
                    chart.Series[chart.Series.Count - 1].Points.AddXY(Points.First[i], Points.Second[i]);
                else
                    chart.Series[chart.Series.Count - 1].Points.AddXY(Points.First[i], Points.Second[i] * -1);
            }
        }

        Pair<List<double>, List<double>> Sort(Pair<List<double>, List<double>> pair)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            while (pair.First.Count > 0)
            {
                double min = double.PositiveInfinity;
                int index = -1;
                for (int i = 0; i < pair.First.Count; i++)
                {
                    if (min > pair.First[i])
                    {
                        min = pair.First[i];
                        index = i;
                    }
                }
                if (index != -1)
                {
                    x.Add(pair.First[index]);
                    y.Add(pair.Second[index]);
                    pair.First.RemoveAt(index);
                    pair.Second.RemoveAt(index);
                }
                else
                    break;
            }
            return new Pair<List<double>, List<double>>(x, y);
        }

        void DelDupli(ref Pair<List<double>, List<double>> pair)
        {
            bool duplicate = false;
            do
            {
                duplicate = false;
                for (int i = 0; i < pair.First.Count-1; i++)
                {
                    if (pair.First[i] == pair.First[i + 1])
                    {
                        int index = pair.Second[i] < pair.Second[i + 1] ? i : i + 1;
                        pair.First.RemoveAt(index);
                        pair.Second.RemoveAt(index);
                        duplicate = true;
                    }
                }
            } while (duplicate);
        }

        public void Draw(Pair<List<double>, List<double>> pair)
        {
            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = SeriesChartType.Spline;
            chart.Series[chart.Series.Count - 1].BorderWidth = 2;
            chart.Series[chart.Series.Count - 1].Color = Color.Red;

            pair = Sort(pair);
            DelDupli(ref pair);

            for (int i = 0; i < pair.First.Count; i++)
            {
                chart.Series[chart.Series.Count - 1].Points.AddXY(pair.First[i], pair.Second[i]);
            }
        }
    }
}
