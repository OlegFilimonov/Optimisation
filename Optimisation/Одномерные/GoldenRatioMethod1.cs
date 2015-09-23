using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    //Метод Золотого Сечения 1 - МЗС 1
    public class GoldenRatioMethod1 : OneDimMethod
    {
        private readonly double goldenLeft = (3 - Math.Sqrt(5)) / 2;
        private readonly double goldenRight = (-1 + Math.Sqrt(5)) / 2;

        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;

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

            } while (length > eps && k < maxIterations);
            iterationCount = k;

            //Окончание
            answer = (a + b) / 2;
        }

        public GoldenRatioMethod1(function f, double eps = 1e-6, int maxIterations=50)
            : base(f,null, eps,"Метод ЗОЛОТОГО СЕЧЕНИЯ-1",maxIterations)
        {
        }

    }
}
