using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    class DichotomyMethod : OneDimentionalOptimisationMethod
    {
        public DichotomyMethod(function f, double eps = 1e-6, bool useStandartInterval = false) : 
            base(f, null, eps, "МДх", useStandartInterval)
        {
        }

        protected override void execute()
        {
            //Начальный этап
            var length = Math.Abs(b - a);
            var middle = (a + b)/2;
            var lambda = middle + eps;
            var mu = middle - eps;
            var k = 0;
           

            //Основной этап
            do
            {
                if (f(lambda) >= f(mu))
                {
                    b = mu;
                    length = Math.Abs(b - a);
                    middle = (a + b) / 2;
                    lambda = middle + eps;
                    mu = middle - eps;
                }
                else
                {
                    a = lambda;
                    length = Math.Abs(b - a);
                    middle = (a + b) / 2;
                    lambda = middle + eps;
                    mu = middle - eps;
                }
                k++;

            } while (length > eps && k < MAX_ITERATIONS);
            iterationCount = k;

            //Окончание
            answer = (a + b) / 2;
        }
    }
}
