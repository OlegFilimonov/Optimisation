using System;
using CORE.Одномерные;
using MathNet.Numerics.LinearAlgebra;

namespace CORE.Многомерные
{
    public class HookeJeeves : OptimisationMethod
    {
        public HookeJeeves()
            : base("Хук-Дживс [Из методы]", 1e-5, null, null)
        {
        }

        public HookeJeeves(double eps, Delegate f, Vector<double> startVector, int maxIterations = 50)
            : base("Хук-Дживс [Из методы]", eps, f, startVector, maxIterations)
        {
        }

        public override void Execute()
        {
            if (AlphaMethod == null) AlphaMethod = new BoostedDavidon(Fh.AlphaFunction, Fh.AlphaDiffFunction);
            IterationCount = 0;
            var varCount = Fh.Point.Count;
            Vector<double> x0, d;
            do
            {
                x0 = Fh.Point;
                var xn = x0;
                for (var i = 0; i < varCount; i++)
                {
                    Fh.Point = xn;
                    Fh.Dir = Fh.MakeOneVector(varCount, i, 1);
                    AlphaMethod.SetSvenInterval();
                    AlphaMethod.Execute();
                    xn = xn + AlphaMethod.Answer*Fh.Dir;
                }
                d = xn - x0;
                if (!Kop1(d)) break;
                Fh.Point = x0;
                Fh.Dir = d;
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                x0 += AlphaMethod.Answer*d;
                Fh.Point = x0;
                IterationCount ++;
            } while (Kop1(d));

            Answer = x0;
        }
    }
}