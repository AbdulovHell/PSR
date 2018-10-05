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
    }
}
