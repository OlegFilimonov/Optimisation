using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    /// Базовый класс метода двумерного поиска
    /// </summary>
    public abstract class MultiDimMethod
    {
        //Имя
        private string Name { get; set; }

        //Холдер для функции
        protected FunctionHolderMultiDim FunctionHolder;

        //Альфа-функция
        protected OneDimMethod AlphaMethod { get; set; }

        //Ответ
        public Vector<double> Answer { get; set; }

        //Текущая точка
        public Vector<double> CurrPoint { get; set; } 

        //Направление поиска
        public Vector<double> Dir { get; set; }
       
        //Точность
        private double Eps { get; set; }

        //Количество итераций
        private int IterationCount { get; set; }
        
        //Максимальное количество итераций
        private int MaxIterations;

        //Сам метод
        public abstract void Execute();
        
        /// <summary>
        /// Создает вектор со всеми нулями, но со значением value на позиции pos
        /// </summary>
        /// <param name="varCount"></param>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Vector<double> makeOneVector(int varCount, int pos, double value)
        {
            var res = Vector<double>.Build.Dense(varCount);
            res[pos] = value;
            return res;
        }

        /// <summary>
        /// Функция численного дифференцирования
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double DiffFunction(Vector<double> point, Vector<double> dir)
        {
            return Grad(point)*dir;
        }

        /// <summary>
        /// Численное дифференцирование градиента
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private Vector<double> Grad(Vector<double> point)
        {
            var h = 1e-5;
            var varCount = point.Count;
            var g = Vector<double>.Build.Dense(varCount); // Создали вектор частных производных
            for (int i = 0; i < varCount; i++)
            {
                var hVector = makeOneVector(varCount, i, h);
                g[i] = (FunctionHolder.Y(point[i] + hVector) - FunctionHolder.Y(point[i] - hVector)) / (2 * h);
            }
            return g;
        } 

        //FIXME:
        public void SetSven4Interval()
        {
            CurrPoint = FunctionHolder.Start;
            Dir = -Grad(CurrPoint); //Антиградиент
            Dir = Dir.Normalize(1);
            if (DiffFunction(CurrPoint,Dir) > 0) Dir = -Dir;
            var alpha = 0.01f;
            while (DiffFunction(CurrPoint,Dir) <= 0)
            {
                alpha *= 2;
                CurrPoint = CurrPoint + Dir*alpha;
            }
            Dir = -Grad(CurrPoint);
        }

        //Критерий окончания поиска
        protected bool KOP1(Vector<double> d)
        {
            return IterationCount <= MaxIterations && !(d.Norm(1) < Eps);
        }

        protected MultiDimMethod(string name, double eps, Delegate f, int maxIterations)
        {
            MaxIterations = maxIterations;
            Name = name;
            Eps = eps;
            //TODO: попробуй засунуть отсюда делегат в холдер и протестируй всю математику
            FunctionHolder = f;
        }
    }
}
