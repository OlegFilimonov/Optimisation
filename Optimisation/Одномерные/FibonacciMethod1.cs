using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Optimisation.Базовые_и_вспомогательные;

// ReSharper disable InconsistentNaming

namespace Optimisation.Одномерные
{
    public class FibonacciMethod1 : OneDimMethod
    {
        private List<double> _fibonacciList;
        private int _n = 1;

        //Конструктор
        public FibonacciMethod1(Function1D f, double eps = 1e-6, int maxIteratons = 50)
            : base(f, null, eps, "Метод ФИБОНАЧЧИ-1", maxIteratons)
        {
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private double PopulateFibonacci(double treshHold)
        {
            double f_n = 1;
            double f_n2 = 1, f_n1 = 1;
            _fibonacciList.Add(1);

            //Нахолим f_n и n
            while (f_n < treshHold)
            {
                _fibonacciList.Add(f_n);
                f_n = f_n1 + f_n2;
                f_n1 = f_n2;
                f_n2 = f_n;
                _n++;
            }
            _n--;
            return f_n;
        }

        public override void Execute()
        {
            //Сбрасываем счетчик
            IterationCount = 0;

            _n = 1;
            if (_fibonacciList == null) _fibonacciList = new List<double>();
            else
            {
                _fibonacciList.Clear();
            }

            //Начальный этап
            var length = Math.Abs(B - A);

            var treshHold = length/(Eps/10);

            var f_n = PopulateFibonacci(treshHold);

            //Находим эпсилон для последнего шага
            var eps2 = length/f_n;

            //Находим две стартовые точки
            var lambda = A + _fibonacciList[_n - 2]/_fibonacciList[_n]*length;
            var mu = A + _fibonacciList[_n - 1]/_fibonacciList[_n]*length;
            var k = 1;

            IterationCount = _n - 1;

            //Основной этап
            while (k != _n - 1)
            {
                if (F(lambda) < F(mu))
                {
                    B = mu;
                    length = Math.Abs(B - A);
                    mu = lambda;
                    lambda = A + _fibonacciList[_n - k - 2]/_fibonacciList[_n - k]*length;
                }
                else
                {
                    A = lambda;
                    lambda = mu;
                    length = Math.Abs(B - A);
                    mu = A + _fibonacciList[_n - k - 1]/_fibonacciList[_n - k]*length;
                }
                k++;
                if (k > MaxIterations) break;
            }
            mu = lambda + eps2;
            if (F(lambda) > F(mu))
            {
                Answer = (lambda + B)/2;
                A = lambda;
            }
            else
            {
                Answer = (A + mu)/2;
                B = mu;
            }
        }
    }
}