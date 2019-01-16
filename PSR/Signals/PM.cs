using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class PM : ISignal
    {
        List<Harmonic> harmonics;
        Harmonic Carrier;
        double K = 1;
        double LeftBorder = -1, RightBorder = 1;
        double Step = 0.1;
        double FreqSpan = 0;
        double PhaseSpan = 0;
        double GFreq = 1;

        double Fmin = -1;
        double Fmax = 1;
        double Fmin_view = -1;
        double Fmax_view = 1;

        const int PointOnPeriod = 2000;

        const SeriesChartType oscType = SeriesChartType.Spline;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        //Modulated balanced (Envelope)
        public PM(List<Harmonic> harmonics, Harmonic carrier, double K)
        {
            this.harmonics = harmonics;
            Carrier = carrier;
            this.K = K;
            GFreq = harmonics.MinimalNonZeroFreq();
            //GFreq = carrier.Freq;
            double PeriodToTime = (1 * 2 * Math.PI) / GFreq;
            Step = PeriodToTime / PointOnPeriod;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
        }

        public CoordPair DrawAmpSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            //x.Add(Carrier.Freq);
            //y.Add(Carrier.Amp * Kp);

            //for (int i = 0; i < harmonics.Count; i++)
            //{
            //    x.Add(Carrier.Freq + harmonics[i].Freq);
            //    y.Add((K * harmonics[i].Amp) / 2);
            //    x.Add(Carrier.Freq - harmonics[i].Freq);
            //    y.Add((K * harmonics[i].Amp) / 2);
            //}

            double[] S = new double[2048];
            double[] indexes = new double[harmonics.Count];
            double[] Fs = new double[harmonics.Count];
            for (int i = 0; i < harmonics.Count; i++)
            {
                //double d = Math.Abs(Carrier.Freq - harmonics[i].Freq);
                //indexes[i] = d / harmonics[i].Freq;
                indexes[i] = i + 1;
                Fs[i] = harmonics[i].Freq;
            }
            indexes[indexes.Length - 1] = 0;
            Mods.Chm(S, indexes, Fs, Carrier.Freq);

            Fmin = Mods.f_min;
            Fmax = Mods.f_max;
            Fmin_view = Mods.f_min_view;
            Fmax_view = Mods.f_max_view;

            double Step = (Fmax - Fmin) / S.Length;

            double CurrentPoint = Fmin;

            for (int i = 0; i < S.Length; i++)
            {
                x.Add(CurrentPoint);
                y.Add(S[i]);
                CurrentPoint += Step;
            }

            return new CoordPair(x, y);
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

            double Fd = 2 * Math.PI * harmonics.MaximumNonZeroFreq();
            double CurrentPoint = LeftBorder;
            while (CurrentPoint <= RightBorder)
            {
                x.Add(CurrentPoint);
                double om = Carrier.Freq + K * CalcPoint(CurrentPoint);
                double Y = Carrier.Amp * Math.Cos(om + Carrier.StaPhase);
                //=Carrier.Amp * Math.Cos(Carrier.Freq * CurrentPoint + Carrier.StaPhase);
                //y.Add(Kp * U0 + ((K * CalcPoint(CurrentPoint)) / V0) * U0);
                y.Add(Y);
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
            return new Pair<double, double>(Fmin_view, Fmax_view);
        }
    }
}
