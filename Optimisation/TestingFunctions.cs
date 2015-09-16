﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    //Класс типичных функций для тестирования
    class TestingFunctions
    {
        // Функция y = x^2
        public static double f1(double x)
        {
            return 4 * Math.Pow(x, 2);
        }

        public static double df1(double x)
        {
            return 8 * x;
        }
        // Функция y = x*x + 3*x - 7
        public static double f2(double x)
        {
            return Math.Pow(x, 2) + 3 * x - 7;

        }

        public static double df2(double x)
        {
            return 2 * x + 3;
        }

        // Функция y = x*x + 3*x - 7
        public static double f3(double x)
        {
            return 2 * Math.Pow(x, 2) + 8 * x - 7;
        }

        public static double df3(double x)
        {
            return 4 * x + 8;
        }

        public static double f4(double x)
        {
            return 10 * Math.Pow(x, 2) - 4 * x + 7;
        }

        public static double df4(double x)
        {
            return 20 * x - 4;
        }
    }

    //Класс, хранящий функции для тестирования
    class Function
    {
        private function f;
        private function df;
        private string name;

        public Function(function f, function df, string name)
        {
            this.f = f;
            this.df = df;
            this.name = name;
        }

        public function F
        {
            get { return f; }
        }

        public function Df
        {
            get { return df; }
        }

        public string Name
        {
            get { return name; }
        }
    }

}
