using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    /// Класс типичных двумерных функций для тестирования
    /// </summary>
    public class TwoDimTestingFunctions
    {
        public static double f1(double x1, double x2) => Pow(x1, 2) + 3 * Pow(x2, 2) + 2 * x1 * x2;
        public static double df1x1(double x1, double x2) => 2 * x1 + 2 * x2;
        public static double df1x2(double x1, double x2) => 6 * x2 + 2 * x1;


        public static double f2(double x1, double x2) => 100 * Pow(x2 - Pow(x1, 2), 2) + Pow(1 - x1, 2);
        public static double df2x1(double x1, double x2) => 2 * (200 * Pow(x1, 3) - 200 * x1 * x2 + x1 - 1);
        public static double df2x2(double x1, double x2) => 200 * (x2 - Pow(x1, 2));

        public static double f3(double x1, double x2) => -12 * x2 + 4 * Pow(x1, 2) + 4 * Pow(x2, 2) - 4 * x1 * x2;
        public static double df3x1(double x1, double x2) => 8 * x1 - 4 * x2;
        public static double df3x2(double x1, double x2) => -4 * (x1 - 2 * x2 + 3);

    }
}
