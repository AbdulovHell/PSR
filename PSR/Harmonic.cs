using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MainModule
{
    public class Harmonic
    {
        public Harmonic(double Frequency, double StartPhase = 0, double Amplitude = 1)
        {
            Freq = Frequency;
            StaPhase = StartPhase;
            Amp = Amplitude;
        }

        //Rad/s
        public double Freq { get; private set; }
        //Radians
        public double StaPhase { get; private set; }
        //Volts
        public double Amp { get; private set; }
        //Еденицы измерения времени
        public string TimeUnits { get; private set; }

        public void Set(double Frequency, double StartPhase = 0, double Amplitude = 1)
        {
            Freq = Frequency;
            StaPhase = StartPhase;
            Amp = Amplitude;
        }

        private double ReduceUnits(double time)
        {
            int Reduces = 0;
            while (time < 0.1)
            {
                time *= 1000;
                Reduces++;
            }

            switch (Reduces)
            {
                case 0:
                    TimeUnits = "с";
                    break;
                case 1:
                    TimeUnits = "мс";
                    break;
                case 2:
                    TimeUnits = "мкс";
                    break;
                case 3:
                    TimeUnits = "нс";
                    break;
                default:
                    TimeUnits = "c";
                    break;
            }

            return time;
        }

        public Pair<double[], double[]> Graphical()
        {
            //5 periods
            const int Periods = 3;
            //18 point/period
            const int PointInPeriod = 36;
            double[] x = new double[Periods * PointInPeriod + 1];
            double[] y = new double[Periods * PointInPeriod + 1];
            double step = (Math.PI * 2) / PointInPeriod;
            double arg = 0;
            double timestep = ReduceUnits(1.0 / (PointInPeriod * Freq));
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = i * timestep;
                y[i] = Amp * Math.Sin(arg + StaPhase);
                arg += step;
            }

            return new Pair<double[], double[]>(x, y);
        }
    }
}
