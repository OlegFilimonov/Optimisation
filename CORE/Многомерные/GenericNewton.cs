using System;
using CORE.Одномерные;
using MathNet.Numerics.Differentiation;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CORE.Многомерные
{
    public class GenericNewton : OptimisationMethod
    {
        private Matrix<double> _hessian;

        public GenericNewton()
            : base("Обобщенный Ньютон", 1e-5, null, null)
        {
        }

        public GenericNewton(Vector<double> startVector, Delegate function, double eps = 1e-5, int maxIterations = 50)
            : base("Обобщенный Ньютон", eps, function, startVector, maxIterations)
        {
        }

        public override void Execute()
        {
            var varCount = Fh.Point.Count;

            //Подготовка
            _hessian = new DenseMatrix(varCount, varCount);
            //начальная точка
            var x1 = Fh.Point;
            Func<double[], double> castFunc = doubles => Fh.Y(new DenseVector(doubles));
            var hessianCalculator = new NumericalHessian();
            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new BoostedDavidon(Fh.AlphaFunction, Fh.AlphaDiffFunction, Eps);
            IterationCount = 0;

            //Основной этап
            do
            {
                if (!Kop1(Fh.Grad(Fh.Point))) break;
                //Находим ньютоновское направление - p TODO
                var temp = hessianCalculator.Evaluate(castFunc, x1.ToArray());
                for (var i = 0; i < varCount; i++)
                    for (var j = 0; j < varCount; j++)
                        _hessian[i, j] = temp[i, j];
                var p = -(_hessian.Inverse())*Fh.Grad(x1);
                Fh.Dir = p;

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;


                //Переходим на новую точку
                x1 = x1 + Fh.Dir*alpha1;

                Fh.Point = x1;
                IterationCount++;
            } while (Kop1(Fh.Dir) && Kop1(Fh.Grad(Fh.Point)));

            Answer = Fh.Point;
        }
    }
}