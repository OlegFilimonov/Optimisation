using System;
using Optimisation.Базовые_и_вспомогательные;

namespace Optimisation.Одномерные
{
    public class ExtrapolationMethod : OneDimMethod
    {
        public ExtrapolationMethod(Function1D f, double eps = 1e-6, int maxIteratons = 50)
            : base(f, null, eps, "Метод ЭКСТРАПОЛЯЦИИ", maxIteratons)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            double eps1 = Eps, eps2 = Eps;
            const double h = 0.01;
            var k = 0;
            var d = (A + B)/2; //random.NextDouble()*(b - a);
            double kr1, kr2; //критерии окончания поиска

            //Основной этап
            do
            {
                A = d - h;
                B = d;
                var c = d + h;
                d = ((F(A)*(Math.Pow(B, 2) - Math.Pow(c, 2))
                      + F(B)*(Math.Pow(c, 2) - Math.Pow(A, 2))
                      + F(c)*(Math.Pow(A, 2) - Math.Pow(B, 2)))
                     /(F(A)*(B - c) + F(B)*(c - A) + F(c)*(A - B)))/2;
                //Критерий близости центральных точек
                kr1 = Math.Abs(d - B)/Math.Abs(B);
                kr2 = Math.Abs(F(d) - F(B))/Math.Abs(F(B));
                k++;
            } while (((kr1 >= eps1) || (kr2 >= eps2)) && (k < MaxIterations));

            IterationCount += k;
            Answer = (B + d)/2;

            if (B < d)
            {
                A = B;
                B = d;
            }
            else
            {
                A = d;
            }
        }
    }
}