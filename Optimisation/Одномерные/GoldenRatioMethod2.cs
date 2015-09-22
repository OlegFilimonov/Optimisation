using System;

namespace Optimisation.Одномерные
{
    //Метод золотого сечения 2 - МЗС2
    public class GoldenRatioMethod2 : OneDimMethod
    {
        private readonly double goldenRight = (-1 + Math.Sqrt(5)) / 2;

        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;

            //Начальный этап
            var length = Math.Abs(b - a);
            var x1 = a + goldenRight * length;
            var k = 0;
            double x2;

            //Основной этап
            do
            {
                x2 = a + b - x1;

                if ((f(x2) < f(x1)) && (x2 < x1))
                {
                    b = x1;
                    x1 = x2;
                }
                else if ((f(x2) >= f(x1)) && (x2 < x1))
                {
                    a = x2;
                }
                else if ((f(x2) < f(x1)) && (x2 >= x1))
                {
                     a = x1;
                    x1 = x2;
                }
                else if ((f(x2) >= f(x1)) && (x2 >= x1))
                {
                    b = x2;
                }
                k++;
                length = Math.Abs(b - a);
            } while (length > eps && k < maxIterations);
            iterationCount = k;

            //Окончание
            answer = (a + b) / 2;
        }

        public GoldenRatioMethod2(function f, double eps = 1e-6, int maxIterations=50)
            : base(f,null, eps, "Метод ЗОЛОТОГО СЕЧЕНИЯ-2",maxIterations)
        { }
    }
}

