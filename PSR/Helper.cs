using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainModule
{

    public static class Helper
    {
        public static string AsMetricPrefix(this int order)
        {
            switch (order)
            {
                case 1:
                    return "к";
                case 2:
                    return "М";
                case 3:
                    return "Г";
                case 4:
                    return "Т";
                case 5:
                    return "П";
                case -1:
                    return "м";
                case -2:
                    return "мк";
                case -3:
                    return "н";
                case -4:
                    return "п";
                case -5:
                    return "ф";
                default:
                    return "";
            }
        }

        //static public dobule ReduceUnits(this double number, int units)
        //{
        //    int Reduces = 0;
        //    bool isBelowZero = number < 0;
        //    if (isBelowZero) number = Math.Abs(number);
        //    while (number < 0.1 && number != 0)
        //    {
        //        number *= 1000;
        //        Reduces++;
        //        if (Reduces * 3 >= units) break;
        //    }
        //    return number * (isBelowZero ? -1 : 1);
        //}

        static public double GetDelta(this double span)
        {
            if (span >= 10) return 1;
            else if (span >= 1) return 0.1;
            else if (span >= 0.1) return 0.01;
            else if (span >= 0.01) return 0.001;
            else return 1;
        }

        /// <summary>
        /// Сокращает число, возвращая его в виде Number*10^Order .
        /// Order кратно трем.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static public ReducedNumber<double, int> Reduce(this double number)
        {
            int Reduces = 0;

            bool isBelowZero = number < 0;
            if (isBelowZero) number = Math.Abs(number);

            if (number != 0 && !double.IsInfinity(number))
                if (number >= 1000)
                {
                    while (number >= 1000)
                    {
                        number /= 1000;
                        Reduces++;
                    }
                }
                else
                {
                    while (number < 0.1)
                    {
                        number *= 1000;
                        Reduces--;
                    }
                }

            return new ReducedNumber<double, int>(number * (isBelowZero ? -1 : 1), Reduces);
        }

        static public double Reorder(this double number, int Order)
        {
            return number * Math.Pow(1000, Order);
        }

        /// <summary>
        /// Обрезает число до требуемого количества знаков после запятой
        /// </summary>
        /// <param name="num"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        static public double Trim(this double num, int order = 5)
        {
            return ((int)(num * Math.Pow(10, order))) / Math.Pow(10, order);
        }

        static public double MinimalNonZeroFreq(this List<Harmonic> harmonics)
        {
            return harmonics.Where(h => h.Freq != 0).Select(h => h.Freq).Min();
        }

        static public double MaximumNonZeroFreq(this List<Harmonic> harmonics)
        {
            return harmonics.Where(h => h.Freq != 0).Select(h => h.Freq).Max();
        }
    }
}
