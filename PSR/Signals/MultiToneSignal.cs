using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class MultiToneSignal : ISignal
    {
        List<Harmonic> harmonics;
        double GFreq = 1;
        double K = 1;

        double LeftBorder = -1, RightBorder = 1;
        double Step = 0.1;
        double FreqSpan = 0;
        double PhaseSpan = 0;

        const int PointOnPeriod = 100;

        const SeriesChartType oscType = SeriesChartType.Spline;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        public MultiToneSignal(List<Harmonic> harmonics, double K)
        {
            this.harmonics = harmonics;
            this.K = K;

            GFreq = harmonics.MinimalNonZeroFreq();

            double PeriodToTime = (1 * 2 * Math.PI) / GFreq;
            Step = PeriodToTime / PointOnPeriod;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
        }

        public void SetPeriods(int periods)
        {
            double PeriodToTime = (periods * 2 * Math.PI) / GFreq;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
        }

        public void SetBorders(double left, double right)
        {
            LeftBorder = left;
            RightBorder = right;
        }

        protected double CalcPoint(double t, double StartPhase = 0)
        {
            double res = 0;
            for (int i = 0; i < harmonics.Count; i++)
            {
                res += harmonics[i].Amp * Math.Cos(harmonics[i].Freq * t + harmonics[i].StaPhase + StartPhase);
            }
            return res;
        }

        public CoordPair DrawOsc()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            double CurrentPoint = LeftBorder;
            while (CurrentPoint <= RightBorder)
            {
                y.Add(CalcPoint(CurrentPoint));
                x.Add(CurrentPoint);
                CurrentPoint += Step;
            }

            return new CoordPair(x, y);
        }

        public CoordPair DrawAmpSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(harmonics[i].Freq);
                y.Add((K * harmonics[i].Amp));
            }

            return new CoordPair(x, y);
        }

        public void SetFreqSpan(double hz)
        {
            FreqSpan = hz;
        }

        public CoordPair DrawPhaSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(harmonics[i].Freq);
                y.Add(harmonics[i].StaPhase);
            }

            return new CoordPair(x, y);
        }

        public void SetPhaseSpan(double hz)
        {
            PhaseSpan = hz;
        }

        SeriesChartType ISignal.OscType() => oscType;
        SeriesChartType ISignal.AmpSpecType() => ampSpecType;
        SeriesChartType ISignal.PhaseSpecType() => phaseSpecType;

        public Pair<double, double> SpecBorders()
        {
            return new Pair<double, double>(0, 0);
        }
    }
}
