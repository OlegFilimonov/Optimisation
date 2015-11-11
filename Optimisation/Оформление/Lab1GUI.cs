using System;
using System.Collections.Generic;
using System.Drawing;
using FPlotLibrary;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;
using Function1D = Optimisation.Базовые_и_вспомогательные.Function1D;
// ReSharper disable InconsistentNaming

namespace Optimisation.Оформление
{
    public partial class MainForm
    {
        private readonly List<OneDimMethod> _oneDimentionalMethods = new List<OneDimMethod>();
        private readonly List<FunctionHolder> _testingFunctions = new List<FunctionHolder>();
        private readonly List<FunctionItem> _graphFunctions = new List<FunctionItem>();

        private void Initilize1() //Констуктор
        {
            PopulateFunctions1();
            populateMethods1();
        }

        void AddOneDimFunction(string source, Function1D f, Function1D df, double min, string name, Function1D d2f = null)
        {
            var graphFunction = new FPlotLibrary.Function1D {source = source};
            graphFunction.Compile(true);
            graphFunction.Color = Color.Blue;
            graphFunction.lineWidth = 3;
            _graphFunctions.Add(graphFunction);
            _testingFunctions.Add(new FunctionHolderOneDim(f, df, name, min, d2f));
        }

        private void functionList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionList1.SelectedIndex == -1) return;
            _currFunctionHolder = _testingFunctions[functionList1.SelectedIndex];
            MakeFunction(_currFunctionHolder);
        }

        private void PopulateFunctions1()
        {
            //заполняем наш список
            AddOneDimFunction("return 2*pow(x,2) + 3*exp(-x);", OneDimTestingFunctions.f1, OneDimTestingFunctions.df1,
                0.469150D, "Функция #1: y = 2x^2 + 3e^-x", OneDimTestingFunctions.d2f1);
            AddOneDimFunction("return -exp(-x)*log(x);", OneDimTestingFunctions.f2, OneDimTestingFunctions.df2,
                1.763223D, "Функция #2: -e^-x*ln(x)", OneDimTestingFunctions.d2f2);
            AddOneDimFunction("return 2*pow(x,2)-pow(e,x);", OneDimTestingFunctions.f3, OneDimTestingFunctions.df3,
                0.357403D, "Функция #3: 2x^2-e^x", OneDimTestingFunctions.d2f3);
            AddOneDimFunction("return pow(x,4)-14*pow(x,3)+60*pow(x,2)-70*x;", OneDimTestingFunctions.f4,
                OneDimTestingFunctions.df4, 0.780884D, "Функция #4: x^4-14x^3+60x^2-70x", OneDimTestingFunctions.d2f4);
            
            //заполняем выпадающий список
            foreach (var func in _testingFunctions)
            {
                functionList1.Items.Add(func.Name);
                functionList2.Items.Add(func.Name);
            }
        }

        private void populateMethods1()
        {
            //заполняем наш список
            _oneDimentionalMethods.Add(new GoldenRatioMethod1(null));
            _oneDimentionalMethods.Add(new GoldenRatioMethod2(null));
            _oneDimentionalMethods.Add(new DichotomyMethod(null));
            _oneDimentionalMethods.Add(new FibonacciMethod1(null));
            _oneDimentionalMethods.Add(new FibonacciMethod2(null));
            _oneDimentionalMethods.Add(new BolzanoMethod(null, null));
            _oneDimentionalMethods.Add(new ExtrapolationMethod(null));
            _oneDimentionalMethods.Add(new PaulMethod(null, null));
            _oneDimentionalMethods.Add(new DskMethod(null));
            _oneDimentionalMethods.Add(new DavidonMethod(null, null));
            _oneDimentionalMethods.Add(new NewtonMethod(null, null, null));

            //заполняем выпадающий список
            foreach (var method in _oneDimentionalMethods)
            {
                methodList1.Items.Add(method.Name);
            }
        }

        private void methodList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList1.SelectedIndex == -1) return;
            _currMethod = _oneDimentionalMethods[methodList1.SelectedIndex];
            MakeMethod(_currMethod);
        }
    }
}
