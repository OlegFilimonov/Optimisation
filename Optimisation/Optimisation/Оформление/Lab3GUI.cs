using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FPlotLibrary;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;
using Optimisation.Одномерные.Цепочки;
using Optimisation.Одномерные_цепочки;

namespace Optimisation
{
    public partial class MainForm
    {

        private List<Function> testingFunctions3 = new List<Function>();
        private List<OneDimMethod> oneDimentionalMethods3 = new List<OneDimMethod>();
        private List<FunctionItem> graphFunctions3 = new List<FunctionItem>();

        void addTwoDimFunction(string source, function2D f, function2D dfx1, function2D dfx2, PointF start, PointF dir, PointF min, string name)
        {
            var graphFunction = new Function2D();
            graphFunction.source = source;
            graphFunction.Compile(true);
            graphFunction.Color = Color.CornflowerBlue;
            graphFunctions3.Add(graphFunction);
            testingFunctions3.Add(new FunctionTwoDim(start, min, dir, f, dfx1, dfx2, name));
        }

        void initilize3()
        {
            populateFunctions3();
            populateMethods3();
        }

        private void populateMethods3()
        {
            //заполняем наш список
            oneDimentionalMethods3.Add(new GoldenRatioMethod1(null));
            oneDimentionalMethods3.Add(new GoldenRatioMethod2(null));
            oneDimentionalMethods3.Add(new DichotomyMethod(null));
            oneDimentionalMethods3.Add(new FibonacciMethod1(null));
            oneDimentionalMethods3.Add(new FibonacciMethod2(null));
            oneDimentionalMethods3.Add(new BolzanoMethod(null, null));
            oneDimentionalMethods3.Add(new ExtrapolationMethod(null));
            oneDimentionalMethods3.Add(new PaulMethod(null, null));
            oneDimentionalMethods3.Add(new DSK_Method(null));
            oneDimentionalMethods3.Add(new DavidonMethod(null, null));
            oneDimentionalMethods3.Add(new svenn_bolz_gr1());
            oneDimentionalMethods3.Add(new svenn_bolz_fib2());
            oneDimentionalMethods3.Add(new fib1_dsk());
            oneDimentionalMethods3.Add(new fib2_dsk());
            oneDimentionalMethods3.Add(new dih_paul());
            oneDimentionalMethods3.Add(new bolz_paul());
            oneDimentionalMethods3.Add(new gr1_extr());
            oneDimentionalMethods3.Add(new dih_dav());
            oneDimentionalMethods3.Add(new extr_dav());
            oneDimentionalMethods3.Add(new gr2_paul());

            //заполняем выпадающий список
            foreach (var method in oneDimentionalMethods3)
            {
                methodList3.Items.Add(method.MethodName);
            }
        }

        void populateFunctions3()
        {
            //((pow(x,2)+3*pow(y,2)+2*x*y)%1==0)?0:1; double(double x, double y)
            
            addTwoDimFunction("return (pow(x,2)+3*pow(y,2)+2*x*y)/10;", TwoDimTestingFunctions.f1,
                TwoDimTestingFunctions.df1x1, TwoDimTestingFunctions.df1x2, new PointF(1, 1), new PointF(2, 3),
                new PointF(0.2558f, -0.1163f), "Функция №10: x1^2+3x2^2+2x1x2");

            addTwoDimFunction("return 100*pow(y-pow(x,2),2)+pow(1-x,2);", TwoDimTestingFunctions.f2,
                TwoDimTestingFunctions.df2x1, TwoDimTestingFunctions.df2x2, new PointF(-1, 0), new PointF(5, 1),
                new PointF(-0.3413f, 0.13172f), "Функция 11: 100(x2-x1^2)^2+(1-x1)^2");

            addTwoDimFunction("return -12*y+4*pow(x,2)+4*pow(y,2)-4*x*y;", TwoDimTestingFunctions.f3,
                TwoDimTestingFunctions.df3x1, TwoDimTestingFunctions.df3x2, new PointF(-0.5f, 1), new PointF(1, 0),
                new PointF(0.5f, 1), "Функция №12: -12x2+4x1^2+4x2^2-4x1x2");

            addTwoDimFunction("return pow(x-2,4)+pow(x-2*y,2);", TwoDimTestingFunctions.f4,
                TwoDimTestingFunctions.df4x1, TwoDimTestingFunctions.df4x2, new PointF(0, 3), new PointF(1, 0),
                new PointF(3.13f, 3.00f), "Функция №13: (x1-2)^4+(x1-2x2)^2");

            addTwoDimFunction("return 4*pow(x-5,2)+pow(y-6,2);", TwoDimTestingFunctions.f5,
                TwoDimTestingFunctions.df5x1, TwoDimTestingFunctions.df5x2, new PointF(8, 9), new PointF(1, 0),
                new PointF(5, 9), "Функция №14: 4(x1-5)^2+(x2-6)^2");

            addTwoDimFunction("return pow(x-2,4)+pow(x-2*y,2);", TwoDimTestingFunctions.f6,
                TwoDimTestingFunctions.df6x1, TwoDimTestingFunctions.df6x2, new PointF(0, 3), new PointF(44, -24.1f),
                new PointF(2.7f, 1.51f), "Функция №15: (x1-2)^4+(x1-2x2)^2");
            foreach (var func in testingFunctions3)
            {
                functionList3.Items.Add(func.Name);
            }

        }

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && currMethod != null)
            {
                makeMethod3(currMethod);
            }
        }

        private void functionList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionList3.SelectedIndex == -1) return;
            currFunction = testingFunctions3[functionList3.SelectedIndex];
            var cast = (FunctionTwoDim) currFunction;
            startBox3x1.Text = Convert.ToString(cast.Start.X);
            startBox3x2.Text = Convert.ToString(cast.Start.Y);
         
            make2DFunction(currFunction);
        }

        private void make2DFunction(Function testingFunction)
        {
            double minX, minY,startX,startY;
            try
            {
                startX = double.Parse(startBox3x1.Text);
                startY = double.Parse(startBox3x2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введены начальные координаты");
                startX = ((FunctionTwoDim)testingFunction).Start.X;
                startY = ((FunctionTwoDim)testingFunction).Start.Y;
            }

            ((FunctionTwoDim)testingFunction).Start = new PointF((float) startX,(float) startY);

            minX = ((FunctionTwoDim)testingFunction).Min.X;
            minY = ((FunctionTwoDim)testingFunction).Min.Y;
            var f = testingFunction.F;

            //TODO: подумай о границах

            const double length = 30;

            var x0 = minX - length / 2;
            var x1 = minX + length / 2;

            var y0 = minY - length / 2;
            var y1 = minY + length / 2;

            graph.x0 = x0;
            graph.x1 = x1;

            graph.y0 = y0;
            graph.y1 = y1;

            var func = graphFunctions3[testingFunctions3.IndexOf(testingFunction)];

            if (graph.Model.Items.Count < 1) graph.Model.Items.Add(func);
            else
                graph.Model.Items[0] = func;

            graph.Invalidate();
            graph.Update();
        }

        void makeMethod3(OneDimMethod method)
        {
            method.F = currFunction.F;
            method.Df = currFunction.Df;

            double startingX, eps;
            try
            {
                eps = double.Parse(epsBox3.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " + exception.Message);
                
                eps = 1e-2;
                epsBox3.Text = "1e-2";
            }

            startingX = 0;

            //Корректируем начальный шаг по формуле
            const double startingH = 0.001;

            //Точность
            method.Eps = eps;

            //Делаем свена
            method.setSvenInterval(startingX, startingH);

            //Делаем сам метод
            method.execute();

            //Вывод, Двуменрная функция
            var cast = (FunctionTwoDim) currFunction;
            var coord = (cast).getOffset(method.Answer);
            minBox3.Text = Convert.ToString(coord.X) + "; " + Convert.ToString(coord.Y);
            iterBox3.Text = Convert.ToString(method.IterationCount);
            diffBox3.Text = (Convert.ToString(Math.Abs(cast.Min.X - coord.X)) + "; " + Convert.ToString(Math.Abs(cast.Min.Y - coord.Y)));
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList3.SelectedIndex == -1) return;
            currMethod = oneDimentionalMethods3[methodList3.SelectedIndex];
            makeMethod3(currMethod);
        }
    }


}
