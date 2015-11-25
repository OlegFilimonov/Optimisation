using System;
using MathNet.Numerics.LinearAlgebra;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    public class GradMethod : MultiDimMethod
    {
        public GradMethod()
            : base("МСГ - Флетчера-Ривса", 1e-5, null, null)
        {
        }

        public GradMethod(double eps, Delegate f, Vector<double> startVector, int maxIterations = 50)
            : base("МСГ - Флетчера-Ривса", eps, f, startVector, maxIterations)
        {
        }

        public override void Execute()
        {
            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction, FH.AlphaDiffFunction, Eps);
            IterationCount = 1;
            var curGrad = FH.Grad(FH.Point);
            var n = FH.Point.Count; // количество переменных
            do
            {
                var prevGrad = curGrad; //предыдущий градиент
                var prevDir = FH.Dir; //предыдущее направление
                curGrad = FH.Grad(FH.Point);
                if ((IterationCount - 1)%n == 0)
                {
                    FH.Dir = -curGrad;
                }
                else
                {
                    //вычисляем бету
                    var beta = Math.Pow(curGrad.Norm(2), 2)/Math.Pow(prevGrad.Norm(2), 2);
                    FH.Dir = -curGrad + prevDir*beta;
                }

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;

                FH.Point += FH.Dir*alpha1;

                IterationCount++;
            } while (KOP1(FH.Dir) && KOP1(FH.Grad(FH.Point)));

            Answer = FH.Point;
            IterationCount--;
        }
    }
}