using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    class BFGH : MultiDimMethod
    {
        private int _varCount;
        private Matrix<double> _a; 

        public BFGH(Delegate f, Vector<double> startVector, double eps=1e-5, int maxIterations = 50) : base("Метод БФГШ", eps, f, startVector, maxIterations)
        {
        }

        private void CalculateNextMatrix(Vector<double> x1, Vector<double> x2)
        {

            if ((IterationCount - 1)%_varCount == 0)
            {
                _a = Matrix<double>.Build.Diagonal(_varCount,_varCount,1);
                return;
            }
            var dx = x2 - x1;
            var dy = FH.Grad(x2) - FH.Grad(x1);
            if (dy.Maximum() == 0) return; //защита от деления на ноль
            Vector<double> s = _a*dy;
            var der = dy*s;
            //   _a = _a + (dx.ToColumnMatrix()*dx.ToRowMatrix()).Divide(der) - (s.ToColumnMatrix()*dx.ToRowMatrix()).Divide(der) ;
            _a = _a - (s.ToColumnMatrix()*s.ToRowMatrix()).Divide(der);
        } 

        public override void Execute()
        {

            _varCount = FH.Point.Count;
            _a = new DenseMatrix(_varCount, _varCount);

            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction, FH.AlphaDiffFunction, Eps);
            IterationCount = 1;
            Vector<double> xprev, xcur, p;
            xcur = FH.Point;
            xprev = xcur;
            do
            {
                CalculateNextMatrix(xprev, xcur);
                p = -_a * FH.Grad(xcur);

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
