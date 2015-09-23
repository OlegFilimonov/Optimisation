using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimisation.Одномерные;

namespace Optimisation.Одномерные_цепочки
{
    class extr_dav:OneDimMethod
    {
        public extr_dav(double eps = 1e-6, int maxIterations = 50)
            : base(null, null, eps, "М7 лин. - куб. интерполяции", maxIterations)
        {
        }

        public override void execute()
        {
            OneDimMethod step1, step2;
            step1 = new ExtrapolationMethod(f, eps, 5);
            step2 = new DavidonMethod(f, df, eps);
            iterationCount = 0;
            

            //ШАГ 2
            step1.A = a;
            step1.B = b;
            step1.execute();


            a = step1.A;
            b = step1.B;

            //ШАГ 3
            step2.A = a;
            step2.B = b;
            step2.execute();

            a = step2.A;
            b = step2.B;
            answer = step2.Answer;

            iterationCount += step1.IterationCount;
            iterationCount += step2.IterationCount;
        }
    }
}
