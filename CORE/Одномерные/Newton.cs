using System;

namespace CORE.Одномерные
{
    public class Newton : OneDimMethod
    {
        /// <summary>
        ///     Обязательно нужен df2!!!
        /// </summary>
        /// <param name="f">функция</param>
        /// <param name="df">первая производная</param>
        /// <param name="d2f">вторая производная</param>
        /// <param name="eps">точность</param>
        /// <param name="maxIterations">кол-во итераций</param>
        // ReSharper disable once InconsistentNaming
        public Newton(Function1D f, Function1D df, Function1D d2f, double eps = 1e-6, int maxIterations = 50) :
            base(f, df, eps, "Метод НЬЮТОНА", maxIterations)
        {
            D2F = d2f;
        }

        private Function1D D2F { get; }

        public override void Execute()
        {
            if (D2F == null || Df == null) throw new ArgumentNullException();

            A = (A + B)/2;
            B = A - Df(A)/D2F(A);
            IterationCount = 1;
            while ((Math.Abs(A - B) > Eps) && (IterationCount < MaxIterations))
            {
                A = B;
                B = A - Df(A)/D2F(A);
                IterationCount++;
            }

            Answer = (A + B)/2;
        }
    }
}