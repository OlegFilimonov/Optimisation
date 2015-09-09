using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    //   Класс типичных функций для тестирования
    //   TODO: создать класс теста и переместить данный класс туда вместе с методами
    class TestingFunctions
    {
        // Функция y = x^2
        public double f1(double x)
        {
            return Math.Pow(x, 2);
        }

        // Функция y = x*x + 3*x - 7
        public double f2(double x)
        {
            return Math.Pow(x, 2) + 3 * x - 7;

        }
    }

    class Tester
    {
        private GoldenRatioMethod goldenRatioMethod;
        private TestingFunctions testingFunctions;

        public Tester()
        {
            testingFunctions = new TestingFunctions();
            Console.WriteLine("======================================================");
            Console.WriteLine("\tЛОГИ МЕТОДОВ");
            Console.WriteLine("======================================================");
            goldenRatioMethod = new GoldenRatioMethod(testingFunctions.f2);
        }
    }
}
