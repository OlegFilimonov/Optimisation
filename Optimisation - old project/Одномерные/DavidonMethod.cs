using System;
using Optimisation.Базовые_и_вспомогательные;

namespace Optimisation.Одномерные
{
    public class DavidonMethod : OneDimMethod
    {
        public DavidonMethod(Function1D f, Function1D df, double eps = 1e-6, int maxIterations = 50) :
            base(f, df, eps, "Метод ДАВИДОНА", maxIterations)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            //Разгонный метод
            OneDimMethod step1 = new GoldenRatioMethod2(F, Eps);
            step1.SetSvenInterval();
            step1.Execute();
            A = step1.A;
            B = step1.B;

            //Вспомогательная переменная
            double x1 = 0;

            //Основной шаг
            do
            {
                IterationCount ++;
                if (IterationCount >= MaxIterations) break;

                var z = Df(A) + Df(B) + 3*(F(A) - F(B))/(B - A);
                var w = Math.Sqrt(Math.Pow(z, 2) - Df(A)*Df(B));
                var y = (z + w - Df(A))/(Df(B) - Df(A) + 2*w);


                if (y < 0)
                {
                    x1 = A;
                }
                else if (y > 1)
                {
                    x1 = B;
                }
                else
                {
                    x1 = A + y*(B - A);
                }

                var temp = Math.Abs(Df(x1));


                if (temp < Eps || x1 == A || x1 == B)
                    break;


                if (Df(x1) > 0)
                {
                    B = x1;
                }
                else
                {
                    A = x1;
                }
            } while (true);

            Answer = x1;
        }
    }
}