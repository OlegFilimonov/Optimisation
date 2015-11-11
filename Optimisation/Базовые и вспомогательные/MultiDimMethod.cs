using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex32;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    /// Базовый класс метода двумерного поиска
    /// </summary>
    public abstract class MultiDimMethod
    {
        //Имя
        public string Name { get; set; }

        //Холдер для функции
        public FunctionHolderMultiDim FH { get; set; }

        //Альфа-функция 
        protected OneDimMethod AlphaMethod { get; set; }

        //Ответ
        public Vector<double> Answer { get; set; }
       
        //Точность
        public double Eps { get; set; }

        //Количество итераций
        public int IterationCount { get; set; }
        
        //Максимальное количество итераций
        protected int MaxIterations;

        //Сам метод
        public abstract void Execute();
        
        //Свенн-4
        public void SetSven4Interval()
        {
            Vector<double> currPoint, dir;
            currPoint = FH.Point;
            dir = -FH.Grad(currPoint); //Антиградиент
            dir = dir.Normalize(1);
            if (FH.DiffFunction(currPoint,dir) > 0) dir = -dir;
            var alpha = 0.01f;
            while (FH.DiffFunction(currPoint,dir) <= 0)
            {
                alpha *= 2;
                currPoint = currPoint + dir*alpha;
            }
            dir = -FH.Grad(currPoint);
            FH.Point = currPoint;
            FH.Dir = dir;
        }

        /// <summary>
        /// Критерий окончания поиска - норма вектора меньше епсилона и 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        protected bool KOP1(Vector<double> d)
        {
            return IterationCount <= MaxIterations && !(d.Norm(1) < Eps);
        }

        
        

        protected MultiDimMethod(string name, double eps, Delegate f,Vector<double> startVector, int maxIterations=50)
        {
            MaxIterations = maxIterations;
            
            Name = name;
            Eps = eps;
            FH = new FunctionHolderMultiDim(f,startVector);
        }
    }
}
