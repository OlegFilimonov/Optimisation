using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    public class FibonacciMethod1 : OneDimentionalOptimisationMethod
    {
        private List<double> fibonacciList = null;
        private int n = 1;
        double length_n = 1e-6;

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
            if(fibonacciList == null) fibonacciList = new List<double>();
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
            var lambda = a + fibonacciList[n - 2] / fibonacciList[n] * length;
            var mu = a + fibonacciList[n - 1] / fibonacciList[n] * length;
            var k = 1;

            iterationCount = n - 1;

            //Основной этап
            while (k != n - 1)
            {
                if (f(lambda) < f(mu))
                {
                    b = mu;
                    length = Math.Abs(b - a);
                    mu = lambda;
                    lambda = a + fibonacciList[n - k - 2] / fibonacciList[n - k] * length;
                }
                else
                {
                    a = lambda;
                    lambda = mu;
                    length = Math.Abs(b - a);
                    mu = a + fibonacciList[n - k - 1] / fibonacciList[n - k] * length;
                }
                k++;
            }
            mu = lambda + eps;
            if (f(lambda) > f(mu))
            {
                answer = (lambda + b) / 2;
                a = lambda; 
            }
            else
            {
                answer = (a + mu) / 2;
                b = mu;
            }
        }

        //Конструктор
        public FibonacciMethod1(function f, double eps = 1e-6, int maxIteratons=50)
            : base(f: f, df: null, eps: eps, methodName: "Метод ФИБОНАЧЧИ-1",maxIterations: maxIteratons)
        {
            length_n = eps;
        }
    }
}
