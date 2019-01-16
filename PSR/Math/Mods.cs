namespace MainModule
{
    public class Mods
    {
        public static double ampl = 1, f_min = 0, f_max = 0;
        public static double S_max = 0, S_min = 0;
        public static double f_min_view = 0, f_max_view = 0;

        //Переменные для рекурсии
        static double[] iS, iF, iindex;
        static double iF0;
        static int[] RecursionsCycles;

        static void FireInDaHole(int[] chms, int my_index)
        {
            for (int i = -chms[my_index]; i <= chms[my_index]; i++)
            {
                RecursionsCycles[my_index] = i;

                if (my_index == chms.Length - 1)    //запустили последний цикл
                {
                    double test = iF0;  // + i * iF[0] + j * iF[1] + t * iF[2];
                    for (int k = 0; k < RecursionsCycles.Length; k++)
                        test += RecursionsCycles[k] * iF[k];

                    if (test < f_min || test > f_max) continue;

                    int p = (int)(iS.Length * (/*iF0 + i * iF[0] + j * iF[1] + t * iF[2]*/test - f_min) / (f_max - f_min));

                    double bs = ampl;
                    for (int k = 0; k < RecursionsCycles.Length; k++)
                        bs *= Bessel.bessel(RecursionsCycles[k], iindex[k]);
                    iS[p] += bs; // + ampl * Bessel.bessel(i, iindex[0]) * Bessel.bessel(j, iindex[1]) * Bessel.bessel(t, iindex[2]);

                    if (System.Math.Abs(iS[p]) > S_max) S_max = System.Math.Abs(iS[p]);
                    if (System.Math.Abs(iS[p]) < S_min) S_min = System.Math.Abs(iS[p]);
                }
                else
                {
                    FireInDaHole(chms, my_index+1);
                }
            }
        }

        static public void Chm(double[] S, double[] index, double[] F, double f0)
        //               S - массив данных
        //               index -массив с индексами модуляции
        //               F1,F2 -массив с частотами модулирующих сигналов
        //               f0 -  частота несущей
        {
            iS = S;
            iF = F;
            iindex = index;
            iF0 = f0;
            double sp_width, index_max, F_max;
            int[] num_chm = new int[index.Length];
            int i = 0;
            //--------------вычисление ширины спектра----------------------

            for (i = 0; i < index.Length; i++)
                num_chm[i] = (int)(1 + index[i] + System.Math.Sqrt(index[i]));   //количество дискретных значений

            F_max = F[0];
            index_max = index[0];

            for (i = 0; i < index.Length; i++)
            {
                if (index[i] > index_max)
                {
                    F_max = F[i];
                    index_max = index[i];
                }
            }

            for (i = 0; i < S.Length; i++)
                S[i] = 0;

            sp_width = 0;
            for (i = 0; i < index.Length; i++)
                sp_width = sp_width + 2.0 * F[i] * (1 + index[i] + System.Math.Sqrt(index[i]));
            //--------------------------------------------------------------
            double sp_width1 = 5.0 * sp_width;

            f_min = f0 - System.Math.Ceiling(sp_width1 / (2.0 * F_max)) * F_max;
            f_max = f0 + System.Math.Ceiling(sp_width1 / (2.0 * F_max)) * F_max;

            //int fMinInt = (int)f_min + 1;
            //int fMaxInt = (int)f_max - 1;
            //while((fMinInt/10)*10 != fMinInt) fMinInt++;
            //while((fMaxInt/10)*10 != fMaxInt) fMaxInt--;
            //f_min_view = (double)fMinInt;
            //f_max_view = (double)fMaxInt;

            f_min_view = f0 - System.Math.Ceiling(sp_width / (2.0 * F_max)) * F_max;
            f_max_view = f0 + System.Math.Ceiling(sp_width / (2.0 * F_max)) * F_max;

            if (f_min_view >= f_max_view)
            {
                f_min_view = f_min;
                f_max_view = f_max;
            }

            S_min = 0;
            S_max = 0;
            RecursionsCycles = new int[num_chm.Length];
            FireInDaHole(num_chm, 0);
            //for (i = -num_chm[0]; i <= num_chm[0]; i++)
            //{
            //    for (int j = -num_chm[1]; j <= num_chm[1]; j++)
            //    {
            //        for (int t = -num_chm[2]; t <= num_chm[2]; t++)
            //        {
            //            if ((f0 + i * F[0] + j * F[1] + t * F[2]) < f_min || (f0 + i * F[0] + j * F[1] + t * F[2]) > f_max) continue;
            //            int p = (int)(S.Length * (f0 + i * F[0] + j * F[1] + t * F[2] - f_min) / (f_max - f_min));
            //            S[p] = S[p] + ampl * Bessel.bessel(i, index[0]) * Bessel.bessel(j, index[1]) * Bessel.bessel(t, index[2]);
            //            if (System.Math.Abs(S[p]) > S_max) S_max = System.Math.Abs(S[p]);
            //            if (System.Math.Abs(S[p]) < S_min) S_min = System.Math.Abs(S[p]);
            //        }
            //    }
            //}

            for (i = 0; i < S.Length; i++)
                S[i] = System.Math.Abs(S[i]);

            double d = 0.1 * (S_max - S_min);
            S_max += d;
            S_min -= d;

            if ((S_max - S_min) < 0.01)
            {
                S_min = 0;
                S_max = 0.01;
            }

            //string test = $"{S_max}";
        }
    }
}
