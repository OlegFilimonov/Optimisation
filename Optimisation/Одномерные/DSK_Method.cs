using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    public class DSK_Method : OneDimMethod
    {
        public DSK_Method(function f, bool useStandartInterval = false, int maxIterations = 50)
            : base(f: f,df: null, eps: 1e-6, methodName: "Метод ДСК", maxIterations: maxIterations)
        {
        }

        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;

            var h = 0.01;
            double eps1 = eps, eps2 = eps;
            var k = 0;
            var d = (a + b) / 2;  //random.NextDouble()*(b - a);
            double kr1, kr2; //критерии окончания поиска

            //Основной этап
            do
            {
                h /= 2;
                setSven3Interval(b, h);
                //Формула 3
                d = b + 0.5 *
                     (Math.Pow(b - a, 2) * (f(b) - f(c)) - Math.Pow(b - c, 2) * (f(b) - f(a)))
                    / ((b - a) * (f(b) - f(c)) - (b - c) * (f(b) - f(a)));

                //Критерий близости центральных точек
                kr1 = Math.Abs(d - b) / Math.Abs(b);
                kr2 = Math.Abs(f(d) - f(b)) / Math.Abs(f(b));

                k++;
            } while (((kr1 >= eps1) || (kr2 >= eps2)) && (k < maxIterations));
            iterationCount += k;
            answer = (b + d) / 2;
            b = c;
        }
    }
}
