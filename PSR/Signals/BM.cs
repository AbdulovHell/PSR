using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class BM : ISignal
    {
        List<Harmonic> harmonics;
        Harmonic Carrier;
        double K = 1;
        double V0 = 1;
        double Periods = 1;
        double FreqSpan = 0;
        double PhaseSpan = 0;
        double Kp = 1;

        const SeriesChartType oscType = SeriesChartType.Area;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        //Modulated balanced (Envelope)
        public BM(List<Harmonic> harmonics, Harmonic carrier, double K, double V0, double Kp)
        {
            this.harmonics = harmonics;
            Carrier = carrier;
            this.K = K;
            this.V0 = V0;
            this.Kp = Kp;

        }

        public CoordPair DrawAmpSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            x.Add(Carrier.Freq);
            y.Add(Carrier.Amp * Kp);

            for (int i = 0; i < harmonics.Count; i++)
            {
                x.Add(Carrier.Freq + harmonics[i].Freq);
                y.Add((K * harmonics[i].Amp) / 2);
                x.Add(Carrier.Freq - harmonics[i].Freq);
                y.Add((K * harmonics[i].Amp) / 2);
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
            int Points = (int)(Periods * 100 + 1);
            double Time = (Periods * 2 * Math.PI) / harmonics[1].Freq;
            double StartTime = -1 * Time / 2;

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            double step = Time / Points;

            for (int i = 0; i < Points; i++)
            {
                x.Add(StartTime + i * step);
                double U0 = Carrier.Amp * Math.Cos(Carrier.Freq * x[i] + Carrier.StaPhase);
                y.Add(Kp * U0 + ((K * CalcPoint(StartTime + i * step)) / V0) * U0);
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
            double Time = left * -2;
            Periods = (harmonics[1].Freq * Time) / (2 * Math.PI);
        }

        public void SetFreqSpan(double hz)
        {
            FreqSpan = hz;
        }

        public void SetPeriods(int periods)
        {
            Periods = periods;
        }

        public void SetPhaseSpan(double hz)
        {
            PhaseSpan = hz;
        }
    }
}
