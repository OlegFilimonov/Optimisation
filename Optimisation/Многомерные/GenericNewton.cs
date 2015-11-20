using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jace;
using MathNet.Numerics.Differentiation;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.Office.Core;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    class GenericNewton : MultiDimMethod
    {
        private Matrix<double> _hessian;
        private readonly int _functonNum;

        public GenericNewton( Vector<double> startVector, int functionNum, double eps = 1e-5, int maxIterations = 50)
            : base("Обобщенный Ньютон", eps, getFunction(functionNum), startVector, maxIterations)
        {
            _functonNum = functionNum;
        }

        private static Delegate getFunction(int num)
        {
            Delegate func;
            var engine = new CalculationEngine();
            switch (num)
            {
                case 19:
                    func = (Func<double, double, double>)engine.Formula("100*(x2-x1^2)^2+(1-x1)^2")
               .Parameter("x1", DataType.FloatingPoint)
               .Parameter("x2", DataType.FloatingPoint)
               .Result(DataType.FloatingPoint)
               .Build();
                    break;
                case 20:
                    func = (Func<double, double, double, double>)engine.Formula("(x1-1)^2+(x2-3)^2+4*(x3+5)^2")
               .Parameter("x1", DataType.FloatingPoint)
               .Parameter("x2", DataType.FloatingPoint)
               .Parameter("x3", DataType.FloatingPoint)
               .Result(DataType.FloatingPoint)
               .Build();
                    break;
                default:
                    throw new AccessViolationException("нет такой функции");
            }
            return func;
        }

        private void UpdateHessian(Vector<double> x)
        {
            switch (_functonNum)
            {
                case 19:
                    _hessian[0, 0] = -400*(x[1]) + 1200*x[0]*x[0] + 2;
                    _hessian[0, 1] = -400 * x[0];
                    _hessian[1, 0] = -400*x[0];
                    _hessian[1, 1] = 200;
                    break;
                case 20:
                    _hessian[0, 0] = 2;
                    _hessian[1, 1] = 2;
                    _hessian[2, 2] = 8;
                    break;
                default:
                    throw new AccessViolationException("нет такой функции");
            }
        }

        public override void Execute()
        {
            int varCount = FH.Point.Count;

            //Подготовка
            Vector<double> p;
            _hessian = new DenseMatrix(varCount, varCount);
            //начальная точка
            var x1 = FH.Point;
            Func<double[], double> formula;

            switch (x1.Count)
            {
                case 2:
                    formula = x1Array => ((Func<double, double, double>) FH.F)(x1Array[0], x1Array[1]);
                    break;
                case 3:
                    formula = x1Array => ((Func<double, double,double, double>)FH.F)(x1Array[0], x1Array[1],x1Array[2]);
                    break;
                default:
                    throw new AccessViolationException("NO!");
            }

            NumericalHessian hessianCalculator = new NumericalHessian();
            double[,] matrix = hessianCalculator.Evaluate(formula, x1.ToArray());
            

            //Альфа метод 
            if (AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction, FH.AlphaDiffFunction, Eps);
            IterationCount = 0;

            //Основной этап
            do
            {
                //Находим ньютоновское направление - p
                UpdateHessian(x1);
                p = -(_hessian.Inverse()) * FH.Grad(x1);
                FH.Dir = p;

                //Альфа метод
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;


                //Переходим на новую точку
                x1 = x1 + FH.Dir *alpha1;

                FH.Point = x1;
                IterationCount++;

            } while (KOP1(FH.Dir) && KOP1(FH.Grad(FH.Point)));

            Answer = FH.Point;
        }
    }
}
