﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation
{
    //   Класс типичных функций для тестирования
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
        private List<OneDimentionalOptimisationMethod> oneDimentionalMethods = new List<OneDimentionalOptimisationMethod>(); 
        private TestingFunctions testingFunctions;

        private void populateList()
        {
            OneDimentionalOptimisationMethod.function f = testingFunctions.f2;
            oneDimentionalMethods.Add(new GoldenRatioMethod1(f));
            oneDimentionalMethods.Add(new GoldenRatioMethod2(f));
            oneDimentionalMethods.Add(new FibonacciMethod1(f));
        }

        private void generateAllReports()
        {
            foreach (var method in oneDimentionalMethods)
            {
                method.generateReport();
            }
        }

        public Tester()
        {
            testingFunctions = new TestingFunctions();
            Console.WriteLine("======================================================");
            Console.WriteLine("\t\tЛОГИ МЕТОДОВ");
            Console.WriteLine("======================================================");
            populateList();
            Console.WriteLine("======================================================");
            Console.WriteLine("\t\tОТВЕТЫ МЕТОДОВ");
            Console.WriteLine("======================================================");
            generateAllReports();
        }
    }
}
