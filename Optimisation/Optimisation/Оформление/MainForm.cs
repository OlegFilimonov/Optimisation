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
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;
using Optimisation.Одномерные.Цепочки;
using Optimisation.Одномерные_цепочки;
using DoubleConverter = Optimisation.Одномерные.DoubleConverter;

namespace Optimisation
{
    public partial class MainForm : Form
    {
        private Function currFunction;
        private OneDimMethod currMethod;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populateFunctions1();
            populateMethods1();
        }

        /// <summary>
        /// Рисует функцию и инициализирует ее
        /// </summary>
        /// <param name="testingFunction">Функция для инициализации</param>
        private void makeFunction(Function testingFunction)
        {
           
            double minX, minY;
            currFunction = testingFunction;
            if (testingFunction is FunctionOneDim)
            {
                //Одномерная функция
                minX = ((FunctionOneDim)testingFunction).Min;
                var f = testingFunction.F;

                if (currMethod != null) makeMethod(currMethod);

                const double length = 1;

                var x0 = minX - length / 2;
                var x1 = minX + length / 2;

                var y0 = f(minX) - length / 2;
                var y1 = f(minX) + length / 2;

                graph.x0 = x0;
                graph.x1 = x1;

                graph.y0 = y0;
                graph.y1 = y1;
            }
            else
            {
                //Функция двумерная
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
            }


            var func = graphFunctions[testingFunctions.IndexOf(testingFunction)];

            if (graph.Model.Items.Count < 1) graph.Model.Items.Add(func);
            else
                graph.Model.Items[0] = func;

            graph.Invalidate();
            graph.Update();
        }

        /// <summary>
        /// Запускает одномерный метод на выбранной функции
        /// </summary>
        /// <param name="method">Метод для запуска</param>
        private void makeMethod(OneDimMethod method)
        {
            if ((method is NewtonMethod || method is svenn_dih_newt) && (currFunction is FunctionTwoDim))
            {
                MessageBox.Show("Вторая производная для функции отсутствует");
                return;
            }
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
                startingX = double.Parse(startingPoint1.Text);
                eps = double.Parse(startingEps1.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " + exception.Message);
                startingX = 1;
                eps = 1e-2;
                startingPoint1.Text = "1";
                startingEps1.Text = "1e-2";
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
            if (currFunction is FunctionOneDim)
            {
                minBox1.Text = DoubleConverter.ToExactString(method.Answer);
                iterBox1.Text = Convert.ToString(method.IterationCount);
                diffBox1.Text = Convert.ToString(Math.Abs(method.A - method.B));

                var aFunction = new Function2D();
                aFunction.source = "return (abs(x-p[0])<p[1])?0:1f;";
                aFunction.Compile(true);
                aFunction.p[0] = method.A;
                aFunction.p[1] = 0.001F;
                aFunction.lineWidth = 0.00001F;
                aFunction.Color = Color.MediumVioletRed;

                var bFunction = new Function2D();
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
            }
            else
            {
                //Двуменрная функция
                var coord = ((FunctionTwoDim)currFunction).getOffset(method.Answer);
                minBox1.Text = Convert.ToString(coord.X) + "; " + Convert.ToString(coord.Y);
                iterBox1.Text = Convert.ToString(method.IterationCount);
                diffBox1.Text = "no";
            }
            graph.Invalidate();
            graph.Update();
        }

        private void functionList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            graph.ResetRange();
            methodList1.SelectedIndex = -1;
            var index = functionList1.SelectedIndex;
            Function testingFunction = testingFunctions[index];
            makeFunction(testingFunction);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<OneDimMethod> metgods = oneDimentionalMethods.Concat(oneDimentionalMethods2).ToList();
            string report = "";
            foreach (var method in metgods)
            {
                if (method is NewtonMethod)
                {
                    ((NewtonMethod)method).D2F = currFunction.D2F;
                }
                if (method is svenn_dih_newt)
                {
                    ((svenn_dih_newt)method).D2F = currFunction.D2F;
                }

                if ((method is NewtonMethod || method is svenn_dih_newt) && (currFunction is FunctionTwoDim))
                {
                    continue;
                }

                method.F = currFunction.F;
                method.Df = currFunction.Df;

                double startingX, eps;

                try
                {
                    startingX = double.Parse(startingPoint1.Text);
                    eps = double.Parse(startingEps1.Text);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " + exception.Message);
                    startingX = 1;
                    eps = 1e-2;
                    startingPoint1.Text = "1";
                    startingEps1.Text = "1e-2";
                }

                //Корректируем начальный шаг по формуле
                var startingH = (startingX == 0) ? 0.01 : 0.01 * startingX;

                //Точность
                method.Eps = eps;

                //Делаем свена
                method.setSvenInterval(startingX, startingH);

                //Делаем сам метод
                method.execute();
                if (currFunction is FunctionTwoDim)
                {
                    var coord = ((FunctionTwoDim)currFunction).getOffset(method.Answer);
                    report += string.Format("{0}: {1};{2}\n", method.MethodName, (coord.X), (coord.Y));
                }
                else
                    report += string.Format("Ответ: {0}\t{1}\n", DoubleConverter.ToExactString(method.Answer), method.MethodName);
            }
            MessageBox.Show(report);

        }

        private void startingPoint1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startingEps1_TextChanged(object sender, EventArgs e)
        {

        }

        private void methodList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
