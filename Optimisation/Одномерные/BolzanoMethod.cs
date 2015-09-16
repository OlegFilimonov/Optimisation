using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    class BolzanoMethod : OneDimentionalOptimisationMethod
    {
        public BolzanoMethod(function f,function df, double eps=1e-6, bool useStandartInterval = false) : 
            base(f,df, eps, "МБц", useStandartInterval=false)
        {
            //Производная должна существовать для Больцано
            if (df == null) throw new ArgumentNullException(nameof(df));
        }

        protected override void execute()
        {
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
                Console.WriteLine(methodName + ": Итерация № " + k + ", \tТИЛ: [" + a + ";" + b + "]");
            } while (((Math.Abs(df(x)) > eps) || (length > eps)) && (k<maxIterations));
            x = (a + b) / 2;
            iterationCount = k;
            answer = x;
        }
    }
}
