using System;
using MathNet.Numerics.LinearAlgebra;

namespace CORE
{
    /// <summary>
    ///     Базовый класс метода двумерного поиска
    /// </summary>
    public abstract class OptimisationMethod
    {
        //Максимальное количество итераций
        private readonly int _maxIterations;

        protected OptimisationMethod(string name, double eps, Delegate f, Vector<double> startVector,
            int maxIterations = 50)
        {
            _maxIterations = maxIterations;

            Name = name;
            Eps = eps;
            Fh = new FunctionHolder(f, startVector);
        }

        //Имя
        public string Name { get; private set; }

        //Холдер для функции
        public FunctionHolder Fh { protected get; set; }

        //Альфа-функция 
        public OneDimMethod AlphaMethod { protected get; set; }

        //Ответ
        public Vector<double> Answer { get; protected set; }

        //Точность
        public double Eps { protected get; set; }

        //Количество итераций
        public int IterationCount { get; protected set; }

        public int MaxIterations
        {
            get
            {
                return _maxIterations;
            }
        }

        //Сам метод
        public abstract void Execute();

        //Свенн-4
        public void SetSven4Interval()
        {
            var currPoint = Fh.Point;
            var dir = -Fh.Grad(currPoint);
            dir = dir.Normalize(1);
            if (Fh.DiffFunction(currPoint, dir) > 0) dir = -dir;
            var alpha = 0.01f;
            while (Fh.DiffFunction(currPoint, dir) <= 0)
            {
                alpha *= 2;
                currPoint = currPoint + dir*alpha;
            }
            dir = -Fh.Grad(currPoint);
            Fh.Point = currPoint;
            Fh.Dir = dir;
        }

        /// <summary>
        ///     Критерий окончания поиска - норма вектора меньше епсилона и
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        protected bool Kop1(Vector<double> d)
        {
            return IterationCount <= _maxIterations && !(d.Norm(1) < Eps);
        }
    }
}