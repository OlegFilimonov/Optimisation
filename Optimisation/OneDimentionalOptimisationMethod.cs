using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting.Messaging;

namespace Optimisation
{
    //Класс одномерных методов оптимизации
    public abstract class OneDimentionalOptimisationMethod
    {
        //Макс. количество итераций
        protected const int MAX_ITERATIONS = 50;

        //Начальный интервал
        protected double a;
        protected double b;

        //Делегат функции
        public delegate double function(double x);

        //Функция
        protected function f;

        //Метод Свена
        private void svenInterval(double startingX = 0, double h = 0.01)
        {
            a = startingX;
            double x1 = a, x2 = a, x3 = a + h;
            var k = 0;
            Console.WriteLine("- Выбран метод Свена (МС)");

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
            Console.WriteLine("- Выбран стандартный начальный интервал: [0,1]");
        }

        //Конструктор
        protected OneDimentionalOptimisationMethod(function f, bool useStandartInterval = false)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            this.f = f;
            if (useStandartInterval) standartInterval();
            else svenInterval();
        }
    }
}
