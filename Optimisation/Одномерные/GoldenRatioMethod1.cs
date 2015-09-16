using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    //Метод Золотого Сечения 1 - МЗС 1
    class GoldenRatioMethod1 : OneDimentionalOptimisationMethod
    {
        private readonly double goldenLeft = (3 - Math.Sqrt(5)) / 2;
        private readonly double goldenRight = (-1 + Math.Sqrt(5)) / 2;

        protected override void execute()
        {

            //Начальный этап
            var length = Math.Abs(b - a);
            var lambda = a + goldenLeft * length;
            var mu = a + goldenRight * length;
            var k = 0;

            //Основной этап
            do
            {
                if (f(lambda) < f(mu))
                {
                    b = mu;
                    length = Math.Abs(b - a);
                    mu = lambda;
                    lambda = a + goldenLeft * length;
                }
                else
                {
                    a = lambda;
                    lambda = mu;
                    length = Math.Abs(b - a);
                    mu = a + goldenRight * length;
                }
                k++;
                Console.WriteLine(methodName + ": Итерация № " + k + ", \tТИЛ: [" + a + ";" + b + "]");

            } while (length > eps && k < maxIterations);
            iterationCount = k;

            //Окончание
            answer = (a + b) / 2;
        }

        public GoldenRatioMethod1(function f, double eps = 1e-6, bool useStandartInterval = false)
            : base(f,null, eps,"МЗС1", useStandartInterval)
        {
        }

    }
}
