using System;
using System.Collections.Generic;
using Optimisation.Базовые_и_вспомогательные;
// ReSharper disable InconsistentNaming

namespace Optimisation.Одномерные
{
    public class FibonacciMethod2 : OneDimMethod
    {
        private List<double> _fibonacciList;
        private int _n = 1;

        //Конструктор
        public FibonacciMethod2(Function1D f, double eps = 1e-6, int maxIterations = 50)
            : base(f, null, eps, "Метод ФИБОНАЧЧИ-2", maxIterations)
        {
        }

        private double PopulateFibonacci(double treshHold)
        {
            double f_n = 1;
            double f_n2 = 1, f_n1 = 1;
            _fibonacciList.Add(1);

            //Нахолим f_n и n
            do
            {
                _fibonacciList.Add(f_n);
                f_n = f_n1 + f_n2;
                f_n1 = f_n2;
                f_n2 = f_n;
                _n++;
            } while (f_n < treshHold);
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
            var x1 = A + _fibonacciList[_n - 1]/_fibonacciList[_n]*length + Math.Pow(-1, _n)/_fibonacciList[_n]*eps2;
            var k = 1;
            double x2;
            IterationCount = _n;

            //Основной этап
            do
            {
                x2 = A + B - x1;

                if ((F(x2) < F(x1)) && (x2 < x1))
                {
                    B = x1;
                    x1 = x2;
                }
                else if ((F(x2) >= F(x1)) && (x2 < x1))
                {
                    A = x2;
                }
                else if ((F(x2) < F(x1)) && (x2 >= x1))
                {
                    A = x1;
                    x1 = x2;
                }
                else if ((F(x2) >= F(x1)) && (x2 >= x1))
                {
                    B = x2;
                }
                k++;
                if (k > MaxIterations) break;
            } while (k != _n);


            if (F(x1) > F(x2))
            {
                Answer = (x1 + B)/2;
                A = x1;
            }
            else
            {
                Answer = (A + x2)/2;
                B = x2;
            }
        }
    }
}