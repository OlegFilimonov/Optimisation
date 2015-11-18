using System;
using MathNet.Numerics.LinearAlgebra;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation.Многомерные
{
    class Partan1Method : MultiDimMethod
    {
        /// <summary>
        /// Конструктор многомерного Партан-1
        /// </summary>
        /// <param name="eps"></param>
        /// <param name="varCount"></param>
        /// <param name="f"></param>
        /// <param name="startVector"></param>
        /// <param name="maxIterations"></param>
        public Partan1Method(double eps, Delegate f,Vector<double> startVector,int maxIterations = 50) 
            : base("Партран-1", eps, f, startVector,maxIterations)
        {
        }
        
        public override void Execute()
        {
            //Подготовка
            Vector<double> d;
            var x1 = FH.Point;

            //TODO: давидон сам собой не работает, починить!
            if (AlphaMethod == null) AlphaMethod = new DavidonMethod(FH.AlphaFunction,FH.AlphaDiffFunction, Eps);
            IterationCount = 0;
            
            //Основной этап
            do
            {
                //Находим x2
                FH.Normilize();
                AlphaMethod.SetSvenInterval(0,1e-6);
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;
                var x2 = x1 + FH.Dir.Multiply(alpha1);

                //Находим х3
                FH.Point = x2;
                FH.Dir = -FH.Grad(x2);
                FH.Normilize();
                AlphaMethod.SetSvenInterval(0, 1e-6);
                AlphaMethod.Execute();
                var alpha2 = AlphaMethod.Answer;
                var x3 = x2 + FH.Dir.Multiply(alpha2);

                //Находим d
                d = x3 - x1;
                d = d.Normalize(1);

                //Находим минимум
                FH.Point = x3;
                FH.Dir = d;
                FH.Normilize();
                AlphaMethod.SetSvenInterval(0, 1e-6);
                AlphaMethod.Execute();
                var alpha3 = AlphaMethod.Answer;
                if (double.IsNaN(alpha3)) alpha3 = 0;
                x1 = x3 + FH.Dir.Multiply(alpha3);
                FH.Point = x1;

                IterationCount++;

            } while (KOP1(d)&&KOP1(FH.Grad(FH.Point)));

            Answer = FH.Point;
        }
    }
}
