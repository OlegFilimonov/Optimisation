using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    /// Класс типичных двумерных функций для тестирования
    /// </summary>
    public class TwoDimTestingFunctions
    {
        public static double f1(double x1, double x2) => Math.Pow(x1, 2) + 3 * Math.Pow(x2, 2) + 2 * x1 * x2;
        public static double df1x1(double x1, double x2) => 2 * x1 + 2 * x2;
        public static double df1x2(double x1, double x2) => 6 * x2 + 2 * x1;


        public static double f2(double x1, double x2) => 100*Math.Pow(x2 - Math.Pow(x1, 2), 2) + Math.Pow(1 - x1, 2);
        public static double df2x1(double x1, double x2) => 100*(-4*x2*x1 + 4*Math.Pow(x1, 3)) - 2 + 2*x1;
        public static double df2x2(double x1, double x2) => 100*(2*x2-2*Math.Pow(x1,2));
    }
}
