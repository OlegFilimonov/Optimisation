using System;
using Optimisation.Базовые_и_вспомогательные;

namespace Optimisation.Одномерные
{
    //Метод золотого сечения 2 - МЗС2
    public class GoldenRatioMethod2 : OneDimMethod
    {
        private readonly double _goldenRight = (-1 + Math.Sqrt(5))/2;

        public GoldenRatioMethod2(Function1D f, double eps = 1e-6, int maxIterations = 50)
            : base(f, null, eps, "Метод ЗОЛОТОГО СЕЧЕНИЯ-2", maxIterations)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            //Начальный этап
            var length = Math.Abs(B - A);
            var x1 = A + _goldenRight*length;
            var k = 0;

            //Основной этап
            do
            {
                var x2 = A + B - x1;

                if ((F(x2) < F(x1)) && (x2 < x1))
                {
                    B = x1;
                    x1 = x2;
                }
                else if ((F(x2) >= F(x1)) && (x2 < x1))
                {
                    A = x2;
                }
                else if ((F(x2) < F(x1)) && (x2 >= x1))
                {
                    A = x1;
                    x1 = x2;
                }
                else if ((F(x2) >= F(x1)) && (x2 >= x1))
                {
                    B = x2;
                }
                k++;
                length = Math.Abs(B - A);
            } while (length > Eps && k < MaxIterations);
            IterationCount = k;

            //Окончание
            Answer = (A + B)/2;
        }
    }
}