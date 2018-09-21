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
            chart.Series.Add("ser1");
            chart.Series[0].Points.AddXY(25, 44);
            chart.Series[0].Points.AddXY(55, 60);
            this.Controls.Add(chart);
        }
    }
}
