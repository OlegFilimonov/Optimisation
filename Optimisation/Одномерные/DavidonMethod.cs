using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    class DavidonMethod : OneDimMethod
    {
        public DavidonMethod(function f, function df, double eps=1e-6, int maxIterations=50) : 
            base(f: f, df: df, eps: eps, methodName: "Метод ДАВИДОНА", maxIterations: maxIterations)
        {
        }

        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;
            
            //Вспомогательная переменная
            double x1 = 0;

            //Основной шаг
            do
            {
                iterationCount ++;
                if(iterationCount > maxIterations) break;

                double z = df(a) + df(b) + 3*(f(a) - f(b))/(b - a);
                double w = Math.Sqrt(Math.Pow(z, 2) - df(a)*df(b));
                double y = (z + w - df(a))/(df(b) - df(a) + 2*w);



                if (y < 0)
                {
                    x1 = a;
                }
                else if (y > 1)
                {
                    x1 = b;
                }
                else
                {
                    x1 = a + y*(b - a);
                }

                double temp = Math.Abs(df(x1));


                if (temp < eps || x1 == a || x1 == b)
                    break;


                if (df(x1) > 0)
                {
                    b = x1;
                }
                else
                {
                    a = x1;
                }
            } while (true);

            answer = x1;

        }
    }
}
