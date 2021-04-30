using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CalculateLibrary
{
    
    public class RectangleCalculator : ICalculator //реализация интерфейса
    {
       
        public double Calculate(double a, double b, long n, Func<double, double> f)
        {
            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            if (n < 0)
            {
                throw new ArgumentException("аргумент n не должен быть меньше 0");
            }

            double h = (b - a) / n;
            a += h * 0.5;

            double sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += f(a + h * i);
            }

            return sum*h;
        }

        public double CalculateParallel(double a, double b, long n, Func<double, double> f)
        {

            if ((a < 0) | (b < 0)) throw new ArgumentException("a или b меньше допустимо значения");

            if (n < 0)
            {
                throw new ArgumentException("аргумент n не должен быть меньше 0");
            }

            double h = (b - a) / n;
            a += h * 0.5;

            var sum = new double[n];
            Parallel.For(0, n, i => {
                
                sum[i]= f(a + h * i);
                

            });
            

            return sum.Sum() * h;
        }
    }
}
