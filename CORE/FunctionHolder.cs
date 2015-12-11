using System;
using MathNet.Numerics.LinearAlgebra;

namespace CORE
{
    public class FunctionHolder
    {
        /// <summary>
        ///     Конструктор
        /// </summary>
        /// <param name="f"></param>
        /// <param name="point"></param>
        public FunctionHolder(Delegate f, Vector<double> point)
        {
            F = f;
            Point = point;
        }

        //Функция
        private Delegate F { get; }

        //Рекомендуемая начальная точка
        public Vector<double> Point { get; set; }

        //Направление для альфа функции
        public Vector<double> Dir { get; set; }

        /// <summary>
        ///     Функиця принимающая вектор и возвращающая число
        /// </summary>
        /// <param name="x">вектор</param>
        /// <returns></returns>
        public double Y(Vector<double> x)
        {
            return ((Func<Vector<double>, double>) F)(x);
        }

        /// <summary>
        ///     Альфа-функция
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public double AlphaFunction(double alpha)
        {
            return Y(Point + Dir.Multiply(alpha));
        }

        /// <summary>
        ///     Альфа-функция дифференцирования
        /// </summary>
        /// <param name="alpha"></param>
        /// <returns></returns>
        public double AlphaDiffFunction(double alpha)
        {
            return DiffFunction(Point + Dir.Multiply(alpha));
        }

        /// <summary>
        ///     Альфа-функция
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double AlphaFunction(double alpha, Vector<double> dir)
        {
            return Y(Point + dir.Multiply(alpha));
        }

        /// <summary>
        ///     Альфа-функция дифференцирования
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double AlphaDiffFunction(double alpha, Vector<double> dir)
        {
            return DiffFunction(Point + dir.Multiply(alpha), dir);
        }

        /// <summary>
        ///     Создает вектор со всеми нулями, но со значением value на позиции pos
        /// </summary>
        /// <param name="varCount"></param>
        /// <param name="pos"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public Vector<double> MakeOneVector(int varCount, int pos, double value)
        {
            var res = Vector<double>.Build.Dense(varCount);
            res[pos] = value;
            return res;
        }

        /// <summary>
        ///     Функция численного дифференцирования
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        private double DiffFunction(Vector<double> point)
        {
            return Grad(point)*Dir;
        }

        /// <summary>
        ///     Функция численного дифференцирования
        /// </summary>
        /// <param name="point"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public double DiffFunction(Vector<double> point, Vector<double> dir)
        {
            return Grad(point)*dir;
        }

        /// <summary>
        ///     Численное дифференцирование градиента
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
                g[i] = (Y(point + hVector) - Y(point - hVector))/(2*h);
            }
            return g;
        }

        /// <summary>
        ///     Численное дифференцирование градиента
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
                g[i] = (Y(point - hVector) + 4*Y(point) + 3*Y(point + hVector))/(2*h);
            }
            return g;
        }

        /// <summary>
        ///     Численное дифференцирование градиента
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
                g[i] = (-Y(point + 2*hVector) + 8*Y(point + hVector) - 8*Y(point - hVector) + Y(point - 2*hVector))/
                       (12*h);
            }
            return g;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public Vector<double> SimpleGrad(Vector<double> point)
        {
            return (point - (point - 0.01))/0.01;
        }

        /// <summary>
        ///     Градиент с численным дифференцированием
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
                g[i] = (Y(Point[i] + hVector) - Y(Point[i] - hVector))/(2*h);
            }
            return g;
        }

        /// <summary>
        ///     Нормализует направлеине
        /// </summary>
        public void Normilize()
        {
            Dir = Dir.Normalize(1);
        }
    }
}