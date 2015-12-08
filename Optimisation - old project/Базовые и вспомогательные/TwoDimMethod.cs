using System;
using System.Drawing;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    ///     Базовый класс метода двумерного поиска
    /// </summary>
    public abstract class TwoDimMethod
    {
        //Максимальное количество итераций
        private readonly int MaxIterations;

        protected TwoDimMethod(string name, double eps, FunctionHolderTwoDim f, int maxIterations)
        {
            MaxIterations = maxIterations;
            Name = name;
            Eps = eps;
            F = f;
        }

        //Имя
        public string Name { get; set; }

        //Ответ
        public PointF Answer { get; set; }

        //Альфа-функция
        protected OneDimMethod AlphaMethod { get; set; }

        //Точность
        public double Eps { get; set; }

        //Количество итераций
        public int IterationCount { get; set; }

        //Функция
        public FunctionHolderTwoDim F { protected get; set; }

        //Сам метод
        public abstract void Execute();

        //Свенн-4
        public void SetSven4Interval()
        {
            Normilize(ref F.Dir);
            if (F.Df(0) > 0) F.invDir();
            var alpha = 0.01f;
            while (F.Df(alpha) <= 0)
            {
                alpha *= 2;
            }
            F.Start = F.GetOffset(alpha);
            F.Dir = F.AntiGrad();
        }

        //Разница векторов
        protected static PointF Minus(PointF x1, PointF x2)
        {
            return new PointF(x1.X - x2.X, x1.Y - x2.Y);
        }

        private static double Norm(PointF x)
        {
            return Math.Sqrt(Math.Pow(x.X, 2) + Math.Pow(x.Y, 2));
        }

        protected static void Normilize(ref PointF x)
        {
            var norm = Norm(x);
            x.X = (float) (x.X/norm);
            x.Y = (float) (x.Y/norm);
        }

        //Критерий окончания поиска
        protected bool KOP(PointF d)
        {
            if (IterationCount > MaxIterations || Norm(d) < Eps) return false;
            return true;
        }
    }
}