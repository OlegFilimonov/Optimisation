using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    class ExtrapolationMethod : OneDimentionalOptimisationMethod
    {
        public ExtrapolationMethod(function f, function df = null, double eps = 1e-6)
            : base(f, df, eps, "ЭКС", false)
        {
        }

        protected override void execute()
        {
            var random = new Random(DateTime.Now.Millisecond);
            //Начальный этап
            var tempGoldenRatioMethod2 = new GoldenRatioMethod2(f, 1e-6, 5);
            iterationCount += 5;
            a = tempGoldenRatioMethod2.A;
            b = tempGoldenRatioMethod2.B;
            
            double eps1 = eps, eps2 = eps;
            const double h = 0.01;
            var k = 0;
            var d = (a + b)/2;  //random.NextDouble()*(b - a);
            double kr1, kr2; //критерии окончания поиска

            //Основной этап
            do
            {
                a = d - h;
                b = d;
                var c = d + h;
                d = ((f(a) * (Math.Pow(b, 2) - Math.Pow(c, 2))
                    + f(b) * (Math.Pow(c, 2) - Math.Pow(a, 2))
                    + f(c) * (Math.Pow(a, 2) - Math.Pow(b, 2)))
                    / (f(a) * (b - c) + f(b) * (c - a) + f(c) * (a - b))) / 2;
                //Критерий близости центральных точек
                kr1 = Math.Abs(d - b) / Math.Abs(b);
                kr2 = Math.Abs(f(d) - f(b)) / Math.Abs(f(b));
                Console.WriteLine(methodName + ": Итерация № " + k + ", \tТИЛ: [" + a + ";" + b + "]");
                k++;
            } while ((kr1 >= eps1) && (kr2 >= eps2));
            iterationCount += k;
            answer = (b + d) / 2;
        }
    }
}
