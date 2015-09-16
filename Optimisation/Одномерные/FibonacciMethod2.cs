using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{

    class FibonacciMethod2 : OneDimentionalOptimisationMethod
    {
        private List<double> fibonacciList;
        private int n = 1;
        double length_n = 1e-6;

        private double populateFibonacci(double treshHold)
        {
            double f_n = 1;
            double f_n2 = 1, f_n1 = 1;
            fibonacciList.Add(1);

            //Нахолим f_n и n
            while (f_n < treshHold)
            {
                fibonacciList.Add(f_n);
                f_n = f_n1 + f_n2;
                f_n1 = f_n2;
                f_n2 = f_n;
                n++;
            }
            n--;
            return f_n;
        }



        protected override void execute()
        {
            n = 1;

            if (fibonacciList == null) fibonacciList = new List<double>();
            else
            {
                fibonacciList.Clear();
            }

            //Начальный этап
            var length = Math.Abs(b - a);

            var treshHold = length / length_n;
            double f_n;

            f_n = populateFibonacci(treshHold);

            //Находим эпсилон для последнего шага
            var eps = length / f_n;

            //Находим две стартовые точки
            var x1 = a + fibonacciList[n - 1]/fibonacciList[n]*length + Math.Pow(-1, n)/fibonacciList[n]*eps;
            var k = 1;
            double x2;
            iterationCount = n;

            //Основной этап
            do
            {
                x2 = a + b - x1;

                if ((f(x2) < f(x1)) && (x2 < x1))
                {
                    b = x1;
                    x1 = x2;
                }
                else if ((f(x2) >= f(x1)) && (x2 < x1))
                {
                    a = x2;
                }
                else if ((f(x2) < f(x1)) && (x2 >= x1))
                {
                    a = x1;
                    x1 = x2;
                }
                else if ((f(x2) >= f(x1)) && (x2 >= x1))
                {
                    b = x2;
                }
                k++;
                length = Math.Abs(b - a);
                Console.WriteLine(methodName + ": Итерация № " + k + " \tТИЛ: [" + a + ";" + b + "]");
            } while (k!=n);
            

            if (f(x1) > f(x2))
            {
                answer = (x1 + b) / 2;
            }
            else
            {
                answer = (a + x2) / 2;
            }
        }

        //Конструктор
        public FibonacciMethod2(function f, double eps = 1e-6, bool useStandartInterval = false)
            : base(f,null, eps, "МФ2", useStandartInterval)
        {
            length_n = eps;
        }
    }
}
