using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPlotLibrary;
using Optimisation.Testing;
using Optimisation.Одномерные;
using DoubleConverter = Optimisation.Одномерные.DoubleConverter;

namespace Optimisation
{
    public partial class MainForm : Form
    {
        private List<OneDimentionalOptimisationMethod> oneDimentionalMethods = new List<OneDimentionalOptimisationMethod>();
        private List<Function> testingFunctions = new List<Function>();
        private List<Function1D> graphFunctions = new List<Function1D>();
        private Function currFunction;
        private OneDimentionalOptimisationMethod currMethod = null;

        void addFunction(string source, function f, function df, double min, string name)
        {
            var graphFunction = new Function1D();
            graphFunction.source = source;
            graphFunction.Compile(true);
            graphFunction.Color = Color.Blue;
            graphFunction.lineWidth = 3;
            graphFunctions.Add(graphFunction);
            testingFunctions.Add(new Function(f, df, name, min));
        }

        private void populateFunctions()
        {
           
            addFunction("return 2*pow(x,2) + 3*exp(-x);", TestingFunctions.f1, TestingFunctions.df1, 0.469150D, "Функция #1: y = 2x^2 + 3e^-x");
            addFunction("return -exp(-x)*log(x);", TestingFunctions.f2, TestingFunctions.df2, 1.763223D, "Функция #2: -e^-x*ln(x)");
            addFunction("return 2*pow(x,2)-pow(e,x);", TestingFunctions.f3, TestingFunctions.df3, 0.357403D, "Функция #3: 2x^2-e^x");
            addFunction("return pow(x,4)-14*pow(x,3)+60*pow(x,2)-70*x;", TestingFunctions.f4, TestingFunctions.df4, 0.780884D, "Функция #4: x^4-14x^3+60x^2-70x");
        }

        private void populateMethods(function f, function df)
        {
            oneDimentionalMethods.Add(new GoldenRatioMethod1(f));
            oneDimentionalMethods.Add(new GoldenRatioMethod2(f));
            oneDimentionalMethods.Add(new DichotomyMethod(f));
            oneDimentionalMethods.Add(new FibonacciMethod1(f));
            oneDimentionalMethods.Add(new FibonacciMethod2(f));
            oneDimentionalMethods.Add(new BolzanoMethod(f, df));
            oneDimentionalMethods.Add(new ExtrapolationMethod(f));
            oneDimentionalMethods.Add(new PaulMethod(f, df));
            oneDimentionalMethods.Add(new DSK_Method(f));
            oneDimentionalMethods.Add(new DavidonMethod(f, df));
        }

        private void populateList()
        {
            foreach (var func in testingFunctions)
            {
                functionList.Items.Add(func.Name);
            }
            foreach (var method in oneDimentionalMethods)
            {
                methodList.Items.Add(method.MethodName);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populateFunctions();
            populateMethods(null, null);
            populateList();
        }

        private void functionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph.ResetRange();
            methodList.SelectedIndex = -1;
            
            
            var index = functionList.SelectedIndex;
            var min = testingFunctions[index].Min;
            var f = testingFunctions[index].F;

            currFunction = testingFunctions[index];

            const double length = 1;

            var x0 = min - length / 2;
            var x1 = min + length / 2;

            var y0 = f(min) - length / 2;
            var y1 = f(min) + length / 2;

            graph.x0 = x0;
            graph.x1 = x1;

            graph.y0 = y0;
            graph.y1 = y1;

            var func = graphFunctions[index];

            if (graph.Model.Items.Count < 1) graph.Model.Items.Add(func);
            else
                graph.Model.Items[0] = func;

            graph.Invalidate();
            graph.Update();

            if (!methodRadioButton.Enabled)
            {
                methodRadioButton.Enabled = true;
                playListRadioButton.Enabled = true;
                methodRadioButton.Checked = true;
                methodList.Enabled = true;
            }
        }

        private void playListRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            methodList.Enabled = !playListRadioButton.Checked;
            playList.Enabled = playListRadioButton.Checked;
        }

        private void methodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList.SelectedIndex == -1)
            {
                return;
            }
            currMethod = oneDimentionalMethods[methodList.SelectedIndex];
            makeMethod();
        }

        private void makeMethod()
        {
            var method = oneDimentionalMethods[methodList.SelectedIndex];
            method.F = currFunction.F;
            method.Df = currFunction.Df;
            
            double startingX, eps;

            try
            {
                startingX = double.Parse(startingPoint.Text);
                eps = double.Parse(startingEps.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " + exception.Message);
                startingX = 1;
                eps = 1e-2;
                startingPoint.Text = "1";
                startingEps.Text = "1e-2";
            }

            //Корректируем начальный шаг по формуле
            var startingH = (startingX == 0) ? 0.01 : 0.01 * startingX;

            //Точность
            method.Eps = eps;

            //Делаем свена
            method.setSvenInterval(startingX, startingH);

            //Делаем сам метод
            method.execute();

            //Вывод
            ansBox.Text = DoubleConverter.ToExactString(method.Answer);
            iterationBox.Text = Convert.ToString(method.IterationCount);
            diffBox.Text = Convert.ToString(Math.Abs(method.A - method.B));

            var aFunction = new Function2D();
            aFunction.source = "return (abs(x-p[0])<p[1])?0:1f;";
            aFunction.Compile(true);
            aFunction.p[0] = method.A;
            aFunction.p[1] = 0.001F;
            aFunction.lineWidth = 0.00001F;
            aFunction.Color = Color.MediumVioletRed;

            var bFunction  = new Function2D();
            bFunction.source = "return (abs(x-p[0])<p[1])?0:1f;";
            bFunction.Compile(true);
            bFunction.p[0] = method.B;
            bFunction.p[1] = 0.001F;
            bFunction.lineWidth = 0.001F;
            bFunction.Color = Color.MediumVioletRed;

            var cFunction = new Function2D();
            cFunction.source = "return (abs(x-p[0])<p[1])?0:1f;";
            cFunction.Compile(true);
            cFunction.p[0] = method.Answer;
            cFunction.p[1] = 0.001F;
            cFunction.lineWidth = 0.001F;
            cFunction.Color = Color.MediumSpringGreen;

            if (graph.Model.Items.Count < 2)
            {
                graph.Model.Items.Add(aFunction);
                graph.Model.Items.Add(bFunction);
                graph.Model.Items.Add(cFunction);
            }
            else
            {
                graph.Model.Items[1] = aFunction;
                graph.Model.Items[2] = bFunction;
                graph.Model.Items[3] = cFunction;
            }
            graph.Invalidate();
            graph.Update();
        }

        private void startingEps_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            bool correct = double.TryParse(startingEps.Text, out tmp);
            if (correct&&currMethod != null)
            {
                makeMethod();
            }
        }

        private void startingPoint_TextChanged(object sender, EventArgs e)
        {
            double tmp;
            bool correct = double.TryParse(startingEps.Text, out tmp);
            if (correct && currMethod != null)
            {
                makeMethod();
            }
        }

        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
