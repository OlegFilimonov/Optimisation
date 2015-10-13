using System;
using Optimisation.Базовые_и_вспомогательные;

namespace Optimisation.Одномерные
{
    //Метод Золотого Сечения 1 - МЗС 1
    public class GoldenRatioMethod1 : OneDimMethod
    {
        private readonly double _goldenLeft = (3 - Math.Sqrt(5))/2;
        private readonly double _goldenRight = (-1 + Math.Sqrt(5))/2;

        public GoldenRatioMethod1(Function1D f, double eps = 1e-6, int maxIterations = 50)
            : base(f, null, eps, "Метод ЗОЛОТОГО СЕЧЕНИЯ-1", maxIterations)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            //Начальный этап
            var length = Math.Abs(B - A);
            var lambda = A + _goldenLeft*length;
            var mu = A + _goldenRight*length;
            var k = 0;

            //Основной этап
            do
            {
                if (F(lambda) < F(mu))
                {
                    B = mu;
                    length = Math.Abs(B - A);
                    mu = lambda;
                    lambda = A + _goldenLeft*length;
                }
                else
                {
                    A = lambda;
                    lambda = mu;
                    length = Math.Abs(B - A);
                    mu = A + _goldenRight*length;
                }
                k++;
            } while (length > Eps && k < MaxIterations);
            IterationCount = k;

            //Окончание
            Answer = (A + B)/2;
        }
    }
}