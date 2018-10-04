using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimuMod
{
    public class Harmonic
    {
        public Harmonic(double Frequency, double StartPhase = 0, double Amplitude = 1)
        {
            Freq = Frequency;
            StaPhase = StartPhase;
            Amp = Amplitude;
        }

        //Hertz
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

        public PSR.Form1.Pair<double[], double[]> Graphical()
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

            return new PSR.Form1.Pair<double[], double[]>(x, y);
        }
    }

    class Signals
    {
        public static double[] SineWave(double Freq, double TimeSpacing)
        {
            double p = 1 / Freq;
            int samples = (int)(p / TimeSpacing);

            double[] sinus = new double[samples];
            double step = Math.PI * 2 / samples;
            for (int i = 0; i < samples; i++)
            {
                //radians
                double arg = (step * i);
                sinus[i] = (Math.Sin(arg));
            }
            return sinus;
        }

        public static double[] SineWave(double Freq, double TimeSpacing, double StaPhase)
        {
            double p = 1 / Freq;
            int samples = (int)(p / TimeSpacing);

            double[] sinus = new double[samples];
            double step = Math.PI * 2 / samples;
            for (int i = 0; i < samples; i++)
            {
                //radians
                double arg = (step * i);
                sinus[i] = (Math.Sin(arg + StaPhase));
            }
            return sinus;
        }

        public static double[] SineWave(double Freq, int Samples)
        {
            double p = 1 / Freq;
            int samples = Samples;

            double[] sinus = new double[samples];
            double step = Math.PI * 2 / samples;
            for (int i = 0; i < samples; i++)
            {
                //radians
                double arg = (step * i);
                sinus[i] = (Math.Sin(arg));
            }
            return sinus;
        }

        public static double[] SineWave(double Freq, int Samples, double StaPhase)
        {
            double p = 1 / Freq;
            int samples = Samples;

            double[] sinus = new double[samples];
            double step = Math.PI * 2 / samples;
            for (int i = 0; i < samples; i++)
            {
                //radians
                double arg = (step * i);
                sinus[i] = (Math.Sin(arg + StaPhase));
            }
            return sinus;
        }

        public static List<double> Square(double Fd, double Freq, int Periods, double time)
        {
            List<double> square = new List<double>();
            if (Freq >= Fd / 2) return square;

            int onepulse = (int)((Fd / Freq) * (time / Fd));
            //int cnt = (int)(time / onepulse);

            for (int i = 0; i < time && i < Fd; i++)
            {
                int temp = i % onepulse;
                if (temp < onepulse / 2)
                {
                    square.Add(1);
                }
                else
                {
                    square.Add(0);
                }
            }

            return square;
        }

        public static double Sinc(double x)
        {
            if (x == 0) return 1;
            return Math.Sin(x) / x;
        }
    }
}
