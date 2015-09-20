using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using DoubleConverter = Optimisation.Одномерные.DoubleConverter;

namespace Optimisation.Одномерные
{
    //Делегат функции
    public delegate double function(double x);


    //Класс одномерных методов оптимизации
    public abstract class OneDimentionalOptimisationMethod
    {
        //Макс. количество итераций
        protected int maxIterations = 50;

        //Точность вычислений метода
        protected readonly double eps;

        //Имя метода для логов
        protected readonly string methodName;

        //Количество итераций для логов
        protected int iterationCount;

        //Ответ
        protected double answer;

        //Начальный интервал
        protected double a;
        protected double b;
        protected double c;

        //Функция
        protected function f;
        protected function df;

        //Реализация метода
        public abstract void execute();

        //Стандартный интервал
        public void setStandartInterval()
        {
            a = 0;
            b = 1;
        }

        //Метод Свена
        private void setSvenInterval(double startingX = 0, double h = 0.01)
        {
            a = startingX;
            double x1 = a, x2 = a, x3 = a + h;
            var k = 0;

            //Начальный этап
            if (f(x2) < f(x3))
            {
                x3 = a + (h = -h);
            }

            //Основной этап
            while (f(x2) > f(x3))
            {
                k++;
                h *= 2;
                x2 = x3;
                x3 += h;
                x1 = x2;
            }

            //Окончание
            if (x1 < x3)
            {
                a = x1;
                b = x3;
            }
            else
            {
                a = x3;
                b = x1;
            }
        }

        //Свен - 3
        public void setSven3Interval(double startingX = 0, double h = 0.01)
        {
            //TODO: do this properly
            setSvenInterval(startingX, h);
            c = b;
            b = (a + c) / 2;
        }


        //Конструктор
        protected OneDimentionalOptimisationMethod(function f, function df, double eps, string methodName, int maxIterations = 50)
        {
            this.methodName = methodName;
            this.f = f;
            this.df = df;
            this.eps = eps;
            this.maxIterations = maxIterations;

        }

        public string MethodName
        {
            get { return methodName; }
        }

        public double A
        {
            get { return a; }
        }

        public double B
        {
            get { return b; }
        }

        public double C
        {
            get { return c; }
        }

        public double Eps
        {
            get { return eps; }
        }


    }
}
