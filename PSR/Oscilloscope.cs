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
        string Units = "";

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
            if (Form1.EnCursors) chart.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart.ChartAreas[0].CursorX.AutoScroll = true;

            chart.ChartAreas[0].CursorY.IntervalType = DateTimeIntervalType.Auto;
            chart.ChartAreas[0].CursorY.Interval = 0.00001;
            if (Form1.EnCursors) chart.ChartAreas[0].CursorY.IsUserEnabled = true;
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
            if (!Form1.EnCursors) return;
            chart.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            chart.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            chart.ChartAreas[0].AxisX.Title = chart.ChartAreas[0].CursorX.Position.ToString() + " " + Units;
            chart.ChartAreas[0].AxisY.Title = chart.ChartAreas[0].CursorY.Position.ToString() + " В";
        }

        private Pair<double, int> ReduceUnits(double number)
        {
            int Reduces = 0;
            bool isBelowZero = number < 0;
            if (isBelowZero) number = Math.Abs(number);
            int units = 0;
            while (number < 0.1 && number != 0)
            {
                number *= 1000;
                Reduces++;
            }

            units = Reduces * 3;

            return new Pair<double, int>(number * (isBelowZero ? -1 : 1), units);
        }

        private double ReduceUnits(double number, int units)
        {
            int Reduces = 0;
            bool isBelowZero = number < 0;
            if (isBelowZero) number = Math.Abs(number);
            while (number < 0.1 && number != 0)
            {
                number *= 1000;
                Reduces++;
                if (Reduces * 3 >= units) break;
            }
            return number * (isBelowZero ? -1 : 1);
        }

        double Trim(double num, int order = 5)
        {
            return ((int)(num * Math.Pow(10, order))) / Math.Pow(10, order);
        }

        public void Draw(Painter painter, FuncType funcType = FuncType.Normal)
        {
            chart.Series.Add($"Ser{chart.Series.Count}");
            chart.Series[chart.Series.Count - 1].ChartType = painter.Type;
            chart.Series[chart.Series.Count - 1].BorderWidth = 1;
            chart.Series[chart.Series.Count - 1].Color = Color.Blue;

            var Points = painter.Draw();

            {
                int index = 0;
                for (int i = 0; i < Points.First.Length; i++)
                {
                    if (Points.First[i] != 0 && Points.Second[i] != 0)
                    {
                        index = i;
                        break;
                    }
                }

                var Xunits = ReduceUnits(Points.First[index]).Second;
                //var Yunits = ReduceUnits(Points.Second[index]).Second;
                switch (Xunits / 3)
                {
                    case 0:
                        Units = "с";
                        break;
                    case 1:
                        Units = "мс";
                        break;
                    case 2:
                        Units = "мкс";
                        break;
                    case 3:
                        Units = "нс";
                        break;
                    case 4:
                        Units = "пс";
                        break;
                    default:
                        Units = "с";
                        break;
                }

                for (int i = 0; i < Points.First.Length; i++)
                {
                    Points.First[i] = Trim(Points.First[i] * Math.Pow(1000, Xunits / 3));
                    //Points.Second[i] *= Math.Pow(1000, Yunits / 3);
                }
            }

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
        /// <summary>
        /// Сортировка по времени
        /// </summary>
        /// <param name="pair">Массив пар X Y</param>
        /// <returns>Сортированный массив</returns>
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
        /// <summary>
        /// Удаление (или складывать?) низших кармоник, накладывающихся по времени друг на друга
        /// </summary>
        /// <param name="pair">Массив пар X Y</param>
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
