using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule
{
    public class Painter
    {
        double[] x;
        double[] y;

        public SeriesChartType Type { get; private set; }

        //Simple
        public Painter(List<Harmonic> harmonics)
        {
            CalcSimpleSignal(harmonics);
            Type = SeriesChartType.Spline;
        }

        public Painter(Harmonic harmonic)
        {
            List<Harmonic> harmonics = new List<Harmonic>();
            harmonics.Add(harmonic);
            CalcSimpleSignal(harmonics);
            Type = SeriesChartType.Area;
        }

        //Modulated (Envelope)
        public Painter(List<Harmonic> harmonics, double K, double V0)
        {
            const int Points = 1000;
            const double Time = 1;
            const double StartTime = -0.5;

            x = new double[Points];
            y = new double[Points];
            double step = Time / Points;

            for (int i = 0; i < x.Length; i++)
            {
                y[i] = V0+K*CalcPoint(ref harmonics, StartTime + i * step);
                x[i] = StartTime + i * step;
            }
            Type = SeriesChartType.Area;
        }

        private double CalcPoint(ref List<Harmonic> harmonics, double t, double StartPhase = 0)
        {
            double res = 0;
            for (int i = 0; i < harmonics.Count; i++)
            {
                res += harmonics[i].Amp * Math.Cos(harmonics[i].Freq * t + harmonics[i].StaPhase + StartPhase);
            }
            return res;
        }

        private void CalcSimpleSignal(List<Harmonic> harmonics)
        {
            const int Points = 1000;
            const double Time = 1;
            const double StartTime = -0.5;

            x = new double[Points];
            y = new double[Points];
            double step = Time / Points;

            for (int i = 0; i < x.Length; i++)
            {
                y[i] = CalcPoint(ref harmonics, StartTime + i * step);
                x[i] = StartTime + i * step;
            }
        }

        public Pair<double[], double[]> Draw()
        {
            return new Pair<double[], double[]>(x, y);
        }
    }
}
