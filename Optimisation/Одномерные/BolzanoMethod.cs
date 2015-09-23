using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    public class BolzanoMethod : OneDimMethod
    {
        public BolzanoMethod(function f,function df, double eps=1e-6, int maxIterations = 50) : 
            base(f,df, eps, "Метод БОЛЬЦАНО",maxIterations)
        {
        }

        public override void execute()
        {
            //Производная должна существовать для Больцано
            if (df == null) throw new ArgumentNullException(nameof(df));

            //Сбрасываем счетчик
            iterationCount = 0;

            //Начальный этап
            var k = 1;
            //Основной этап
            double x, length;
            do
            {

                x = (a + b)/2;
                length = Math.Abs(b - a);
                if (df(x) > 0)
                {
                    b = x;
                }
                else
                {
                    a = x;
                }
                k++;

            } while (((Math.Abs(df(x)) > eps) || (length > eps)) && (k<maxIterations));
            x = (a + b) / 2;
            iterationCount += k;
            answer = x;
        }
    }
}
