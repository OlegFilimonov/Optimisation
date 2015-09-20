using System;
using System.Collections.Generic;
using Optimisation.Одномерные;

namespace Optimisation.Testing
{

    //Тестер
    public class Tester
    {
        private List<OneDimentionalOptimisationMethod> oneDimentionalMethods = new List<OneDimentionalOptimisationMethod>();
        private List<Function> testingFunctions = new List<Function>();

        private void populateFunctions()
        {
            testingFunctions.Add(new Function(TestingFunctions.f1,TestingFunctions.f2,"2x^2+16/x"));
        }

        private void populateMethods(function f, function df)
        {
            oneDimentionalMethods.Add(new GoldenRatioMethod1(f));
            oneDimentionalMethods.Add(new GoldenRatioMethod2(f));
            oneDimentionalMethods.Add(new FibonacciMethod1(f));
            oneDimentionalMethods.Add(new FibonacciMethod2(f));
            oneDimentionalMethods.Add(new BolzanoMethod(f, df));
            oneDimentionalMethods.Add(new ExtrapolationMethod(f));
            oneDimentionalMethods.Add(new PaulMethod(f, df));
            oneDimentionalMethods.Add(new DSK_Method(f));
            oneDimentionalMethods.Add(new DavidonMethod(f,df));
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
            Console.Clear();
            populateFunctions();
            Console.WriteLine("Выберите функцию, полный список:\n");
            int k = 0;
            foreach (var func in testingFunctions)
            {
                k++;
                Console.WriteLine("[{0}] Функция {1}", k,func.Name);
            }
            var chosenValue = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());

            Console.Clear();
            var currFunc = testingFunctions[chosenValue - 1];


            populateMethods(currFunc.F, currFunc.Df);

            Console.WriteLine("\nВсе методы инициированы. Нажмите любую клавишу, чтобы войти в главное меню.");
        //    Console.ReadKey(true);
            executeLauncher();
        }

        public void executeLauncher()
        {
            Console.Clear();
            Console.WriteLine("Выберите метод, полный список:\n");
            int k = 0;
            Console.WriteLine("[0] Запустить все методы");
            foreach (var method in oneDimentionalMethods)
            {
                k++;
                Console.WriteLine("[{0}] Метод \"{1}\"", k, method.MethodName);
            }
            var chosenValue = Convert.ToInt32(Console.ReadKey(true).KeyChar.ToString());
            Console.Clear();
            if (chosenValue == 0)
            {
                try
                {
                    Console.WriteLine(("").PadRight(79, '='));
                    Console.WriteLine("\t\t\tОТВЕТЫ МЕТОДОВ");
                    Console.WriteLine(("").PadRight(79, '='));
                    generateAllReports();
                }
                catch (Exception ignored)
                {
                    Console.WriteLine("Exception: " + ignored.ToString());
                }

            }
            else
            {
                var currMethod = oneDimentionalMethods[chosenValue - 1];

                //try
                //{
                    currMethod.executeMethod();
                    Console.WriteLine(("").PadRight(79, '='));
                    Console.WriteLine("\t\t\tОТВЕТ МЕТОДА");
                    Console.WriteLine(("").PadRight(79, '='));
                    currMethod.generateReport();
                    Console.WriteLine("\n\n");
                //}
                //catch (Exception ignored)
                //{
                //    Console.WriteLine("Exception: " + ignored.ToString());
                //}
            }
            Console.WriteLine("\nКонец работы, нажмите \"r\" чтобы начать заного или \"m\" чтобы выбрать новую функцию");
            chosenValue = Convert.ToChar(Console.ReadKey(true).KeyChar.ToString());
            if (chosenValue == 'r' || chosenValue == 'к') executeLauncher(); else
            if (chosenValue == 'ь' || chosenValue == 'm') new Tester();

        }
    }
}
