using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;
using Optimisation.Одномерные;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    /// Базовый класс метода двумерного поиска
    /// </summary>
    public abstract class TwoDimMethod
    {
        //Максимальное количество итераций
        private int MaxIterations = 50;

        //Имя
        public string Name { get; set; }

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
        public void SetSvenn4Interval()
        {
            Normilize(ref F.Dir);
            if(F.Df(0) < 0) F.invDir();
            var alpha = 0.01f;
            while (F.Df(0) > 0)
            {
                F.Start.X += alpha;
                F.Start.Y += alpha;
                alpha *= 2;
            }
        }

        protected static PointF Minus(PointF x1, PointF x2)
        {
            return new PointF(x1.X-x2.X,x1.Y-x2.Y);
        }

        protected static double Norm(PointF x)
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
            return IterationCount < MaxIterations || Norm(d) > Eps;
        }
    }
}
