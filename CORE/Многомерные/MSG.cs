using System;
using CORE.Одномерные;
using MathNet.Numerics.LinearAlgebra;

namespace CORE.Многомерные
{
    public class Msg : OptimisationMethod
    {
        public Msg()
            : base("МСГ - Флетчера-Ривса", 1e-5, null, null, 50)
        {
        }

        public Msg(double eps, Delegate f, Vector<double> startVector, int maxIterations = 50)
            : base("МСГ - Флетчера-Ривса", eps, f, startVector, maxIterations)
        {
        }

        public override void Execute()
        {
            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new BoostedDavidon(Fh.AlphaFunction, Fh.AlphaDiffFunction, 1e-25);
            IterationCount = 1;
            var curGrad = Fh.Grad(Fh.Point);
            var n = Fh.Point.Count; // количество переменных
            do
            {
                
                var prevGrad = curGrad; //предыдущий градиент
                var prevDir = Fh.Dir; //предыдущее направление
                curGrad = Fh.Grad(Fh.Point);
                if ((IterationCount - 1)%n == 0)
                {
                    Fh.Dir = -curGrad;
                }
                else
                {
                    var gamma = curGrad - prevGrad;
                    var beta = curGrad*gamma/(prevDir*gamma); //Math.Pow(curGrad.Norm(2), 2)/Math.Pow(prevGrad.Norm(2), 2);
                    Fh.Dir = -curGrad + prevDir*beta;
                }

                if (!Kop1(Fh.Grad(Fh.Point))) break;

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;
                Fh.Point += Fh.Dir*alpha1;
                IterationCount++;
            } while (Kop1(Fh.Dir) && Kop1(Fh.Grad(Fh.Point)));

            Answer = Fh.Point;
            IterationCount--;
        }
    }
}