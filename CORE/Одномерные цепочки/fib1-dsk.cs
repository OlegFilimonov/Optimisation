using CORE.Одномерные;

namespace CORE.Одномерные_цепочки
{
    public class Fib1Dsk : OneDimMethod
    {
        public Fib1Dsk(double eps = 1e-6, int maxIterations = 50)
            : base(null, null, eps, "М1 Фибоначчи-1 - ДСК", maxIterations)
        {
        }

        public override void Execute()
        {
            OneDimMethod step1 = new Fibonacci1(F, Eps, 5);
            OneDimMethod step2 = new Dsk(F, Eps);
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