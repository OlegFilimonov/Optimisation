using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    public class HookeJeeves : MultiDimMethod
    {
        public HookeJeeves()
            : base("Хук-Дживс", 1e-5, null,null)
        {
        }

        public HookeJeeves(double eps, Delegate f, Vector<double> startVector, int maxIterations = 50) 
            : base("Хук-Дживс", eps, f, startVector, maxIterations)
        {
        }

        public override void Execute()
        {
            if(AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction,FH.AlphaDiffFunction);
            IterationCount = 0;
            int varCount = FH.Point.Count;
            Vector<double> x0,d;
            do
            {
                x0 = FH.Point;
                var xn = x0;
                for (int i = 0; i < varCount; i++)
                {
                    FH.Point = xn;
                    FH.Dir = FH.MakeOneVector(varCount,i,1);
                    AlphaMethod.SetSvenInterval();
                    AlphaMethod.Execute();
                    xn = xn + AlphaMethod.Answer*FH.Dir;
                }
                d = xn - x0;
                if(!KOP1(d)) break;
                FH.Point = x0;
                FH.Dir = d;
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                x0 += AlphaMethod.Answer*d;
                FH.Point = x0;
                IterationCount ++;
            } while (KOP1(d));
            
            Answer = x0;
        }
    }
}
