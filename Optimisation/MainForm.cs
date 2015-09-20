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
        private List<Function1D> testingFunctions = new List<Function1D>();

        void add(string source)
        {
            var f1 = new Function1D();
            f1.source = source;
            f1.Color = Color.Blue;
            f1.lineWidth = 2;
            testingFunctions.Add(f1);
        }

        private void populateFunctions()
        {
            add("return 2 * pow(x, 2);");

            foreach (var func in testingFunctions)
            {
                graph.Model.Items.Add(func);
            }
            graph.Invalidate();
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
            oneDimentionalMethods.Add(new DavidonMethod(f, df));
        }

        private void populateList()
        {

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
    }
}
