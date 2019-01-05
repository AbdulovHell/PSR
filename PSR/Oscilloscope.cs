using System;
using System.Collections.Generic;
using System.Drawing;
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
        string[] Units = { "", "", "" };
        int[] Periods = new int[3];
        int[] PrefixIndex = new int[3];
        double[] Xoffset = { 0, 0, 0 }, Yoffset = { 0, 0, 0 };
        bool[] DragCursors = { true, true, true };

        void InitCharts()
        {
            for (int i = 0; i < 3; i++)
            {
                Charts[i] = new Chart();
                Charts[i].Dock = DockStyle.Fill;
                Charts[i].MouseMove += Chart_MouseMove;
                Charts[i].Click += Oscilloscope_Click;
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

                Charts[i].Annotations.Add(new CalloutAnnotation()
                {
                    AxisX = Charts[i].ChartAreas[0].AxisX,
                    AxisY = Charts[i].ChartAreas[0].AxisY,
                    IsSizeAlwaysRelative = false
                });   //x
                Charts[i].Annotations.Add(new CalloutAnnotation()
                {
                    AxisX = Charts[i].ChartAreas[0].AxisX,
                    AxisY = Charts[i].ChartAreas[0].AxisY,
                    IsSizeAlwaysRelative = false
                });   //y

                Charts[i].ChartAreas[0].AxisX.TitleFont = new Font("Arial", 10, FontStyle.Regular);
                Charts[i].ChartAreas[0].AxisY.TitleFont = new Font("Arial", 10, FontStyle.Regular);
            }

            Charts[0].ChartAreas[0].AxisY.Title = "U, В";
            Charts[1].ChartAreas[0].AxisY.Title = "U, В";
            if (Form1.unitsType == Form1.UnitsType.Radian)
            {
                Charts[2].ChartAreas[0].AxisY.Title = "φ, рад";
            }
            else
            {
                Charts[2].ChartAreas[0].AxisY.Title = "φ, град";
            }

            tabControl1.TabPages[0].Controls.Add(Charts[0]);
            tabControl1.TabPages[1].Controls.Add(Charts[1]);
            tabControl1.TabPages[2].Controls.Add(Charts[2]);
        }

        private void Oscilloscope_Click(object sender, EventArgs e)
        {
            DragCursors[tabControl1.SelectedIndex] =!DragCursors[tabControl1.SelectedIndex];
            if (DragCursors[tabControl1.SelectedIndex]) {
                Charts[tabControl1.SelectedIndex].MouseMove += Chart_MouseMove;
            }
            else
            {
                Charts[tabControl1.SelectedIndex].MouseMove -= Chart_MouseMove;
            }
        }

        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            if (!Form1.EnCursors) return;
            if (sender.GetType().ToString() != "System.Windows.Forms.DataVisualization.Charting.Chart") return;
            Chart chart = sender as Chart;
            chart.ChartAreas[0].CursorX.SetCursorPixelPosition(new PointF(e.X, e.Y), true);
            chart.ChartAreas[0].CursorY.SetCursorPixelPosition(new PointF(e.X, e.Y), true);

            CalloutAnnotation Xannotation = chart.Annotations[0] as CalloutAnnotation;
            CalloutAnnotation Yannotation = chart.Annotations[1] as CalloutAnnotation;
            Xannotation.Text = chart.ChartAreas[0].CursorX.Position.ToString();
            Yannotation.Text = chart.ChartAreas[0].CursorY.Position.ToString();

            Xannotation.X = chart.ChartAreas[0].CursorX.Position;
            Xannotation.Y = Yoffset[tabControl1.SelectedIndex];

            Yannotation.X = Xoffset[tabControl1.SelectedIndex];
            Yannotation.Y = chart.ChartAreas[0].CursorY.Position;

            //Text = $"{e.X} {e.Y}";
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
            PeriodsText.Enabled = tabControl1.SelectedIndex == 0;
            LessPeriodsBtn.Enabled = tabControl1.SelectedIndex == 0;
            MorePeriodsBtn.Enabled = tabControl1.SelectedIndex == 0;
        }

        void RelocateBtns()
        {
            var UpLeftCorner = new Point(tabPage1.Left, tabPage1.Top);
            IncrMaxYBtn.Location = new Point(4 + UpLeftCorner.X, 4 + UpLeftCorner.Y);
            DecrMaxYBtn.Location = new Point(4 + UpLeftCorner.X, 25 + UpLeftCorner.Y);

            var DownLeftCorner = new Point(tabPage1.Left, /*tabPage1.Top +*/ Charts[tabControl1.SelectedIndex].Size.Height);
            DecrMinYBtn.Location = new Point(DownLeftCorner.X + 4, DownLeftCorner.Y - 0);
            IncrMinYBtn.Location = new Point(DownLeftCorner.X + 4, DownLeftCorner.Y - 21);

            DecrMinXBtn.Location = new Point(DownLeftCorner.X + 25, DownLeftCorner.Y - 0);
            IncrMinXBtn.Location = new Point(DownLeftCorner.X + 46, DownLeftCorner.Y - 0);

            var DownRightCorner = new Point(Charts[tabControl1.SelectedIndex].Size.Width, Charts[tabControl1.SelectedIndex].Size.Height);

            IncrMaxXBtn.Location = new Point(DownRightCorner.X - (0 + 20), DownRightCorner.Y - 0);
            DecrMaxXBtn.Location = new Point(DownRightCorner.X - (21 + 20), DownRightCorner.Y - 0);
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

                PrefixIndex[0] = Points.X[index].Reduce().Order;
                //var Yunits = ReduceUnits(Points.Y[index]).Y;
                Charts[0].ChartAreas[0].AxisX.Title = "t, " + PrefixIndex[0].AsMetricPrefix() + "c";

                for (int i = 0; i < Points.X.Count; i++)
                {
                    Points.X[i] = Points.X[i].Reorder(-PrefixIndex[0]).Trim();
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

            //Charts[0].ChartAreas[0].AxisY.Minimum = Math.Round(mins[0], 0);
            //Charts[0].ChartAreas[0].AxisY.Maximum = Math.Round(maxs[maxs.Count - 1], 0);
        }

        public void DrawOsc(FuncType funcType = FuncType.Normal, int periods = 1)
        {
            OSCtype = funcType;
            Periods[0] = periods;
            PeriodsText.Text = Periods[0].ToString();
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

        public void DrawSpec(bool chm = false)
        {
            Charts[1].Series.Add($"Ser{Charts[1].Series.Count}");
            Charts[1].Series[Charts[1].Series.Count - 1].ChartType = signal.AmpSpecType();
            Charts[1].Series[Charts[1].Series.Count - 1].BorderWidth = 2;
            Charts[1].Series[Charts[1].Series.Count - 1].Color = Color.Red;
            Charts[1].Series[Charts[1].Series.Count - 1].MarkerSize = 8;
            Charts[1].Series[Charts[1].Series.Count - 1].MarkerStyle = MarkerStyle.Circle;
            //annotation line width >=2
            //Получение отсчетов
            if (chm)
            {
                var Points=signal.DrawAmpSpec();

                Charts[1].ChartAreas[0].AxisX.Title = (Form1.unitsType == Form1.UnitsType.Radian ? "ω, рад/с" : "f, Гц");

                for (int i = 0; i < Points.X.Count; i++)
                {
                    Charts[1].Series[Charts[1].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i]);
                }

                Charts[1].Series[Charts[1].Series.Count - 1].ChartType = SeriesChartType.Spline;
                Charts[1].Series[Charts[1].Series.Count - 1].BorderWidth = 1;
                Charts[1].Series[Charts[1].Series.Count - 1].MarkerStyle = MarkerStyle.None;
            }
            else
            {
                var Points = signal.DrawAmpSpec();
                Points = Sort(Points);
                DelDupli(ref Points);

                //Перевод величин и определение едениц измерения
                if (Form1.unitsType == Form1.UnitsType.Radian)
                {
                    Units[1] = "рад/сек";
                }
                else
                {
                    for (int i = 0; i < Points.X.Count; i++)
                        Points.X[i] = Points.X[i] / (2.0 * Math.PI);
                    Units[1] = "Гц";
                }

                //Сокращение
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

                    PrefixIndex[1] = Points.X[index].Reduce().Order;
                    Units[1] = PrefixIndex[1].AsMetricPrefix() + Units[1];

                    for (int i = 0; i < Points.X.Count; i++)
                    {
                        Points.X[i] = Points.X[i].Reorder(-PrefixIndex[1]).Trim(3);
                        //Points.Y[i] *= Math.Pow(1000, Yunits / 3);
                    }
                }

                Charts[1].ChartAreas[0].AxisX.Title = (Form1.unitsType == Form1.UnitsType.Radian ? "ω, " : "f, ") + Units[1];

                for (int i = 0; i < Points.X.Count; i++)
                {
                    Charts[1].Series[Charts[1].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i]);
                    Charts[1].Annotations.Add(new VerticalLineAnnotation()
                    {
                        LineWidth = 2,
                        AxisX = Charts[1].ChartAreas[0].AxisX,
                        AxisY = Charts[1].ChartAreas[0].AxisY,
                        IsSizeAlwaysRelative = false,
                        Height = Points.Y[i],
                        Y = 0,
                        X = Points.X[i]
                    });
                }
            }
        }

        public void DrawPhaseSpec()
        {
            Charts[2].Series.Add($"Ser{Charts[2].Series.Count}");
            Charts[2].Series[Charts[2].Series.Count - 1].ChartType = signal.PhaseSpecType();
            Charts[2].Series[Charts[2].Series.Count - 1].BorderWidth = 2;
            Charts[2].Series[Charts[2].Series.Count - 1].Color = Color.Red;
            Charts[2].Series[Charts[2].Series.Count - 1].MarkerSize = 8;
            Charts[2].Series[Charts[2].Series.Count - 1].MarkerStyle = MarkerStyle.Circle;

            var Points = signal.DrawPhaSpec();
            DelDupli(ref Points);

            if (Form1.unitsType == Form1.UnitsType.Radian)
            {
                Units[2] = "рад/сек";
            }
            else
            {
                for (int i = 0; i < Points.X.Count; i++)
                {
                    Points.X[i] = Points.X[i] / (2.0 * Math.PI);
                    Points.Y[i] = Points.Y[i] * (180.0 / Math.PI);
                }
                Units[2] = "Гц";
            }

            //Сокращение
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

                PrefixIndex[2] = Points.X[index].Reduce().Order;
                Units[2] = PrefixIndex[2].AsMetricPrefix() + Units[2];

                for (int i = 0; i < Points.X.Count; i++)
                {
                    Points.X[i] = Points.X[i].Reorder(-PrefixIndex[2]).Trim(3);
                    //Points.Y[i] *= Math.Pow(1000, Yunits / 3);
                }
            }

            Charts[2].ChartAreas[0].AxisX.Title = (Form1.unitsType == Form1.UnitsType.Radian ? "ω, " : "f, ") + Units[2];

            for (int i = 0; i < Points.X.Count; i++)
            {
                Charts[2].Series[Charts[2].Series.Count - 1].Points.AddXY(Points.X[i], Points.Y[i]);
                Charts[2].Annotations.Add(new VerticalLineAnnotation()
                {
                    LineWidth = 2,
                    AxisX = Charts[2].ChartAreas[0].AxisX,
                    AxisY = Charts[2].ChartAreas[0].AxisY,
                    IsSizeAlwaysRelative = false,
                    Height = Points.Y[i],
                    Y = 0,
                    X = Points.X[i]
                });
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
            LessPeriodsBtn.Enabled = tabControl1.SelectedIndex == 0;
            MorePeriodsBtn.Enabled = tabControl1.SelectedIndex == 0;
        }

        private void Oscilloscope_ResizeEnd(object sender, EventArgs e)
        {
            RelocateBtns();
        }

        private void IncrMaxXBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum;
            Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum += span.GetDelta();

            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    signal.SetBorders(
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum.Reorder(PrefixIndex[0]),
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum.Reorder(PrefixIndex[0])
                        );
                    Charts[tabControl1.SelectedIndex].Series.Clear();
                    OscToChart();
                    break;
            }
        }

        private void DecrMaxXBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum;
            if (Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum - span.GetDelta() > Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum)
                Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum -= span.GetDelta();
            else return;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    signal.SetBorders(
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum.Reorder(PrefixIndex[0]),
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum.Reorder(PrefixIndex[0])
                        );
                    Charts[tabControl1.SelectedIndex].Series.Clear();
                    OscToChart();
                    break;
                case 1:

                    break;
            }
        }

        private void IncrMinXBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum;
            if (Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum + span.GetDelta() < Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum)
                Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum += span.GetDelta();
            else return;
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    signal.SetBorders(
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum.Reorder(PrefixIndex[0]),
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum.Reorder(PrefixIndex[0])
                        );
                    Charts[tabControl1.SelectedIndex].Series.Clear();
                    OscToChart();
                    break;
            }
        }

        private void DecrMinXBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum;
            Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum -= span.GetDelta();
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    signal.SetBorders(
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Minimum.Reorder(PrefixIndex[0]),
                        Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisX.Maximum.Reorder(PrefixIndex[0])
                        );
                    Charts[tabControl1.SelectedIndex].Series.Clear();
                    OscToChart();
                    break;
            }
        }

        private void DecrMinYBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum;
            Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum -= span.GetDelta();
        }

        private void IncrMinYBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum;
            double ch = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum + span.GetDelta();
            if (ch < Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum)
                Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum += span.GetDelta();
            else return;
        }

        private void DecrMaxYBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum;
            double ch = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum - span.GetDelta();
            if (ch > Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum)
                Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum -= span.GetDelta();
            else return;
        }

        private void IncrMaxYBtn_Click(object sender, EventArgs e)
        {
            double span = Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum - Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Minimum;
            Charts[tabControl1.SelectedIndex].ChartAreas[0].AxisY.Maximum += span.GetDelta();
        }
    }
}
