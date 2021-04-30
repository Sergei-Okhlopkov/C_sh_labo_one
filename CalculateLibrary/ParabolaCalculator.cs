using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculateLibrary
{
    public class ParabolaCalculator : ICalculator
    {
       
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            if (n < 0)
            {
                throw new ArgumentException("аргумент n не должен быть меньше 0");
            }

            double h = (b - a) / n;
            double sum = 0.0;
            double sum2 = 0.0;
            for (int i = 1; i <= n; i++)
            {
                var xk = a + i * h;
                if (i <= n - 1)
                {

                    sum += f(xk);
                }

                var xk_1 = a + (i - 1) * h;
                sum2 += f((xk + xk_1) / 2);

            }
            double result = h / 3d * (1d / 2d * f(a) + sum + 2 * sum2 + 1d / 2d * f(b));

            return result;
        }

        public double CalculateParallel(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            if (n < 0)
            {
                throw new ArgumentException("аргумент n не должен быть меньше 0");
            }

            double h = (b - a) / n;
            var sum = new double[n];
            var sum2 = new double[n];
            Array.Clear(sum, 0, sum.Length);
            Array.Clear(sum2, 0, sum2.Length);

            Parallel.For(1, n, i =>
              {
                  var xk = a + i * h;
                  if (i <= n - 1)
                  {

                      sum[i] = f(xk);

                  }

                  var xk_1 = a + (i - 1) * h;

                  sum2[i]= f((xk + xk_1) / 2);


              });
            double summ = sum.Sum(), 
                summ2 = sum2.Sum();
            

            double result = h / 3d * (1d / 2d * f(a) + summ + 2 * summ2 + 1d / 2d * f(b));

            return result;
        }
    }
}
