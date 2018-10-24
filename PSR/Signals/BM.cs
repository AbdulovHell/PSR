using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class BM : ISignal
    {
        //Modulated balanced (Envelope)
        public BM(List<Harmonic> harmonics, Harmonic carrier, double K, double V0, double Kp)
        {
            //const int Points = 1000;
            //const double Time = 1;
            //const double StartTime = -0.5;

            //x = new double[Points];
            //y = new double[Points];
            //double step = Time / Points;

            //for (int i = 0; i < x.Length; i++)
            //{
            //    x[i] = StartTime + i * step;
            //    double U0 = carrier.Amp * Math.Cos(carrier.Freq * x[i] + carrier.StaPhase);
            //    y[i] = Kp * U0 + ((K * CalcPoint(ref harmonics, StartTime + i * step)) / V0) * U0;
            //}
            //Type = SeriesChartType.Area;
        }

        public SeriesChartType AmpSpecType()
        {
            throw new NotImplementedException();
        }

        public CoordPair DrawAmpSpec()
        {
            throw new NotImplementedException();
        }

        public CoordPair DrawOsc()
        {
            throw new NotImplementedException();
        }

        public CoordPair DrawPhaSpec()
        {
            throw new NotImplementedException();
        }

        public SeriesChartType OscType()
        {
            throw new NotImplementedException();
        }

        public SeriesChartType PhaseSpecType()
        {
            throw new NotImplementedException();
        }

        public void SetBorders(double left, double right)
        {
            throw new NotImplementedException();
        }

        public void SetFreqSpan(double hz)
        {
            throw new NotImplementedException();
        }

        public void SetPeriods(int periods)
        {
            throw new NotImplementedException();
        }

        public void SetPhaseSpan(double hz)
        {
            throw new NotImplementedException();
        }
    }
}
