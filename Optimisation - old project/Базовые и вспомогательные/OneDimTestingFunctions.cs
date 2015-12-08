using System;

// ReSharper disable InconsistentNaming

namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    ///     Класс типичных функций для тестирования
    /// </summary>
    public static class OneDimTestingFunctions
    {
        public static double f1(double x) => 2*Math.Pow(x, 2) + 3*Math.Exp(-x);
        public static double df1(double x) => 4*x - 3*Math.Pow(Math.E, -x);
        public static double d2f1(double x) => 4 + 3*Math.Exp(-x);

        public static double f2(double x) => -Math.Pow(Math.E, -x)*Math.Log(x);
        public static double df2(double x) => Math.Pow(Math.E, -x)*(x*Math.Log(x) - 1)/x;
        public static double d2f2(double x) => Math.Exp(-x)*(Math.Pow(x, 2)*(-Math.Log(x)) + 2*x + 1)/Math.Pow(x, 2);

        public static double f3(double x) => 2*Math.Pow(x, 2) - Math.Exp(x);
        public static double df3(double x) => 4*x - Math.Exp(x);
        public static double d2f3(double x) => 4 - Math.Exp(x);

        public static double f4(double x) => Math.Pow(x, 4) - 14*Math.Pow(x, 3) + 60*Math.Pow(x, 2) - 70*x;
        public static double df4(double x) => 4*Math.Pow(x, 3) - 42*Math.Pow(x, 2) + 120*x - 70;
        public static double d2f4(double x) => 12*Math.Pow(x, 2) - 84*x + 120;
    }
}