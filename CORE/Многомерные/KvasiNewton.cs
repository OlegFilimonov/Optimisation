using System;
using CORE.Одномерные;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CORE.Многомерные
{
    public class KvasiNewton : OptimisationMethod
    {
        private Matrix<double> _a;
        private int _varCount;

        public KvasiNewton() : base("Квазиньютонский", 1e-5, null, null)
        {
        }

        public KvasiNewton(double eps, Delegate f, Vector<double> startVector, int maxIterations = 50)
            : base("Квазиньютонский", eps, f, startVector, maxIterations)
        {
        }

        private void CalculateNextMatrix(Vector<double> x1, Vector<double> x2)
        {
            if ((IterationCount == 1))
            {
                _a = Matrix<double>.Build.Diagonal(_varCount, _varCount, 1);
                return;
            }
            var dx = x2 - x1;
            var dy = Fh.Grad(x2) - Fh.Grad(x1);
            if (dy.Maximum() == 0) return; //защита от деления на ноль
            var s = _a*dy;
            var der = dx*dy;
            var slag1 = (dx.ToColumnMatrix()*dx.ToRowMatrix()).Divide(der);
            var slag2 = (s.ToColumnMatrix()*dx.ToRowMatrix()).Divide(der);
            _a = _a + slag1 - slag2;
        }

        public override void Execute()
        {
            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new BoostedDavidon(Fh.AlphaFunction, Fh.AlphaDiffFunction, Eps);

            _varCount = Fh.Point.Count;
            _a = new DenseMatrix(_varCount, _varCount);

            IterationCount = 1;
            var xcur = Fh.Point;
            var xprev = xcur;
            do
            {
                CalculateNextMatrix(xprev, xcur);
                var p = -_a*Fh.Grad(xcur);

                Fh.Dir = p;

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;
                if (double.IsNaN(alpha1))
                {
                    break;
                }

                xprev = xcur;
                xcur = xcur + p*alpha1;
                Fh.Point = xcur;

                IterationCount++;
            } while (Kop1(Fh.Dir) && Kop1(Fh.Grad(Fh.Point)));
            IterationCount--;
            Answer = Fh.Point;
        }
    }
}