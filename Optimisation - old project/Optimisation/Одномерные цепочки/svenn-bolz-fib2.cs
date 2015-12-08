using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Одномерные_цепочки
{
    internal class SvennBolzFib2 : OneDimMethod
    {
        public SvennBolzFib2(double eps = 1e-6, int maxIterations = 50)
            : base(null, null, eps, "М8 Свенн-Больцано-Фибоначчи2", maxIterations)
        {
        }

        public override void Execute()
        {
            OneDimMethod step1 = new BolzanoMethod(F, Df, Eps, 5);
            OneDimMethod step2 = new FibonacciMethod2(F, Eps);
            IterationCount = 0;

            //ШАГ 2
            step1.A = A;
            step1.B = B;
            step1.Execute();


            A = step1.A;
            B = step1.B;

            //ШАГ 3
            step2.A = A;
            step2.B = B;
            step2.Execute();

            A = step2.A;
            B = step2.B;
            Answer = step2.Answer;

            IterationCount += step1.IterationCount;
            IterationCount += step2.IterationCount;
        }
    }
}