using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using FPlotLibrary;
using Optimisation.Одномерные;

namespace Optimisation.Testing
{
    //Класс типичных функций для тестирования
    public class TestingFunctions
    {
        public static double f1(double x) => 2*Math.Pow(x, 2) + 3*Math.Pow(Math.E, -x);
        public static double df1(double x) => 4*x + 3* Math.Pow(Math.E, -x);

        public static double f2(double x) => -Math.Pow(Math.E, -x) *Math.Log(x);
        public static double df2(double x) => -Math.Pow(Math.E, -x)*(x*Math.Log(x) - 1)/x;

        public static double f3(double x) => 2*Math.Pow(x, 2) - Math.Exp(x);
        public static double df3(double x) => 4*x - Math.Exp(x);

        public static double f4(double x) => Math.Pow(x,4) - 14*Math.Pow(x,3) + 60*Math.Pow(x,2) - 70*x;
        public static double df4(double x) => 4*Math.Pow(x, 3) - 42*Math.Pow(x, 2) + 120*x - 70;
    }

    //Класс, хранящий функции для тестирования
    public class Function
    {
        private function f;
        private function df;
        private string name;
        private double min;
        private double startingX;

        public Function(function f, function df, string name,double min)
        {
            this.f = f;
            this.df = df;
            this.name = name;
            this.min = min;
        }

        public function F1
        {
            get { return f; }
        }

        public double Min
        {
            get { return min; }
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
