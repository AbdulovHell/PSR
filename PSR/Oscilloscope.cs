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

        public Oscilloscope(string caption)
        {
            InitializeComponent();

            Text = caption;

            chart.Dock = DockStyle.Fill;
            chart.MouseMove += Chart_MouseMove;
            chart.Cursor = Cursors.Cross;
            chart.ChartAreas.Add("area1");

            chart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

            chart.ChartAreas[0].CursorX.IntervalType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].CursorX.Interval = 0.00001;
            chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;

            chart.ChartAreas[0].CursorY.IntervalType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].CursorY.Interval = 0.00001;
            chart.ChartAreas[0].CursorY.IsUserEnabled = true;
            chart.ChartAreas[0].CursorY.AutoScroll = true;

            chart.Visible = true;

            //chart.Series[0].Points.AddXY(25, 44);
            //chart.Series[0].Points.AddXY(55, 60);
            //sinx/x
            //for (int x = -100; x <= 100; x++)
            //    chart.Series[0].Points.AddXY(x, SimuMod.Signals.Sinc(x));

            this.Controls.Add(chart);
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            chart.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            chart.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
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
            
            List<double> temp = new List<double>(Points.First);
            temp.Sort();
            double min = temp[0], max = temp[temp.Count - 1];
            
            chart.ChartAreas[0].AxisX.Interval = Math.Abs(min - max) / 10;
            //chart.ChartAreas[0].AxisX.ScaleView.Position = -0.5;
            //chart.ChartAreas[0].AxisX.ScaleView.Size = 1;
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
                for (int i = 0; i < pair.First.Count - 1; i++)
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
