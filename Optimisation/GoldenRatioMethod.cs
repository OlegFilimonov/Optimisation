using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    //Метод Золотого Сечения 1 - МЗС 1
    class GoldenRatioMethod : OneDimentionalOptimisationMethod
    {
        private readonly double eps;
        private readonly double goldenLeft = (3 - Math.Sqrt(5)) / 2;
        private readonly double goldenRight = (-1 + Math.Sqrt(5)) / 2;
        private double answer;

        private void execute()
        {
            //Начальный этап
            var length = Math.Abs(b - a);
            var lambda = a + goldenLeft * length;
            var mu = a + goldenRight * length;
            var k = 0;

            //Основной этап
            do
            {
                if (f(lambda) < f(mu))
                {
                    b = mu;
                    length = Math.Abs(b - a);
                    mu = lambda;
                    lambda = a + goldenLeft * length;
                }
                else
                {
                    a = lambda;
                    lambda = mu;
                    length = Math.Abs(b - a);
                    mu = a + goldenRight * length;
                }
                Console.WriteLine("- МЗС: Итерация № " + k + ", \tТИЛ: [" + a + ";"+ b + "]");
                k++;
            } while (length > eps && k < MAX_ITERATIONS);
            Console.WriteLine("- МЗС: Закончена работа за " + k + " итераций");

            //Окончание
            answer = (a + b)/2;
        }

        public GoldenRatioMethod(function f, double eps = 1e-6, bool useStandartInterval = false)
            : base(f, useStandartInterval)
        {
            this.eps = eps;
            execute();
            Console.WriteLine( "МЗС: Закончена работа, найденый минимум: " + answer );
        }
    }
}
