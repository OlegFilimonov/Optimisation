using System;

namespace CORE.Одномерные
{
    public class Dsk : OneDimMethod
    {
        public Dsk(Function1D f, double eps = 1e-6, int maxIterations = 50)
            : base(f, null, eps, "Метод ДСК", maxIterations)
        {
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            var h = 0.01;
            double eps1 = Eps, eps2 = Eps;
            var k = 0;
            double d; //random.NextDouble()*(b - a);
            double kr1, kr2; //критерии окончания поиска

            //Основной этап
            do
            {
                h /= 2;
                SetSven3Interval(B, h);
                //Формула 3
                d = B + 0.5*
                    (Math.Pow(B - A, 2)*(F(B) - F(C)) - Math.Pow(B - C, 2)*(F(B) - F(A)))
                    /((B - A)*(F(B) - F(C)) - (B - C)*(F(B) - F(A)));

                //Критерий близости центральных точек
                kr1 = Math.Abs(d - B)/Math.Abs(B);
                kr2 = Math.Abs(F(d) - F(B))/Math.Abs(F(B));

                k++;
            } while (((kr1 >= eps1) || (kr2 >= eps2)) && (k < MaxIterations));
            IterationCount += k;
            Answer = (B + d)/2;
            B = C;
        }
    }
}