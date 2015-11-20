using System;
using MathNet.Numerics.LinearAlgebra;

namespace Optimisation.Базовые_и_вспомогательные
{
    public class FunctionHolderMultiDim
    {
        //Функция
        public Delegate F { get; set; }

        //Рекомендуемая начальная точка
        public Vector<double> Point { get; set; }

        //Направление для альфа функции
        public Vector<double> Dir { get; set; } 

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="f"></param>
        /// <param name="varCount"></param>
        /// <param name="point"></param>
        public FunctionHolderMultiDim( Delegate f, Vector<double> point)
        {
            F = f;
            Point = point;
        }

        /// <summary>
        /// Функиця принимающая вектор и возвращающая число
        /// </summary>
        /// <param name="x">вектор</param>
        /// <returns></returns>
        public double Y(Vector<double> x)
        {
            switch (x.Count)
            {
                case 1:
                    return ((Func<double, double>)F)(x[0]);
                case 2:
                    return ((Func<double, double, double>)F)(x[0], x[1]);
                case 3:
                    return ((Func<double, double, double, double>)F)(x[0], x[1], x[2]);
                case 4:
                    return ((Func<double, double, double, double, double>)F)(x[0], x[1], x[2], x[3]);
                default:
                    throw new Exception("переменных может быть от 1 до 4");
            }
            
        }

        /// <summary>
        /// Альфа-функция
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public double AlphaFunction(double alpha)
        {
            return Y(Point + Dir.Multiply(alpha));
        }

        /// <summary>
        /// Альфа-функция дифференцирования
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public double AlphaDiffFunction(double alpha)
        {
            return DiffFunction(Point + Dir.Multiply(alpha));
        }

        /// <summary>
        /// Альфа-функция
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double AlphaFunction(double alpha,Vector<double> dir )
        {
            return Y(Point + dir.Multiply(alpha));
        }

        /// <summary>
        /// Альфа-функция дифференцирования
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double AlphaDiffFunction(double alpha,Vector<double> dir )
        {
            return DiffFunction(Point + dir.Multiply(alpha),dir);
        }

        /// <summary>
        /// Создает вектор со всеми нулями, но со значением value на позиции pos
        /// </summary>
        /// <param name="varCount"></param>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Vector<double> MakeOneVector(int varCount, int pos, double value)
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
        private double DiffFunction(Vector<double> point)
        {
            return Grad(point) * Dir;
        }

        /// <summary>
        /// Функция численного дифференцирования
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double DiffFunction(Vector<double> point,Vector<double> dir )
        {
            return Grad(point) * dir;
        }

        /// <summary>
        /// Численное дифференцирование градиента
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector<double> Grad(Vector<double> point)
        {
            const double h = 1e-5;
            var varCount = point.Count;
            var g = Vector<double>.Build.Dense(varCount); // Создали вектор частных производных
            for (var i = 0; i < varCount; i++)
            {
                var hVector = MakeOneVector(varCount, i, h);
                g[i] = (Y(point + hVector) - Y(point - hVector)) / (2 * h);
            }
            return g;
        }

        /// <summary>
        /// Численное дифференцирование градиента
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector<double> Grad4(Vector<double> point)
        {
            const double h = 1e-5;
            var varCount = point.Count;
            var g = Vector<double>.Build.Dense(varCount); // Создали вектор частных производных
            for (var i = 0; i < varCount; i++)
            {
                var hVector = MakeOneVector(varCount, i, h);
                g[i] = (Y(point - hVector) + 4*Y(point) + 3*Y(point+hVector) ) / (2 * h);
            }
            return g;
        }

        /// <summary>
        /// Численное дифференцирование градиента
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector<double> Grad5(Vector<double> point)
        {
            const double h = 1e-5;
            var varCount = point.Count;
            var g = Vector<double>.Build.Dense(varCount); // Создали вектор частных производных
            for (var i = 0; i < varCount; i++)
            {
                var hVector = MakeOneVector(varCount, i, h);
                g[i] = (-Y(point + 2*hVector) + 8*Y(point + hVector) - 8*Y(point-hVector)+Y(point-2*hVector)) / (12 * h);
            }
            return g;
        }

        /// <summary>
        /// Градиент с численным дифференцированием
        /// </summary>
        /// <returns></returns>
        public Vector<double> Grad()
        {
            const double h = 1e-5;
            var varCount = Point.Count;
            var g = Vector<double>.Build.Dense(varCount); // Создали вектор частных производных
            for (var i = 0; i < varCount; i++)
            {
                var hVector = MakeOneVector(varCount, i, h);
                g[i] = (Y(Point[i] + hVector) - Y(Point[i] - hVector)) / (2 * h);
            }
            return g;
        }

        /// <summary>
        /// Нормализует направлеине
        /// </summary>
        public void Normilize()
        {
            Dir = Dir.Normalize(1);
        }
    }
}
