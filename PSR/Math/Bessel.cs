namespace MainModule
{
    public class Bessel
    {
        //----ВОЗВРАЩАЕТ ФУНКЦИЮ БЕССЕЛЯ ПЕРВОГО РОДА   Jn(x)----------------------
        //double bessel(int n, double x);
        //                             n-ПОРЯДОК ФУНКЦИИ
        //                             X-АРГУМЕНТ
        //-------------------------------------------------------------------------
        static public double bessel(int n, double x)
        {
            double an, bn, n2, arg, J = 0, J0 = 0, J1 = 0, pi = 3.1415926536;
            double ind, factr;
            int j, zn = 1;
            if (n < 0)
            {
                zn = -1;
                n = -n;
            };
            if (x != 0)
            {
                if (x > 6)
                {
                    n2 = 0;
                    an = 1.0 - (((double)n2 - 1.0) * ((double)n2 - 9.0) / (2.0 * 64.0 * x * x)) + (((double)n2 - 1.0) * ((double)n2 - 9.0) * ((double)n2 - 25.0) * ((double)n2 - 49.0) / (24.0 * 64.0 * 64.0 * x * x * x * x));
                    bn = ((double)n2 - 1.0) / (8.0 * x) - (((double)n2 - 1.0) * ((double)n2 - 9.0) * ((double)n2 - 25.0) / (6.0 * 8.0 * 8.0 * 8.0 * x * x * x));
                    arg = x - pi / 4.0;
                    J0 = System.Math.Sqrt(2.0 / (pi * x)) * (an * System.Math.Cos(arg) - bn * System.Math.Sin(arg));
                    if (n != 0)
                    {
                        n2 = 4;
                        an = 1.0 - (((double)n2 - 1.0) * ((double)n2 - 9.0) / (2.0 * 64.0 * x * x)) + (((double)n2 - 1.0) * ((double)n2 - 9.0) * ((double)n2 - 25.0) * ((double)n2 - 49.0) / (24.0 * 64.0 * 64.0 * x * x * x * x));
                        bn = ((double)n2 - 1.0) / (8.0 * x) - (((double)n2 - 1.0) * ((double)n2 - 9.0) * ((double)n2 - 25.0) / (6.0 * 8.0 * 8.0 * 8.0 * x * x * x));
                        arg = x - 3.0 * pi / 4.0;
                        J1 = System.Math.Sqrt(2.0 / (pi * x)) * (an * System.Math.Cos(arg) - bn * System.Math.Sin(arg));
                    };
                }
                else
                {
                    J0 = 1.0;
                    J1 = x / 2.0;
                    factr = 1.0;
                    for (j = 1; j <= 10; j++)
                    {
                        ind = System.Math.Pow(-1.0, j);
                        factr = factr * (double)j;
                        J0 = J0 + ind * System.Math.Pow(x / 2.0, 2.0 * (double)j) / (factr * factr);
                        if (n != 0) J1 = J1 + ind * System.Math.Pow(x / 2.0, (1.0 + 2.0 * (double)j)) / (factr * factr * ((double)j + 1.0));
                    };
                };
            };
            if ((x == 0) && (n == 0)) J = 1.0;
            if ((x == 0) && (n > 0)) J = 0.0;
            if ((x != 0) && (n == 0)) J = J0;
            if ((x != 0) && (n == 1)) J = J1;
            if ((x != 0) && (n > 1))
            {
                if (n > (x + 6)) J = 0.0;
                else
                {
                    j = 1;
                    do
                    {
                        J = 2.0 * (double)j * J1 / x - J0;
                        j++;
                        J0 = J1;
                        J1 = J;
                    } while (j < n);
                };
            };
            J = J * System.Math.Pow(zn, n);
            return J;
        }
    }
}
