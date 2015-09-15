using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using DoubleConverter = Optimisation.Одномерные.DoubleConverter;

namespace Optimisation
{
    //Делегат функции
    public delegate double function(double x);


    //Класс одномерных методов оптимизации
    public abstract class OneDimentionalOptimisationMethod
    {
        //Макс. количество итераций
        protected const int MAX_ITERATIONS = 50;

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

  
        //Функция
        protected function f;
        protected function df;

        //Реализация метода
        protected abstract void execute();

        //Метод Свена
        private void svenInterval(double startingX = 0, double h = 0.01)
        {
            a = startingX;
            double x1 = a, x2 = a, x3 = a + h;
            var k = 0;
            Console.WriteLine("НАЧАЛО МЕТОДА СВЕНА");

            //Начальный этап
            if (f(x2) < f(x3))
            {
                x3 = a + (h = -h);
            }

            //Основной этап
            while ((f(x2) > f(x3)) && (k <= MAX_ITERATIONS))
            {
                Console.WriteLine("- МС: Итерация № " + k + " \tТИЛ: [" + x1 + ";" + x3 + "]");
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
            Console.WriteLine("- МС: Начальный интервал: [" + a + ";" + b + "]");
        }

        //Стандартный интервал
        private void standartInterval()
        {
            a = 0;
            b = 1;
            Console.WriteLine("ВЫБРАН СТАНДАРТНЫЙ НАЧАЛЬНЫЙ ИНТЕРВАЛ [0,1]");
        }

        //Вывод ответа
        public void generateReport()
        {
            double floatNumberCount = Math.Abs(Math.Log10(eps)) + 5 + 6;
            Console.WriteLine("{0}:\tИтерации: {1}\t Ответ:"+ DoubleConverter.ToExactString(answer) +"\tТочность: {3}", methodName,iterationCount, answer,eps)
                ;
        }

        //Конструктор
        protected OneDimentionalOptimisationMethod(function f, function df, double eps, string methodName, bool useStandartInterval = false)
        {
            //Функция должна существовать
            if (f == null) throw new ArgumentNullException(nameof(f));
            

            this.methodName = methodName;
            this.f = f;
            this.df = df;
            this.eps = eps;

            //Выбор начального интервала
            if (useStandartInterval) standartInterval();
            else
            {
                if (df != null)
                {
                    //TODO: реализовать метод свена-2 и выбрать его
                    svenInterval();
                }
                else
                {
                    svenInterval();
                }
            }

            Console.WriteLine("НАЧАЛО " + methodName);
            //Запуск метода
            execute();

            Console.WriteLine("КОНЕЦ " + methodName);
            //Вывод ответа
            generateReport();
        }
    }
}
