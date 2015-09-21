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
        protected double eps;

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
        public void setSvenInterval(double startingX = 0, double h = 0.01)
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
            while (f(x2) >= f(x3))
            {
                k++;
                h *= 2;
                x1 = x2;
                x2 = x3;
                x3 += h;
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

        public void setSven2Interval(double startingX = 0, double h = 0.01)
        {
            if (startingX != 0) h *= Math.Abs(startingX);
            if (df(startingX) > 0) h = -h;
            double sign = df(startingX);
            while (sign * df(startingX + h) > 0)
            {
                startingX += h;
                h *= 2;
            }
            if (h < 0)
            {
                a = startingX + h;
                b = startingX;
            }
            else
            {
                a = startingX;
                b = startingX + h;
            }
        }

        //Свен - 3
        public void setSven3Interval(double startingX = 0, double h = 0.01)
        {
            if (startingX != 0) h *= Math.Abs(startingX);
            if (f(startingX) < f(startingX + h)) h = -h;

            var x = startingX;

            while (f(x) > f(x + h))
            {
                x += h; h *= 2;
            }

            if (f(x) > f(x + h / 2) && (h < 0)) //Первый случай
            {

                a = x + h;
                b = x + h / 2;
                c = x;
            }
            else if (f(x) > f(x + h / 2) && (h >= 0)) //Второй случай
            {
                a = x;
                b = x + h / 2;
                c = x + h;
            }
            else if (f(x) <= f(x + h / 2) && (h < 0)) //Третий случай
            {
                a = x + h / 2;
                b = x;
                c = x - h / 2;
            }
            else //Четвертный случай
            {
                a = x - h / 2;
                b = x;
                c = x + h / 2;
            }
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
            set { eps = value; }
        }

        public double Answer
        {
            get { return answer; }
        }

        public int IterationCount
        {
            get { return iterationCount; }
        }

        public function F
        {
            get { return f; }
            set { f = value; }
        }

        public function Df
        {
            get { return df; }
            set { df = value; }
        }
    }
}
