using System;

namespace CORE.Одномерные
{
    public class Bolzano : OneDimMethod
    {
        public Bolzano(Function1D f, Function1D df, double eps = 1e-6, int maxIterations = 50) :
            base(f, df, eps, "Метод БОЛЬЦАНО", maxIterations)
        {
        }

        public override void Execute()
        {
            //Производная должна существовать для Больцано
            if (Df == null) throw new ArgumentNullException(nameof(Df));

            //Сбрасываем счетчик
            IterationCount = 0;

            //Начальный этап
            var k = 1;
            //Основной этап
            double x, length;
            do
            {
                x = (A + B)/2;
                length = Math.Abs(B - A);
                if (Df(x) > 0)
                {
                    B = x;
                }
                else
                {
                    A = x;
                }
                k++;
            } while (((Math.Abs(Df(x)) > Eps) || (length > Eps)) && (k < MaxIterations));
            x = (A + B)/2;
            IterationCount += k;
            Answer = x;
        }
    }
}