using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Двумерные
{
    class CauchyMethod : TwoDimMethod
    {
        public CauchyMethod(FunctionHolderTwoDim f,double eps=1e-2, int maxIterations = 50) :
            base("Метод КОШИ", eps, f, maxIterations)
        {
        }

        public override void Execute()
        {
            if(AlphaMethod == null) AlphaMethod = new DavidonMethod(F.F, F.Df, Eps);
            IterationCount = 0;
            PointF d;
            do
            {
                AlphaMethod.SetSvenInterval(0);
                AlphaMethod.Execute();
                double alpha = AlphaMethod.Answer;
                d = Minus(F.Start, F.GetOffset(alpha));
                F.Start = F.GetOffset(alpha);
                F.Dir = F.AntiGrad();
                IterationCount++;
            } while (KOP(d));
            Answer = F.Start;
        }
    }
}
