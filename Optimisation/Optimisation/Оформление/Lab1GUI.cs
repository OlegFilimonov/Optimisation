using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPlotLibrary;
using Optimisation.Testing;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;

namespace Optimisation
{
    public partial class MainForm
    {
        private List<OneDimMethod> oneDimentionalMethods = new List<OneDimMethod>();
        private List<Function> testingFunctions = new List<Function>();
        private List<FunctionItem> graphFunctions = new List<FunctionItem>();

        void addOneDimFunction(string source, function f, function df, double min, string name, function d2f = null)
        {
            var graphFunction = new Function1D();
            graphFunction.source = source;
            graphFunction.Compile(true);
            graphFunction.Color = Color.Blue;
            graphFunction.lineWidth = 3;
            graphFunctions.Add(graphFunction);
            testingFunctions.Add(new FunctionOneDim(f, df, name, min, d2f));
        }
        
        private void populateFunctions1()
        {
            //заполняем наш список
            addOneDimFunction("return 2*pow(x,2) + 3*exp(-x);", OneDimTestingFunctions.f1, OneDimTestingFunctions.df1,
                0.469150D, "Функция #1: y = 2x^2 + 3e^-x", OneDimTestingFunctions.d2f1);
            addOneDimFunction("return -exp(-x)*log(x);", OneDimTestingFunctions.f2, OneDimTestingFunctions.df2,
                1.763223D, "Функция #2: -e^-x*ln(x)", OneDimTestingFunctions.d2f2);
            addOneDimFunction("return 2*pow(x,2)-pow(e,x);", OneDimTestingFunctions.f3, OneDimTestingFunctions.df3,
                0.357403D, "Функция #3: 2x^2-e^x", OneDimTestingFunctions.d2f3);
            addOneDimFunction("return pow(x,4)-14*pow(x,3)+60*pow(x,2)-70*x;", OneDimTestingFunctions.f4,
                OneDimTestingFunctions.df4, 0.780884D, "Функция #4: x^4-14x^3+60x^2-70x", OneDimTestingFunctions.d2f4);
            
            //заполняем выпадающий список
            foreach (var func in testingFunctions)
            {
                functionList1.Items.Add(func.Name);
            }

        }

        private void populateMethods1()
        {
            //заполняем наш список
            oneDimentionalMethods.Add(new GoldenRatioMethod1(null));
            oneDimentionalMethods.Add(new GoldenRatioMethod2(null));
            oneDimentionalMethods.Add(new DichotomyMethod(null));
            oneDimentionalMethods.Add(new FibonacciMethod1(null));
            oneDimentionalMethods.Add(new FibonacciMethod2(null));
            oneDimentionalMethods.Add(new BolzanoMethod(null, null));
            oneDimentionalMethods.Add(new ExtrapolationMethod(null));
            oneDimentionalMethods.Add(new PaulMethod(null, null));
            oneDimentionalMethods.Add(new DSK_Method(null));
            oneDimentionalMethods.Add(new DavidonMethod(null, null));
            oneDimentionalMethods.Add(new NewtonMethod(null, null, null));

            //заполняем выпадающий список
            foreach (var method in oneDimentionalMethods)
            {
                methodList1.Items.Add(method.MethodName);
            }
        }

        private void startingEps1_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            bool correct = double.TryParse(startingEps1.Text, out tmp);
            if (correct && currMethod != null)
            {
                makeMethod(currMethod);
            }
        }

        private void methodList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList1.SelectedIndex == -1)
            {
                return;
            }
            currMethod = oneDimentionalMethods[methodList1.SelectedIndex];
            makeMethod(currMethod);
        }

        private void startingPoint1_ValueChanged(object sender, EventArgs e)
        {

            if (currMethod != null)
            {
                makeMethod(currMethod);
            }
        }
    }
}
