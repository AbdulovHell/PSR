using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class AM : ISignal
    {
        List<Harmonic> harmonics;
        Harmonic Carrier;
        double K = 1;
        double LeftBorder = -1, RightBorder = 1;
        double Step = 0.1;
        double FreqSpan = 0;
        double PhaseSpan = 0;
        double GFreq = 1;

        const int PointOnPeriod = 100;

        const SeriesChartType oscType = SeriesChartType.Area;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        //Modulated (Envelope)
        public AM(List<Harmonic> harmonics, Harmonic carrier, double K)
        {
            this.harmonics = harmonics;
            Carrier = carrier;
            this.K = K;
            GFreq = harmonics.MinimalNonZeroFreq();
            double PeriodToTime = (1 * 2 * Math.PI) / GFreq;
            Step = PeriodToTime / PointOnPeriod;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
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

        public CoordPair DrawAmpSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            x.Add(Carrier.Freq);
            y.Add(Carrier.Amp);

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(Carrier.Freq + harmonics[i].Freq);
                y.Add((K * harmonics[i].Amp)/2);
                x.Add(Carrier.Freq - harmonics[i].Freq);
                y.Add((K * harmonics[i].Amp) / 2);
            }

            return new CoordPair(x, y);
        }

        public CoordPair DrawOsc()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            double CurrentPoint = LeftBorder;
            while (CurrentPoint <= RightBorder)
            {
                y.Add(Carrier.Amp + K * CalcPoint(CurrentPoint));
                x.Add(CurrentPoint);
                CurrentPoint += Step;
            }

            return new CoordPair(x, y);
        }

        public CoordPair DrawPhaSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            x.Add(Carrier.Freq);
            y.Add(Carrier.StaPhase);

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(Carrier.Freq + harmonics[i].Freq);
                y.Add(Carrier.StaPhase + harmonics[i].StaPhase);
                x.Add(Carrier.Freq - harmonics[i].Freq);
                y.Add(Carrier.StaPhase - harmonics[i].StaPhase);
            }

            return new CoordPair(x, y);
        }

        SeriesChartType ISignal.OscType() => oscType;
        SeriesChartType ISignal.AmpSpecType() => ampSpecType;
        SeriesChartType ISignal.PhaseSpecType() => phaseSpecType;

        public void SetBorders(double left, double right)
        {
            LeftBorder = left;
            RightBorder = right;
        }

        public void SetFreqSpan(double hz)
        {
            FreqSpan = hz;
        }

        public void SetPeriods(int periods)
        {
            double PeriodToTime = (periods * 2 * Math.PI) / GFreq;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
        }

        public void SetPhaseSpan(double hz)
        {
            PhaseSpan = hz;
        }

        public Pair<double, double> SpecBorders()
        {
            return new Pair<double, double>(0, 0);
        }
    }
}
