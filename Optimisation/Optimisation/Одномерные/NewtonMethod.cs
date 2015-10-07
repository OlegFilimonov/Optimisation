using System;

namespace Optimisation.Одномерные
{
    public class NewtonMethod:OneDimMethod
    {
        private function d2f;

        /// <summary>
        /// Обязательно нужен df2!!!
        /// </summary>
        /// <param name="f">функция</param>
        /// <param name="df">первая производная</param>
        /// <param name="df2">вторая производная</param>
        /// <param name="eps">точность</param>
        /// <param name="maxIterations">кол-во итераций</param>
        public NewtonMethod(function f, function df,function d2f, double eps = 1e-6,int maxIterations = 50) : 
            base(f: f, df: df, eps: eps, methodName: "Метод НЬЮТОНА", maxIterations: maxIterations)
        {
            this.d2f = d2f;
        }

        public override void execute()
        {
            if(d2f == null || df == null) throw new ArgumentNullException();

            a = (a + b) / 2;
            b = a - df(a) / d2f(a);
            iterationCount = 1;
            while ((Math.Abs(a - b) > eps) && (iterationCount < maxIterations))
            {
                a = b;
                b = a - df(a) / d2f(a);
                iterationCount++;
            }

            answer = (a + b)/2;

        }

        public function D2F
        {
            get { return d2f; }
            set { d2f = value; }
        }
    }
}