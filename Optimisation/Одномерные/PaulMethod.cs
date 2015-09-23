using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    public class PaulMethod : OneDimMethod
    {
        public PaulMethod(function f, function df, double eps = 1e-6, int maxIterations = 50)
            : base(f: f, df: df, eps: eps, methodName: "Метод ПАУЛА",maxIterations: maxIterations)
        {
        }

        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;

            //Начальный этап
            double eps1 = eps, eps2 = eps;
            var h = 0.01;
            var k = 0;
            double d = b + h;
            double kr1, kr2; //критерии окончания поиска
            double chosen;

            //Основной этап
            do
            {
                k++;
                if ((f(b) < f(d)) && (b < d))
                {
                    chosen = b;
                }
                else if ((f(b) >= f(d)) && (b < d))
                {
                    chosen = d;
                }
                else if ((f(b) < f(d)) && (b >= d))
                {
                    chosen = d;
                }
                else
                {
                    chosen = b;
                }

                h /= 2;
                setSven3Interval(chosen, h);

                if (k == 1)
                {
                    d = ((f(a) * (Math.Pow(b, 2) - Math.Pow(c, 2))
                          + f(b) * (Math.Pow(c, 2) - Math.Pow(a, 2))
                          + f(c) * (Math.Pow(a, 2) - Math.Pow(b, 2)))
                         / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b))) / 2;
                }
                else
                {
                    d = (a + b) / 2 + (f(a) - f(b)) * (b - c) * (c - a) / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b)) / 2;
                }

                //Критерий близости центральных точек
                kr1 = Math.Abs(d - b) / Math.Abs(b);
                kr2 = Math.Abs(f(d) - f(b)) / Math.Abs(f(b));
                
            } while (((kr1 >= eps1) || (kr2 >= eps2)) && (k < maxIterations));

            iterationCount += k;

            answer = (b + d) / 2;

            a = b;
            b = d;

        }
    }
}
