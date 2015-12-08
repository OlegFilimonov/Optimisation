using System;
using MathNet.Numerics.LinearAlgebra;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    ///     Базовый класс метода двумерного поиска
    /// </summary>
    public abstract class MultiDimMethod
    {
        //Максимальное количество итераций
        protected int MaxIterations;

        protected MultiDimMethod(string name, double eps, Delegate f, Vector<double> startVector, int maxIterations = 50)
        {
            MaxIterations = maxIterations;

            Name = name;
            Eps = eps;
            FH = new FunctionHolderMultiDim(f, startVector);
        }

        //Имя
        public string Name { get; set; }

        //Холдер для функции
        public FunctionHolderMultiDim FH { get; set; }

        //Альфа-функция 
        public OneDimMethod AlphaMethod { get; set; }

        //Ответ
        public Vector<double> Answer { get; set; }

        //Точность
        public double Eps { get; set; }

        //Количество итераций
        public int IterationCount { get; set; }

        //Сам метод
        public abstract void Execute();

        //Свенн-4
        public void SetSven4Interval()
        {
            Vector<double> currPoint, dir;
            currPoint = FH.Point;
            dir = -FH.Grad(currPoint); //Антиградиент
            dir = dir.Normalize(1);
            if (FH.DiffFunction(currPoint, dir) > 0) dir = -dir;
            var alpha = 0.01f;
            while (FH.DiffFunction(currPoint, dir) <= 0)
            {
                alpha *= 2;
                currPoint = currPoint + dir*alpha;
            }
            dir = -FH.Grad(currPoint);
            FH.Point = currPoint;
            FH.Dir = dir;
        }

        /// <summary>
        ///     Критерий окончания поиска - норма вектора меньше епсилона и
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        protected bool KOP1(Vector<double> d)
        {
            return IterationCount <= MaxIterations && !(d.Norm(1) < Eps);
        }
    }
}