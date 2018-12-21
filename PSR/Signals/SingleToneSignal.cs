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

        double LeftBorder=-1, RightBorder=1;
        double Step=0.1;
        double FreqSpan = 0;
        double PhaseSpan = 0;

        const int PointOnPeriod = 100;

        const SeriesChartType oscType = SeriesChartType.Spline;
        const SeriesChartType ampSpecType = SeriesChartType.Point;
        const SeriesChartType phaseSpecType = SeriesChartType.Point;

        public SingleToneSignal(Harmonic harmonic)
        {
            this.harmonic = harmonic;

            double PeriodToTime = (1 * 2 * Math.PI) / harmonic.Freq;
            Step = PeriodToTime / PointOnPeriod;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
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

        public void SetPeriods(int periods)
        {
            double PeriodToTime = (periods * 2 * Math.PI) / harmonic.Freq;
            LeftBorder = PeriodToTime / -2;
            RightBorder = PeriodToTime / 2;
        }

        public void SetBorders(double left, double right)
        {
            LeftBorder = left;
            RightBorder = right;
        }

        private double CalcPoint(double t, double StartPhase = 0)
        {
            return harmonic.Amp * Math.Cos(harmonic.Freq * t + harmonic.StaPhase + StartPhase);
        }

        //линия V0 на F0
        public CoordPair DrawAmpSpec()
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();
            
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
            List<double> x = new List<double>();
            List<double> y = new List<double>();

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
