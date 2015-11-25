using System;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    public class KvasiNewton : MultiDimMethod
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
            var dy = FH.Grad(x2) - FH.Grad(x1);
            if (dy.Maximum() == 0) return; //защита от деления на ноль
            var s = _a*dy;
            var der = dx*dy;
            var slag1 = (dx.ToColumnMatrix()*dx.ToRowMatrix()).Divide(der);
            var slag2 = (s.ToColumnMatrix()*dx.ToRowMatrix()).Divide(der);
            _a = _a + slag1 - slag2;
           // _a = _a - (s.ToColumnMatrix()*s.ToRowMatrix()).Divide(der);
        }

        public override void Execute()
        {
            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction, FH.AlphaDiffFunction, Eps);

            _varCount = FH.Point.Count;
            _a = new DenseMatrix(_varCount, _varCount);

            IterationCount = 1;
            Vector<double> xprev, xcur, p;
            xcur = FH.Point;
            xprev = xcur;
            do
            {
                CalculateNextMatrix(xprev, xcur);
                p = -_a*FH.Grad(xcur);

                FH.Dir = p;

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;

                xprev = xcur;
                xcur = xcur + p*alpha1;
                FH.Point = xcur;

                IterationCount++;
            } while (KOP1(FH.Dir) && KOP1(FH.Grad(FH.Point)));

            IterationCount--;
            Answer = FH.Point;
        }
    }
}