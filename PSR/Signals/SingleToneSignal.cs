using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class SingleToneSignal : ISignal
    {
        Harmonic harmonic;

        double Periods = 1;
        double FreqSpan = 0;
        double PhaseSpan = 0;

        const SeriesChartType oscType = SeriesChartType.Spline;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        public SingleToneSignal(Harmonic harmonic)
        {
            this.harmonic = harmonic;
        }

        public CoordPair DrawOsc()
        {
            int Points = (int)(Periods * 100 + 1);
            double Time = (Periods * 2 * Math.PI) / harmonic.Freq;
            double StartTime = -1 * Time / 2;

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            double step = Time / Points;

            for (int i = 0; i < Points; i++)
            {
                y.Add(CalcPoint(StartTime + i * step));
                x.Add(StartTime + i * step);
            }

            return new CoordPair(x, y);
        }

        public void SetPeriods(int periods)
        {
            Periods = periods;
        }

        public void SetBorders(double left, double right)
        {
            double Time = left * -2;
            Periods = (harmonic.Freq * Time) / (2 * Math.PI);
        }

        private double CalcPoint(double t, double StartPhase = 0)
        {
            return harmonic.Amp * Math.Cos(harmonic.Freq * t + harmonic.StaPhase + StartPhase);
        }

        //линия V0 на F0
        public CoordPair DrawAmpSpec()
        {
            //int Points = 100 + 1;
            //double StartTime = harmonic.Freq - FreqSpan / 2;

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            //double step = FreqSpan / Points;

            //for (int i = 0; i < Points - 1; i++)
            //{
            //    y.Add(0);
            //    x.Add(StartTime + i * step);
            //}

            x.Add(harmonic.Freq);
            y.Add(harmonic.Amp);

            return new CoordPair(x, y);
        }

        public void SetFreqSpan(double hz)
        {
            FreqSpan = hz;
        }

        public CoordPair DrawPhaSpec()
        {
            //int Points = 100 + 1;
            //double StartTime = harmonic.Freq - PhaseSpan / 2;

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            //double step = PhaseSpan / Points;

            //for (int i = 0; i < Points - 1; i++)
            //{
            //    y.Add(0);
            //    x.Add(StartTime + i * step);
            //}

            x.Add(harmonic.Freq);
            y.Add(harmonic.StaPhase);

            return new CoordPair(x, y);
        }

        public void SetPhaseSpan(double hz)
        {
            PhaseSpan = hz;
        }

        SeriesChartType ISignal.OscType() => oscType;
        SeriesChartType ISignal.AmpSpecType() => ampSpecType;
        SeriesChartType ISignal.PhaseSpecType() => phaseSpecType;
    }
}
