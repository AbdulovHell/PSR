using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    class MultiToneSignal : ISignal
    {
        List<Harmonic> harmonics;
        double GFreq = 1;
        double K=1;

        protected double Periods = 1;
        double FreqSpan = 0;
        double PhaseSpan = 0;

        const SeriesChartType oscType = SeriesChartType.Spline;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        public MultiToneSignal(List<Harmonic> harmonics, double K)
        {
            this.harmonics = harmonics;
            this.K = K;

            var tempList = harmonics.Where(h => h.Freq != 0).ToList();
            GFreq = 0;
            for (int i = 0; i < tempList.Count; i++)
            {
                GFreq += tempList[i].Freq;
            }
            GFreq /= tempList.Count;
        }

        public void SetPeriods(int periods)
        {
            Periods = periods;
        }

        public void SetBorders(double left, double right)
        {
            double Time = left * -2;
            Periods = (GFreq * Time) / (2 * Math.PI);
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
                y.Add(CalcPoint(StartTime + i * step));
                x.Add(StartTime + i * step);
            }

            return new CoordPair(x, y);
        }

        public CoordPair DrawAmpSpec()
        {
            //int Points = 100 + 1 - harmonics.Count;
            //double StartTime = GFreq - FreqSpan / 2;

            List<double> x = new List<double>();
            List<double> y = new List<double>();
            //double step = FreqSpan / Points;

            //for (int i = 0; i < Points - 1; i++)
            //{
            //    y.Add(0);
            //    x.Add(StartTime + i * step);
            //}

            //x.Add(harmonic.Freq);
            //y.Add(harmonic.Amp);

            for(int i = 0; i < harmonics.Count; i++)
            {
                x.Add(harmonics[i].Freq);
                y.Add((/*K**/harmonics[i].Amp)/2);
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
    }
}
