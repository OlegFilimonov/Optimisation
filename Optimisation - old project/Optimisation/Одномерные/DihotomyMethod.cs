using System;
using Optimisation.Базовые_и_вспомогательные;

namespace Optimisation.Одномерные
{
    public class DichotomyMethod : OneDimMethod
    {
        public DichotomyMethod(Function1D f, double eps = 1e-6, int maxIterations = 50) :
            base(f, null, eps, "Метод ДИХТОМИИ", maxIterations)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            //Начальный этап
            double length;
            var middle = (A + B)/2;
            var lambda = middle + Eps;
            var mu = middle - Eps;
            var k = 0;


            //Основной этап
            do
            {
                if (F(lambda) >= F(mu))
                {
                    B = mu;
                    length = Math.Abs(B - A);
                    middle = (A + B)/2;
                    lambda = middle + Eps;
                    mu = middle - Eps;
                }
                else
                {
                    A = lambda;
                    length = Math.Abs(B - A);
                    middle = (A + B)/2;
                    lambda = middle + Eps;
                    mu = middle - Eps;
                }
                k++;
            } while (length > Eps && k < MaxIterations);
            IterationCount += k;

            //Окончание
            Answer = (A + B)/2;
        }
    }
}