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
        double f1(double x)
        {
            return Math.Pow(x, 2);
        }

        // Функция y = x^3 + 5x^2 - 5x + 65
        double f2(double x)
        {
            return Math.Pow(x, 3) + 5 * Math.Pow(x, 2) - 5 * x + 65;
           
        }
    }

    //Основной класс программы
    class Program
    {
        static void Main(string[] args) => Console.Write("Hello, universe!");
    }
}
