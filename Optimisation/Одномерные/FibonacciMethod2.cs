using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{

    public class FibonacciMethod2 : OneDimMethod
    {
        private List<double> fibonacciList;
        private int n = 1;

        public double populateFibonacci(double treshHold)
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



        public override void execute()
        {
            //Сбрасываем счетчик
            iterationCount = 0;

            n = 1;

            if (fibonacciList == null) fibonacciList = new List<double>();
            else
            {
                fibonacciList.Clear();
            }

            //Начальный этап
            var length = Math.Abs(b - a);

            var treshHold = length / (eps/10);
            double f_n;

            f_n = populateFibonacci(treshHold);

            //Находим эпсилон для последнего шага
            var eps2 = length / f_n;

            //Находим две стартовые точки
            var x1 = a + fibonacciList[n - 1]/fibonacciList[n]*length + Math.Pow(-1, n)/fibonacciList[n]*eps2;
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
        public FibonacciMethod2(function f, double eps = 1e-6, int maxIterations=50)
            : base(f: f, df: null, eps: eps, methodName: "Метод ФИБОНАЧЧИ-2", maxIterations: maxIterations)
        {
        }
    }
}
