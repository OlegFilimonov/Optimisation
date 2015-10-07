using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные.Цепочки
{
    class svenn_dih_newt: OneDimMethod
    {
        private function d2f;

        public svenn_dih_newt( double eps = 1e-6, int maxIterations = 50) : 
            base(null,null,eps, "М5 - Свенн - дихтомии - Ньютона", maxIterations)
        {
        }

        //TODO: узнать что такое касты

        public override void execute()
        {
            OneDimMethod step1, step2;
            step1 = new DichotomyMethod(f,eps,3);
            step2 = new NewtonMethod(f,df,d2f,eps,3);

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

        public function D2F
        {
            get { return d2f; }
            set { d2f = value; }
        }
    }
}
