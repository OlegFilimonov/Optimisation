using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    public class DichotomyMethod : OneDimMethod
    {
        

        public DichotomyMethod(function f, double eps = 1e-6, int maxIterations = 50) :
            base(f: f, df: null, eps: eps, methodName: "Метод ДИХТОМИИ",maxIterations: maxIterations)
        {
        }

        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;

            //Начальный этап
            var length = Math.Abs(b - a);
            var middle = (a + b) / 2;
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

            } while (length > eps && k < maxIterations);
            iterationCount = k;

            //Окончание
            answer = (a + b) / 2;
        }
    }
}
