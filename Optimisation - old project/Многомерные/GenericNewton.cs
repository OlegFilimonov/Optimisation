using System;
using Albatross.Expression.Operations;
using MathNet.Numerics.Differentiation;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    public class GenericNewton : MultiDimMethod
    {
        private readonly int _functonNum;
        private Matrix<double> _hessian;

        public GenericNewton()
           : base("Обобщенный Ньютон",1e-5,null,null)
        {
        }

        public GenericNewton(Vector<double> startVector, Delegate function, double eps = 1e-5, int maxIterations = 50)
            : base("Обобщенный Ньютон", eps, function, startVector, maxIterations)
        {
        }

        public override void Execute()
        {
            var varCount = FH.Point.Count;

            //Подготовка
            Vector<double> p;
            _hessian = new DenseMatrix(varCount, varCount);
            //начальная точка
            var x1 = FH.Point;
            Func<double[],double> castFunc = doubles => FH.Y(new DenseVector(doubles));
            var hessianCalculator = new NumericalHessian();
            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction, FH.AlphaDiffFunction, Eps);
            IterationCount = 0;

            //Основной этап
            do
            {
                //Находим ньютоновское направление - p TODO
                var temp = hessianCalculator.Evaluate(castFunc, x1.ToArray());
                for(var i=0;i<varCount;i++)
                    for (var j = 0; j < varCount; j++)
                        _hessian[i, j] = temp[i, j];
                p = -(_hessian.Inverse())*FH.Grad(x1);
                FH.Dir = p;

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;


                //Переходим на новую точку
                x1 = x1 + FH.Dir*alpha1;

                FH.Point = x1;
                IterationCount++;
            } while (KOP1(FH.Dir) && KOP1(FH.Grad(FH.Point)));

            Answer = FH.Point;
        }
    }
}