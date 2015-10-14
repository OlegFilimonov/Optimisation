using System;
using System.Drawing;

// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Optimisation.Базовые_и_вспомогательные
{
    //Делегат функции
    public delegate double Function1D(double x);

    public delegate double Function2D(double x1, double x2);
 
    /// <summary>
    ///     Базовый класс
    /// </summary>
    public abstract class OneDimMethod
    {
        
        protected readonly int MaxIterations;

        //Конструктор
        protected OneDimMethod(Function1D f, Function1D df, double eps, string name, int maxIterations = 50)
        {
            Name = name;
            F = f;
            Df = df;
            Eps = eps;
            MaxIterations = maxIterations;
        }

        public string Name { get; }

        public double Answer { get; protected set; }

        public double A { get; set; }

        public double B { get; set; }

        public double C { get; private set; }

        public double Eps { get; set; }

        public int IterationCount { get; protected set; }

        public Function1D F { protected get; set; }

        public Function1D Df { protected get; set; }

        //Реализация метода
        public abstract void Execute();

        //Стандартный интервал
        public void SetStandartInterval()
        {
            A = 0;
            B = 1;
        }

        //Метод Свена
        public void SetSvenInterval(double startingX = 0, double h = 0.01)
        {
            A = startingX;
            double x1 = A, x2 = A, x3 = A + h;

            //Начальный этап
            if (F(x2) < F(x3))
            {
                x3 = A + (h = -h);
            }

            //Основной этап
            while (F(x2) >= F(x3))
            {
                h *= 2;
                x1 = x2;
                x2 = x3;
                x3 += h;
            }

            //Окончание
            if (x1 < x3)
            {
                A = x1;
                B = x3;
            }
            else
            {
                A = x3;
                B = x1;
            }
        }

        public void SetSven2Interval(double startingX = 0, double h = 0.01)
        {
            if (startingX != 0) h *= Math.Abs(startingX);
            if (Df(startingX) > 0) h = -h;
            var sign = Df(startingX);
            while (sign*Df(startingX + h) > 0)
            {
                startingX += h;
                h *= 2;
            }
            if (h < 0)
            {
                A = startingX + h;
                B = startingX;
            }
            else
            {
                A = startingX;
                B = startingX + h;
            }
        }

        //Свен - 3
        public void SetSven3Interval(double startingX = 0, double h = 0.01)
        {
            if (startingX != 0) h *= Math.Abs(startingX);
            if (F(startingX) < F(startingX + h)) h = -h;

            var x = startingX;

            while (F(x) > F(x + h))
            {
                x += h;
                h *= 2;
            }

            if (F(x) > F(x + h/2) && (h < 0)) //Первый случай
            {
                A = x + h;
                B = x + h/2;
                C = x;
            }
            else if (F(x) > F(x + h/2) && (h >= 0)) //Второй случай
            {
                A = x;
                B = x + h/2;
                C = x + h;
            }
            else if (F(x) <= F(x + h/2) && (h < 0)) //Третий случай
            {
                A = x + h/2;
                B = x;
                C = x - h/2;
            }
            else //Четвертный случай
            {
                A = x - h/2;
                B = x;
                C = x + h/2;
            }
        }
    }
}