using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SimuMod
{
    class Harmonic
    {
        Harmonic(double Freq)
        {
            this.Freq = Freq;
            StaPhase = 0;
            Amp = 1;
        }

        //Hertz
        public double Freq { get => Freq; private set => Freq = value; }
        //Radians
        public double StaPhase { get => StaPhase; private set => StaPhase = value; }
        //Volts
        public double Amp { get => Amp; private set => Amp = value; }

        Pair<double[], double[]> Graphical()
        {
            //5 periods
            const int Periods = 5;
            //18 point/period
            const int PointInPeriod = 18;
            double[] x = new double[Periods * PointInPeriod];
            double[] y = new double[Periods * PointInPeriod];
            double step = (Math.PI * 2) / PointInPeriod;
            double arg = 0;
            double timestep = 1.0 / (PointInPeriod * Freq);
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = i * timestep;
                y[i] = Math.Sin(arg + StaPhase);
                arg += step;
            }

            return new Pair<double[], double[]>(x, y);
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
