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

        Chart[] Charts = new Chart[3];
        Signals.ISignal signal;
        string Units = "";

        void InitCharts()
        {
            for (int i = 0; i < 3; i++)
            {
                Charts[i] = new Chart();
                Charts[i].Dock = DockStyle.Fill;
                Charts[i].MouseMove += Chart_MouseMove;
                Charts[i].Cursor = Cursors.Cross;
                Charts[i].ChartAreas.Add("area1");

                Charts[i].ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
                Charts[i].ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;

                Charts[i].ChartAreas[0].CursorX.Interval = 0.00001;
                if (Form1.EnCursors) Charts[i].ChartAreas[0].CursorX.IsUserEnabled = true;
                Charts[i].ChartAreas[0].CursorX.AutoScroll = true;

                Charts[i].ChartAreas[0].CursorY.Interval = 0.00001;
                if (Form1.EnCursors) Charts[i].ChartAreas[0].CursorY.IsUserEnabled = true;
                Charts[i].ChartAreas[0].CursorY.AutoScroll = true;

                Charts[i].Visible = true;
            }
            splitContainer1.Panel1.Controls.Add(Charts[0]);
            splitContainer2.Panel1.Controls.Add(Charts[1]);
            splitContainer3.Panel1.Controls.Add(Charts[2]);
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Form1.EnCursors) return;
            if (sender.GetType().ToString() != "System.Windows.Forms.DataVisualization.Charting.Chart") return;
            Chart chart = (Chart)sender;
            chart.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            chart.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            chart.ChartAreas[0].AxisX.Title = chart.ChartAreas[0].CursorX.Position.ToString() + " " + Units;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    chart.ChartAreas[0].AxisY.Title = chart.ChartAreas[0].CursorY.Position.ToString() + " В";
                    break;
                case 1:
                    chart.ChartAreas[0].AxisY.Title = chart.ChartAreas[0].CursorY.Position.ToString() + " дБ?";
                    break;
                case 2:
                    chart.ChartAreas[0].AxisY.Title = chart.ChartAreas[0].CursorY.Position.ToString() + " град";
                    break;
            }
        }

        public Oscilloscope(string caption, Signals.ISignal signal,int tabIndex=0)
        {
            InitializeComponent();
            Text = caption;
            InitCharts();
            this.signal = signal;
            tabControl1.SelectedIndex = tabIndex;
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

        public void DrawOsc(FuncType funcType = FuncType.Normal)
        {
            Charts[0].Series.Add($"Ser{Charts[0].Series.Count}");
            Charts[0].Series[Charts[0].Series.Count - 1].ChartType = signal.OscType();
            Charts[0].Series[Charts[0].Series.Count - 1].BorderWidth = 1;
            Charts[0].Series[Charts[0].Series.Count - 1].Color = Color.Blue;

            signal.SetPeriods(int.Parse(PeriodsText.Text));
            var Points = signal.DrawOsc();

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

                var Xunits = ReduceUnits(Points.X[index]).Second;
                //var Yunits = ReduceUnits(Points.Y[index]).Y;
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

                for (int i = 0; i < Points.X.Count; i++)
                {
                    Points.X[i] = Trim(Points.X[i] * Math.Pow(1000, Xunits / 3));
                    //Points.Y[i] *= Math.Pow(1000, Yunits / 3);
                }
            }

            for (int i = 0; i < Points.X.Count; i++)
            {
                if (funcType == FuncType.Normal)
                    Charts[0].Series[Charts[0].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i]);
                else
                    Charts[0].Series[Charts[0].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i] * -1);
            }

            List<double> temp = new List<double>(Points.X);
            temp.Sort();
            double min = temp[0], max = temp[temp.Count - 1];

            Charts[0].ChartAreas[0].AxisX.Interval = Math.Abs(min - max) / 10;
            //chart.ChartAreas[0].AxisX.ScaleView.Position = -0.5;
            //chart.ChartAreas[0].AxisX.ScaleView.Size = 1;
        }
        /// <summary>
        /// Сортировка по времени
        /// </summary>
        /// <param name="pair">Массив пар X Y</param>
        /// <returns>Сортированный массив</returns>
        Signals.CoordPair Sort(Signals.CoordPair pair)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            while (pair.X.Count > 0)
            {
                double min = double.PositiveInfinity;
                int index = -1;
                for (int i = 0; i < pair.X.Count; i++)
                {
                    if (min > pair.X[i])
                    {
                        min = pair.X[i];
                        index = i;
                    }
                }
                if (index != -1)
                {
                    x.Add(pair.X[index]);
                    y.Add(pair.Y[index]);
                    pair.X.RemoveAt(index);
                    pair.Y.RemoveAt(index);
                }
                else
                    break;
            }
            return new Signals.CoordPair(x, y);
        }
        /// <summary>
        /// Удаление (или складывать?) низших кармоник, накладывающихся по времени друг на друга
        /// </summary>
        /// <param name="pair">Массив пар X Y</param>
        void DelDupli(ref Signals.CoordPair pair)
        {
            bool duplicate = false;
            do
            {
                duplicate = false;
                for (int i = 0; i < pair.X.Count - 1; i++)
                {
                    if (pair.X[i] == pair.X[i + 1])
                    {
                        int index = pair.Y[i] < pair.Y[i + 1] ? i : i + 1;
                        pair.X.RemoveAt(index);
                        pair.Y.RemoveAt(index);
                        duplicate = true;
                    }
                }
            } while (duplicate);
        }

        public void DrawSpec()
        {
            Charts[1].Series.Add($"Ser{Charts[1].Series.Count}");
            Charts[1].Series[Charts[1].Series.Count - 1].ChartType = signal.AmpSpecType();
            Charts[1].Series[Charts[1].Series.Count - 1].BorderWidth = 2;
            Charts[1].Series[Charts[1].Series.Count - 1].Color = Color.Red;

            signal.SetFreqSpan(1e3);
            var pair = signal.DrawAmpSpec();
            pair = Sort(pair);
            DelDupli(ref pair);

            for (int i = 0; i < pair.X.Count; i++)
            {
                Charts[1].Series[Charts[1].Series.Count - 1].Points.AddXY(pair.X[i], pair.Y[i]);
            }
        }

        public void DrawPhaseSpec()
        {
            Charts[2].Series.Add($"Ser{Charts[2].Series.Count}");
            Charts[2].Series[Charts[2].Series.Count - 1].ChartType = signal.PhaseSpecType();
            Charts[2].Series[Charts[2].Series.Count - 1].BorderWidth = 2;
            Charts[2].Series[Charts[2].Series.Count - 1].Color = Color.Red;

            signal.SetPhaseSpan(1e3);
            var pair = signal.DrawPhaSpec();
            pair = Sort(pair);
            DelDupli(ref pair);

            for (int i = 0; i < pair.X.Count; i++)
            {
                Charts[2].Series[Charts[2].Series.Count - 1].Points.AddXY(pair.X[i], pair.Y[i]);
            }
        }

        private void SaveChartBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog fileDialog = new SaveFileDialog
            {
                Filter = "JPEG|*.jpg|PNG|*.png|BMP|*.bmp|TIFF|*.tif|GIF|*.gif",
                CheckPathExists = true
            };
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                //disable cursors
                Charts[tabControl1.SelectedIndex].ChartAreas[0].CursorX.Position = double.NaN;
                Charts[tabControl1.SelectedIndex].ChartAreas[0].CursorY.Position = double.NaN;
                Charts[tabControl1.SelectedIndex].SaveImage(fileDialog.FileName, (ChartImageFormat)fileDialog.FilterIndex);
                //enable cursors

            }
        }

        private void LessPeriodsBtn_Click(object sender, EventArgs e)
        {
            int oldPeriod = int.Parse(PeriodsText.Text);
            int newPeriod = oldPeriod - 1;
            if (newPeriod < 1) newPeriod = 1;

            if (oldPeriod == newPeriod) return;

            PeriodsText.Text = $"{newPeriod}";
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    Charts[0].Series.Clear();
                    DrawOsc();
                    break;
            }
        }

        private void MorePeriodsBtn_Click(object sender, EventArgs e)
        {
            int oldPeriod = int.Parse(PeriodsText.Text);
            int newPeriod = oldPeriod + 1;
            if (newPeriod > 100) newPeriod = 100;

            if (oldPeriod == newPeriod) return;

            PeriodsText.Text = $"{newPeriod}";
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    Charts[0].Series.Clear();
                    DrawOsc();
                    break;
            }
        }
    }
}
