using System;
using Optimisation.Базовые_и_вспомогательные;

namespace Optimisation.Одномерные
{
    public class PaulMethod : OneDimMethod
    {
        public PaulMethod(Function1D f, Function1D df, double eps = 1e-6, int maxIterations = 50)
            : base(f, df, eps, "Метод ПАУЛА", maxIterations)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            //Начальный этап
            double eps1 = Eps, eps2 = Eps;
            var h = 0.01;
            var k = 0;
            var d = B + h;
            double kr1, kr2; //критерии окончания поиска

            //Основной этап
            do
            {
                k++;
                double chosen;
                if ((F(B) < F(d)) && (B < d))
                {
                    chosen = B;
                }
                else if ((F(B) >= F(d)) && (B < d))
                {
                    chosen = d;
                }
                else if ((F(B) < F(d)) && (B >= d))
                {
                    chosen = d;
                }
                else
                {
                    chosen = B;
                }

                h /= 2;
                SetSven3Interval(chosen, h);

                if (k == 1)
                {
                    d = ((F(A)*(Math.Pow(B, 2) - Math.Pow(C, 2))
                          + F(B)*(Math.Pow(C, 2) - Math.Pow(A, 2))
                          + F(C)*(Math.Pow(A, 2) - Math.Pow(B, 2)))
                         /(F(A)*(B - C) + F(B)*(C - A) + F(C)*(A - B)))/2;
                }
                else
                {
                    d = (A + B)/2 + (F(A) - F(B))*(B - C)*(C - A)/(F(A)*(B - C) + F(B)*(C - A) + F(C)*(A - B))/2;
                }

                //Критерий близости центральных точек
                kr1 = Math.Abs(d - B)/Math.Abs(B);
                kr2 = Math.Abs(F(d) - F(B))/Math.Abs(F(B));
            } while (((kr1 >= eps1) || (kr2 >= eps2)) && (k < MaxIterations));

            IterationCount += k;

            Answer = (B + d)/2;

            A = B;
            B = d;
        }
    }
}