using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
using Optimisation.Одномерные.Цепочки;
using Optimisation.Одномерные_цепочки;
using DoubleConverter = Optimisation.Одномерные.DoubleConverter;

namespace Optimisation
{
    public partial class MainForm : Form
    {
        private List<OneDimMethod> oneDimentionalChains = new List<OneDimMethod>();
        private List<OneDimMethod> oneDimentionalMethods = new List<OneDimMethod>();
        private List<Function> testingFunctions = new List<Function>();
        private List<Function1D> graphFunctions = new List<Function1D>();
        private Function currFunction;
        private OneDimMethod currMethod;

        void addFunction(string source, function f, function df, double min, string name, function d2f = null)
        {
            var graphFunction = new Function1D();
            graphFunction.source = source;
            graphFunction.Compile(true);
            graphFunction.Color = Color.Blue;
            graphFunction.lineWidth = 3;
            graphFunctions.Add(graphFunction);
            testingFunctions.Add(new Function(f, df, name, min,d2f));
        }

        private void populateFunctions()
        {
           
            addFunction("return 2*pow(x,2) + 3*exp(-x);", OneDimTestingFunctions.f1, OneDimTestingFunctions.df1, 0.469150D, "Функция #1: y = 2x^2 + 3e^-x",OneDimTestingFunctions.d2f1);
            addFunction("return -exp(-x)*log(x);", OneDimTestingFunctions.f2, OneDimTestingFunctions.df2, 1.763223D, "Функция #2: -e^-x*ln(x)", OneDimTestingFunctions.d2f2);
            addFunction("return 2*pow(x,2)-pow(e,x);", OneDimTestingFunctions.f3, OneDimTestingFunctions.df3, 0.357403D, "Функция #3: 2x^2-e^x", OneDimTestingFunctions.d2f3);
            addFunction("return pow(x,4)-14*pow(x,3)+60*pow(x,2)-70*x;", OneDimTestingFunctions.f4, OneDimTestingFunctions.df4, 0.780884D, "Функция #4: x^4-14x^3+60x^2-70x", OneDimTestingFunctions.d2f4);
        }

        private void populateMethods()
        {
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
            oneDimentionalMethods.Add(new NewtonMethod(null,null,null));
        }

        private void populateChains()
        {
            oneDimentionalChains.Add(new svenn_dih_newt());
            oneDimentionalChains.Add(new svenn_bolz_gr1());
            oneDimentionalChains.Add(new svenn_bolz_fib2());
            
            oneDimentionalChains.Add(new fib1_dsk());
            oneDimentionalChains.Add(new fib2_dsk());
            oneDimentionalChains.Add(new dih_paul());
            oneDimentionalChains.Add(new bolz_paul());
            oneDimentionalChains.Add(new gr1_extr());
            oneDimentionalChains.Add(new dih_dav());
            oneDimentionalChains.Add(new extr_dav());
            oneDimentionalChains.Add(new gr2_paul());
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

            foreach (var method in oneDimentionalChains)
            {
                chainList.Items.Add(method.MethodName);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populateFunctions();
            populateMethods();
            populateChains();
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

            if(currMethod!=null) makeMethod(currMethod);

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
                button1.Enabled = true;
            }
        }

        private void playListRadioButton_CheckedChanged(object sender, EventArgs e)
        {

            methodList.Enabled = !playListRadioButton.Checked;
            chainList.Enabled = playListRadioButton.Checked;
        }


        private void makeMethod(OneDimMethod method)
        {
            if (method.MethodName == "Метод НЬЮТОНА")
            {
                ((NewtonMethod)method).D2F = currFunction.D2F;
            }
            if (method.MethodName == "М5 - Свенн - дихтомии - Ньютона")
            {
                ((svenn_dih_newt)method).D2F = currFunction.D2F;
            }
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
                makeMethod(currMethod);
            }
        }

        private void methodList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList.SelectedIndex == -1)
            {
                return;
            }
            currMethod = oneDimentionalMethods[methodList.SelectedIndex];
            makeMethod(currMethod);
        }


        private void playList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chainList.SelectedIndex == -1) return;
            currMethod = oneDimentionalChains[chainList.SelectedIndex];
            makeMethod(currMethod);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<OneDimMethod> metgods = oneDimentionalMethods.Concat(oneDimentionalChains).ToList();
            string report = "";
            foreach (var method in metgods)
            {
                if (method.MethodName == "Метод НЬЮТОНА")
                {
                    ((NewtonMethod)method).D2F = currFunction.D2F;
                }
                if (method.MethodName == "М5 - Свенн - дихтомии - Ньютона")
                {
                    ((svenn_dih_newt)method).D2F = currFunction.D2F;
                }
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

                report += string.Format("Ответ: {0}\t{1}\n",DoubleConverter.ToExactString(method.Answer), method.MethodName);
            }
            MessageBox.Show(report);

        }

        private void startingPoint_ValueChanged(object sender, EventArgs e)
        {

            if (currMethod != null)
            {
                makeMethod(currMethod);
            }
        }
    }
}
