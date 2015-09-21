using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FPlotLibrary;
using Optimisation.Testing;
using Optimisation.Одномерные;

namespace Optimisation
{
    public partial class MainForm : Form
    {
        private List<OneDimentionalOptimisationMethod> oneDimentionalMethods = new List<OneDimentionalOptimisationMethod>();
        private List<Function> testingFunctions = new List<Function>();
        private List<Function1D> graphFunctions = new List<Function1D>();

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
            addFunction("return 2*pow(x,2) + 3*pow(e,-x);", TestingFunctions.f1, TestingFunctions.df1, 0.469150D, "Функция #1: y = 2x^2 + 3e^-x");
            addFunction("return -pow(e,-x)*log(x);", TestingFunctions.f2, TestingFunctions.df2, 1.763223D, "Функция #2: -e^-x*ln(x)");
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
            if (graph.Model.Items.Count != 0) graph.Model.Items.Remove(graph.Model.Items[0]);
            var index = functionList.SelectedIndex;
            var min = testingFunctions[index].Min;
            var f = testingFunctions[index].F;
            graph.x0 = min - 3;
            graph.x1 = min + 3;

            graph.Model.Items.Add(graphFunctions[index]);
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
    }
}
