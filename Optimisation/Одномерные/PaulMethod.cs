using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    class PaulMethod : OneDimentionalOptimisationMethod
    {
        public PaulMethod(function f, function df, double eps = 1e-6, bool useStandartInterval = false)
            : base(f, df, eps, "PAUL", useStandartInterval)
        {
        }

        protected override void execute()
        {
            //Разгонный метод
            var tempGoldenRatioMethod2 = new GoldenRatioMethod2(f, 1e-6, 5);
            iterationCount += 5;
            a = tempGoldenRatioMethod2.A;
            c = tempGoldenRatioMethod2.B;
            b = (a + c) / 2;
           

            //Начальный этап
            double eps1 = eps, eps2 = eps;
            var h = 0.01;
            var k = 0;
            double d;
            double kr1, kr2; //критерии окончания поиска
            double chosen;

            //Основной этап
            do
            {
                k++;

                h /= 2;
                setSven3Interval(b,h);

                if (k == 1)
                {
                    
                }


                if ((f(b) < f(d)) && (b < d))
                {
                    chosen = d;
                }
                else if ((f(b) >= f(d)) && (b < d))
                {
                    chosen = b;
                }
                else if ((f(b) < f(d)) && (b >= d))
                {
                    chosen = b;
                }
                else if ((f(b) >= f(d)) && (b >= d))
                {
                    chosen = d;
                }

                //Критерий близости центральных точек
                kr1 = Math.Abs(d - b) / Math.Abs(b);
                kr2 = Math.Abs(f(d) - f(b)) / Math.Abs(f(b));


                Console.WriteLine(methodName + ": Итерация № " + k + ", \tТИЛ: [" + a + ";" + b + "]");
            } while ((kr1 >= eps1) || (kr2 >= eps2));
            iterationCount += k;
            answer = (b + d) / 2;

        }
    }
}
