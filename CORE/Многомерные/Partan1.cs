using System;
using CORE.Одномерные;
using MathNet.Numerics.LinearAlgebra;

namespace CORE.Многомерные
{
    public class Partan1 : OptimisationMethod
    {
        /// <summary>
        ///     Конструктор многомерного Партан-1
        /// </summary>
        /// <param name="eps"></param>
        /// <param name="f"></param>
        /// <param name="startVector"></param>
        /// <param name="maxIterations"></param>
        public Partan1(double eps, Delegate f, Vector<double> startVector, int maxIterations = 50)
            : base("Партран-1", eps, f, startVector, maxIterations)
        {
        }

        public Partan1() : base("Партан-1", 1e-5, null, null, 50)
        {
        }

        public override void Execute()
        {
            //Подготовка
            var x1 = Fh.Point;

            if (AlphaMethod == null) AlphaMethod = new BoostedDavidon(Fh.AlphaFunction, Fh.AlphaDiffFunction, Eps);
            IterationCount = 0;

            //Основной этап
            do
            {
                //Находим x2
                Fh.Dir = -Fh.Grad();
                Fh.Normilize();

                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha1 = AlphaMethod.Answer;
                if (double.IsNaN(alpha1)) break;
                var x2 = x1 + Fh.Dir.Multiply(alpha1);

                //Находим х3
                Fh.Point = x2;
                Fh.Dir = -Fh.Grad(x2);

                Fh.Normilize();
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha2 = AlphaMethod.Answer;
                if (double.IsNaN(alpha2)) break;
                var x3 = x2 + Fh.Dir.Multiply(alpha2);

                //Находим d
                var d = x3 - x1;
                d = d.Normalize(1);

                //Находим минимум
                Fh.Point = x3;
                Fh.Dir = d;
                Fh.Normilize();
                AlphaMethod.SetSvenInterval();
                AlphaMethod.Execute();
                var alpha3 = AlphaMethod.Answer;
                if (double.IsNaN(alpha3)) alpha3 = 0;
                x1 = x3 + Fh.Dir.Multiply(alpha3);
                Fh.Point = x1;
                IterationCount++;
            } while (Kop1(Fh.Grad(Fh.Point)));

            Answer = Fh.Point;
        }
    }
}