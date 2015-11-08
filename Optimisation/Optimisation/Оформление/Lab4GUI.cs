using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FPlotLibrary;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Двумерные;
using Function2D = Optimisation.Базовые_и_вспомогательные.Function2D;

namespace Optimisation.Оформление
{
    partial class MainForm
    {
        private readonly List<FunctionItem> _graphFunctions4 = new List<FunctionItem>();
        private readonly List<TwoDimMethod> _twoDimentionalMethods4 = new List<TwoDimMethod>();
        private readonly List<FunctionHolderTwoDim> _testingFunctions4 = new List<FunctionHolderTwoDim>();

        private FunctionHolderTwoDim _currFunctionHolder4;
        private TwoDimMethod _currMethod4;

        private void Initilize4()
        {
            PopulateFunctions4();
            PopulateMethods4();
        }

        private void PopulateMethods4()
        {
            _twoDimentionalMethods4.Add(new CauchyMethod(null));
            //заполняем выпадающий список
            foreach (var method in _twoDimentionalMethods4)
            {
                methodList4.Items.Add(method.Name);
            }
        }

        private void PopulateFunctions4()
        {
            AddTwoDimFunction4("return 100*pow(y-pow(x,2),2)+pow(1-x,2);", TwoDimTestingFunctions.f19,
                    TwoDimTestingFunctions.df19x1, TwoDimTestingFunctions.df19x2, new PointF(-1.2f, 1),
                    new PointF(1, 1), "Функция №19: 100(x2-x1^2)^2+(1-x1)^2");
            AddTwoDimFunction4("return pow(x,2)+3*pow(y,2)+2*x*y;", TwoDimTestingFunctions.f1,
                TwoDimTestingFunctions.df1x1, TwoDimTestingFunctions.df1x2, new PointF(1, 1),
                new PointF(0.2558f, -0.1163f), "Функция №10: x1^2+3x2^2+2x1x2");

            AddTwoDimFunction4("return 100*pow(y-pow(x,2),2)+pow(1-x,2);", TwoDimTestingFunctions.f2,
                TwoDimTestingFunctions.df2x1, TwoDimTestingFunctions.df2x2, new PointF(-1, 0),
                new PointF(-0.3413f, 0.13172f), "Функция 11: 100(x2-x1^2)^2+(1-x1)^2");

            AddTwoDimFunction4("return -12*y+4*pow(x,2)+4*pow(y,2)-4*x*y;", TwoDimTestingFunctions.f3,
                TwoDimTestingFunctions.df3x1, TwoDimTestingFunctions.df3x2, new PointF(-0.5f, 1),
                new PointF(0.5f, 1), "Функция №12: -12x2+4x1^2+4x2^2-4x1x2");

            AddTwoDimFunction4("return pow(x-2,4)+pow(x-2*y,2);", TwoDimTestingFunctions.f4,
                TwoDimTestingFunctions.df4x1, TwoDimTestingFunctions.df4x2, new PointF(0, 3),
                new PointF(3.13f, 3.00f), "Функция №13: (x1-2)^4+(x1-2x2)^2");

            AddTwoDimFunction4("return 4*pow(x-5,2)+pow(y-6,2);", TwoDimTestingFunctions.f5,
                TwoDimTestingFunctions.df5x1, TwoDimTestingFunctions.df5x2, new PointF(8, 9),
                new PointF(5, 9), "Функция №14: 4(x1-5)^2+(x2-6)^2");

            AddTwoDimFunction4("return pow(x-2,4)+pow(x-2*y,2);", TwoDimTestingFunctions.f6,
                TwoDimTestingFunctions.df6x1, TwoDimTestingFunctions.df6x2, new PointF(0, 3),
                new PointF(2.7f, 1.51f), "Функция №15: (x1-2)^4+(x1-2x2)^2");

            foreach (var func in _testingFunctions4)
            {
                functionList4.Items.Add(func.Name);
            }
        }

        private void functionList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionList4.SelectedIndex == -1) return;
            _currFunctionHolder4 = _testingFunctions4[functionList4.SelectedIndex];
            startingBox4x1.Text = Convert.ToString(_currFunctionHolder4.Start.X);
            startingBox4x2.Text = Convert.ToString(_currFunctionHolder4.Start.Y);

            Make2DFunction4(_currFunctionHolder4);
        }

        private void methodList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList4.SelectedIndex == -1) return;
            _currMethod4 = _twoDimentionalMethods4[methodList4.SelectedIndex];
            MakeMethod4(_currMethod4);
        }

        private void AddTwoDimFunction4(string source, Function2D f, Function2D dfx1, Function2D dfx2, PointF start,
            PointF min, string name)
        {
            var graphFunction = new FPlotLibrary.Function2D { source = source };
            graphFunction.Compile(true);
            graphFunction.Color = Color.CornflowerBlue;
            _graphFunctions4.Add(graphFunction);
            var func = new FunctionHolderTwoDim(start, min, f, dfx1, dfx2, name);
            _testingFunctions4.Add(func);
        }

        private void MakeMethod4(TwoDimMethod method)
        {
            method.F = _currFunctionHolder4;

            double eps;
            try
            {
                eps = double.Parse(startingEps4.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " +
                                exception.Message);

                eps = 1e-2;
                startingEps4.Text = "1e-2";
            }

            //Точность
            method.Eps = eps;

            //Делаем свена
            method.SetSven4Interval();

            //Делаем сам метод
            method.Execute();

            //Вывод, Двуменрная функция
            var coord = method.Answer;
            answerBox4.Text = Convert.ToString(coord.X) + "; " + Convert.ToString(coord.Y);
            iterBox4.Text = Convert.ToString(method.IterationCount);
            diffBox4.Text = (Convert.ToString(Math.Abs(_currFunctionHolder4.Min.X - coord.X)) + "; " +
                             Convert.ToString(Math.Abs(_currFunctionHolder4.Min.Y - coord.Y)));
        }

        private void Make2DFunction4(FunctionHolderTwoDim testingFunction)
        {
            double startX, startY;
            try
            {
                startX = double.Parse(startingBox4x1.Text);
                startY = double.Parse(startingBox4x2.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Неверно введены начальные координаты");
                startX = testingFunction.Start.X;
                startY = testingFunction.Start.Y;
            }

            testingFunction.Start = new PointF((float)startX, (float)startY);

            double minX = testingFunction.Min.X;
            double minY = testingFunction.Min.Y;

            const double length = 10;

            var x0 = minX - length / 2;
            var x1 = minX + length / 2;

            var y0 = minY - length / 2;
            var y1 = minY + length / 2;

            graph.x0 = x0;
            graph.x1 = x1;

            graph.y0 = y0;
            graph.y1 = y1;


            var func = _graphFunctions4[_testingFunctions4.IndexOf(testingFunction)];

            if (graph.Model.Items.Count < 1) graph.Model.Items.Add(func);
            else
                graph.Model.Items[0] = func;

            graph.Invalidate();
            graph.Update();
        }
    }
}