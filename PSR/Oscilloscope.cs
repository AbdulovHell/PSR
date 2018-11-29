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
            Modulated
        }

        Chart[] Charts = new Chart[3];
        Signals.ISignal signal;
        FuncType OSCtype;
        string Units = "";
        int[] Periods = new int[3];
        int Xunits;

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
            tabControl1.TabPages[0].Controls.Add(Charts[0]);
            tabControl1.TabPages[1].Controls.Add(Charts[1]);
            tabControl1.TabPages[2].Controls.Add(Charts[2]);
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

        public Oscilloscope(string caption, Signals.ISignal signal, int tabIndex = 0)
        {
            InitializeComponent();
            Text = caption;
            InitCharts();
            this.signal = signal;
            tabControl1.SelectedIndex = tabIndex;

            Periods[0] = 1;
            Periods[1] = 1;
            Periods[2] = 1;

            RelocateBtns();
        }

        void RelocateBtns()
        {
            var UpLeftCorner = new Point(tabPage1.Left, tabPage1.Top);
            IncrMaxYBtn.Location = new Point(4 + UpLeftCorner.X, 4 + UpLeftCorner.Y);
            DecrMaxYBtn.Location = new Point(4 + UpLeftCorner.X, 25 + UpLeftCorner.Y);

            var DownLeftCorner = new Point(tabPage1.Left, /*tabPage1.Top +*/ Charts[0].Size.Height);
            DecrMinYBtn.Location = new Point(DownLeftCorner.X + 4, DownLeftCorner.Y - 0);
            IncrMinYBtn.Location = new Point(DownLeftCorner.X + 4, DownLeftCorner.Y - 21);

            DecrMinXBtn.Location = new Point(DownLeftCorner.X + 25, DownLeftCorner.Y - 0);
            IncrMinXBtn.Location = new Point(DownLeftCorner.X + 46, DownLeftCorner.Y - 0);

            var DownRightCorner = new Point(Charts[0].Size.Width, Charts[0].Size.Height);

            IncrMaxXBtn.Location = new Point(DownRightCorner.X - (0 + 20), DownRightCorner.Y - 0);
            DecrMaxXBtn.Location = new Point(DownRightCorner.X - (21 + 20), DownRightCorner.Y - 0);
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

        private void OscToChart()
        {
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

                Xunits = ReduceUnits(Points.X[index]).Second;
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

            //Normal
            Charts[0].Series.Add($"Ser{Charts[0].Series.Count}");
            Charts[0].Series[Charts[0].Series.Count - 1].ChartType = signal.OscType();
            Charts[0].Series[Charts[0].Series.Count - 1].BorderWidth = 1;
            Charts[0].Series[Charts[0].Series.Count - 1].Color = Color.Blue;         
            for (int i = 0; i < Points.X.Count; i++)
            {
                Charts[0].Series[Charts[0].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i]);
            }

            if (OSCtype == FuncType.Modulated)
            {
                Charts[0].Series.Add($"Ser{Charts[0].Series.Count}");
                Charts[0].Series[Charts[0].Series.Count - 1].ChartType = signal.OscType();
                Charts[0].Series[Charts[0].Series.Count - 1].BorderWidth = 1;
                Charts[0].Series[Charts[0].Series.Count - 1].Color = Color.Blue;
                for (int i = 0; i < Points.X.Count; i++)
                {
                    Charts[0].Series[Charts[0].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i] * -1);
                }
            }

            List<double> tempX = new List<double>(Points.X);
            tempX.Sort();
            double min = tempX[0], max = tempX[tempX.Count - 1];

            //Charts[0].ChartAreas[0].AxisX.Interval = Math.Abs(min - max) / 10;
            //chart.ChartAreas[0].AxisX.ScaleView.Position = -0.5;
            //chart.ChartAreas[0].AxisX.ScaleView.Size = 1;
            Charts[0].ChartAreas[0].AxisX.Minimum = Math.Round(min, 3);
            Charts[0].ChartAreas[0].AxisX.Maximum = Math.Round(max, 3);

            List<double> mins = new List<double>();
            for (int i = 0; i < Charts[0].Series.Count; i++)
            {
                mins.AddRange(Charts[0].Series[i].Points.FindMinByValue().YValues);
            }
            mins.Sort();

            List<double> maxs = new List<double>();
            for (int i = 0; i < Charts[0].Series.Count; i++)
            {
                maxs.AddRange(Charts[0].Series[i].Points.FindMaxByValue().YValues);
            }
            maxs.Sort();

            Charts[0].ChartAreas[0].AxisY.Minimum = Math.Round(mins[0], 3);
            Charts[0].ChartAreas[0].AxisY.Maximum = Math.Round(maxs[maxs.Count - 1], 3);
        }

        public void DrawOsc(FuncType funcType = FuncType.Normal)
        {
            OSCtype = funcType;
            signal.SetPeriods(Periods[0]);
            OscToChart();
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
            Periods[tabControl1.SelectedIndex] = newPeriod;
            signal.SetPeriods(Periods[tabControl1.SelectedIndex]);
            Charts[tabControl1.SelectedIndex].Series.Clear();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    OscToChart();
                    break;
                case 1:
                    DrawSpec();
                    break;
                case 2:
                    DrawPhaseSpec();
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
            Periods[tabControl1.SelectedIndex] = newPeriod;
            signal.SetPeriods(Periods[tabControl1.SelectedIndex]);
            Charts[tabControl1.SelectedIndex].Series.Clear();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    OscToChart();
                    break;
                case 1:
                    DrawSpec();
                    break;
                case 2:
                    DrawPhaseSpec();
                    break;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            PeriodsText.Text = Periods[tabControl1.SelectedIndex].ToString();
            PeriodsText.Enabled = tabControl1.SelectedIndex == 0;
        }

        private void Oscilloscope_ResizeEnd(object sender, EventArgs e)
        {
            RelocateBtns();
        }

        private void IncrMaxXBtn_Click(object sender, EventArgs e)
        {
            Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum += 0.1;
            signal.SetBorders(
                Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum / Math.Pow(1000, Xunits / 3),
                Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum / Math.Pow(1000, Xunits / 3)
                );
            Charts[tabControl1.SelectedIndex].Series.Clear();

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    OscToChart();
                    break;
            }
        }
    }
}
