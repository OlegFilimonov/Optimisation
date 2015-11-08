using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Jace;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;
using Optimisation.Одномерные_цепочки;
using Optimisation.Тестирование;
using Function2D = FPlotLibrary.Function2D;
// ReSharper disable CompareOfFloatsByEqualityOperator

namespace Optimisation.Оформление
{
    public partial class MainForm : Form
    {
        private FunctionHolder _currFunctionHolder;
        private OneDimMethod _currMethod;

        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initilize1();
            Initilize2();
            Initilize3();
            Initilize4();
        }

        /// <summary>
        ///     Рисует функцию и инициализирует ее
        /// </summary>
        /// <param name="testingFunction">Функция для инициализации</param>
        private void MakeFunction(FunctionHolder testingFunction)
        {
            //Одномерная функция
            var minX = ((FunctionHolderOneDim)testingFunction).Min;
            var f = testingFunction.F;

            if (_currMethod != null) MakeMethod(_currMethod);

            const double length = 1;

            var x0 = minX - length / 2;
            var x1 = minX + length / 2;

            var y0 = f(minX) - length / 2;
            var y1 = f(minX) + length / 2;

            graph.x0 = x0;
            graph.x1 = x1;

            graph.y0 = y0;
            graph.y1 = y1;

            var func = _graphFunctions[_testingFunctions.IndexOf(testingFunction)];

            if (graph.Model.Items.Count < 1) graph.Model.Items.Add(func);
            else
                graph.Model.Items[0] = func;

            graph.Invalidate();
            graph.Update();
        }

        /// <summary>
        ///     Запускает одномерный метод на выбранной функции
        /// </summary>
        /// <param name="method">Метод для запуска</param>
        private void MakeMethod(OneDimMethod method)
        {
            if ((method is NewtonMethod || method is SvennDihNewt) && (_currFunctionHolder is FunctionHolderTwoDim))
            {
                MessageBox.Show("Вторая производная для функции отсутствует");
                return;
            }
            if (method.Name == "Метод НЬЮТОНА")
            {
                ((NewtonMethod)method).D2F = _currFunctionHolder.D2F;
            }
            if (method.Name == "М5 - Свенн - дихтомии - Ньютона")
            {
                ((SvennDihNewt)method).D2F = _currFunctionHolder.D2F;
            }
            method.F = _currFunctionHolder.F;
            method.Df = _currFunctionHolder.Df;

            double startingX, eps;
            try
            {
                startingX = double.Parse(startBox1.Text);
                eps = double.Parse(epsBox1.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " +
                                exception.Message);
                startingX = 1;
                eps = 1e-2;
                startBox1.Text = "1";
                epsBox1.Text = "1e-2";
            }

            //Корректируем начальный шаг по формуле
            var startingH = (startingX == 0f) ? 0.01 : 0.01 * startingX;

            //Точность
            method.Eps = eps;

            //Делаем свена
            method.SetSvenInterval(startingX, startingH);

            //Делаем сам метод
            method.Execute();

            //Вывод
            minBox1.Text = DoubleConverter.ToExactString(method.Answer);
            iterBox1.Text = Convert.ToString(method.IterationCount);
            diffBox1.Text = Convert.ToString(Math.Abs(method.Answer - ((FunctionHolderOneDim)_currFunctionHolder).Min));
            minBox2.Text = DoubleConverter.ToExactString(method.Answer);
            iterBox2.Text = Convert.ToString(method.IterationCount);
            diffBox2.Text = Convert.ToString(Math.Abs(method.Answer - ((FunctionHolderOneDim)_currFunctionHolder).Min));


            var aFunction = new Function2D { source = "return (abs(x-p[0])<p[1])?0:1f;" };
            aFunction.Compile(true);
            aFunction.p[0] = method.A;
            aFunction.p[1] = 0.001F;
            aFunction.lineWidth = 0.00001F;
            aFunction.Color = Color.MediumVioletRed;

            var bFunction = new Function2D { source = "return (abs(x-p[0])<p[1])?0:1f;" };
            bFunction.Compile(true);
            bFunction.p[0] = method.B;
            bFunction.p[1] = 0.001F;
            bFunction.lineWidth = 0.001F;
            bFunction.Color = Color.MediumVioletRed;

            var cFunction = new Function2D { source = "return (abs(x-p[0])<p[1])?0:1f;" };
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

        private void startingPoint1_KeyUp(object sender, KeyEventArgs e)
        {
            if (_currMethod != null && e.KeyCode == Keys.Enter)
            {
                MakeMethod(_currMethod);
            }
        }

        private void lab1tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currMethod = null;
            _currFunctionHolder = null;
            methodList1.SelectedIndex = -1;
            methodList2.SelectedIndex = -1;
            methodList3.SelectedIndex = -1;
            functionList1.SelectedIndex = -1;
            functionList2.SelectedIndex = -1;
            functionList3.SelectedIndex = -1;
            minBox1.Text = "";
            minBox2.Text = "";
            startBox3x1.Text = "";
            startBox3x2.Text = "";
            iterBox1.Text = "";
            iterBox2.Text = "";
            iterBox3.Text = "";
            diffBox1.Text = "";
            diffBox2.Text = "";
            diffBox3.Text = "";
        }

        private void LaunchTestForm(double eps)
        {
            var metgods = _oneDimentionalMethods.Concat(_oneDimentionalMethods2).ToList();
            var export1And2 = new List<List<ExportOneDim>>(_testingFunctions.Count);
            var export3 = new List<List<ExportOneDim>>(_testingFunctions3.Count);
            var export4 = new List<List<ExportOneDim>>(_testingFunctions4.Count);

            //Заполняем первую лабу
            foreach (var function in _testingFunctions)
            {
                var exportList = new List<ExportOneDim>(metgods.Count);
                foreach (var method in metgods)
                {
                    if (method is NewtonMethod)
                    {
                        ((NewtonMethod)method).D2F = function.D2F;
                    }
                    if (method is SvennDihNewt)
                    {
                        ((SvennDihNewt)method).D2F = function.D2F;
                    }

                    if ((method is NewtonMethod || method is SvennDihNewt) && (function is FunctionHolderTwoDim))
                    {
                        continue;
                    }

                    method.F = function.F;
                    method.Df = function.Df;

                    double startingX = 1;

                    //Корректируем начальный шаг по формуле
                    var startingH = (startingX == 0) ? 0.01 : 0.01 * startingX;

                    //Точность
                    method.Eps = eps;

                    //Делаем свена
                    method.SetSvenInterval(startingX, startingH);

                    //Делаем сам метод
                    method.Execute();

                    var cast = (FunctionHolderOneDim)function;
                    var min = cast.Min;
                    var realEps = Math.Abs(method.Answer - cast.Min);
                    exportList.Add(new ExportOneDim(method.Name, (uint)method.IterationCount, method.Answer, min,
                        method.Eps, realEps));
                }
                export1And2.Add(exportList);
            }

            //Заполняем третью лабу
            foreach (var function in _testingFunctions3)
            {
                var exportList = new List<ExportOneDim>(metgods.Count);
                foreach (var method in metgods)
                {
                    if (method is NewtonMethod)
                    {
                        ((NewtonMethod)method).D2F = function.D2F;
                    }
                    if (method is SvennDihNewt)
                    {
                        ((SvennDihNewt)method).D2F = function.D2F;
                    }

                    if ((method is NewtonMethod || method is SvennDihNewt || method is ExtrDav) &&
                        (function is FunctionHolderTwoDim))
                    {
                        continue;
                    }

                    method.F = function.F;
                    method.Df = function.Df;

                    double startingX = 1;

                    //Корректируем начальный шаг по формуле
                    var startingH = (startingX == 0) ? 0.01 : 0.01 * startingX;

                    //Точность
                    method.Eps = eps;

                    //Делаем свена
                    method.SetSvenInterval(startingX, startingH);

                    //Делаем сам метод
                    method.Execute();
                    var castFunction = (FunctionHolderTwoDim)function;
                    var coord = castFunction.GetOffset(method.Answer);
                    var realEps =
                        Math.Abs(Math.Pow(castFunction.Min.X - coord.X, 2) + Math.Pow(castFunction.Min.Y - coord.Y, 2));
                    exportList.Add(new ExportOneDim(method.Name, (uint)method.IterationCount, coord,
                        castFunction.Min, method.Eps, realEps));
                }
                export3.Add(exportList);
            }

            //Заполняем четвертую лабу
            foreach (var function in _testingFunctions4)
            {
                var exportList = new List<ExportOneDim>(_twoDimentionalMethods4.Count);
                foreach (var method in _twoDimentionalMethods4)
                {
                   
                    method.F = function;

                    //Точность
                    method.Eps = eps;

                    //Делаем свена
                    method.SetSven4Interval();

                    //Делаем сам метод
                    method.Execute();

                    var castFunction = (FunctionHolderTwoDim)function;
                    var coord = method.Answer;
                    var realEps =
                        Math.Abs(Math.Pow(castFunction.Min.X - coord.X, 2) + Math.Pow(castFunction.Min.Y - coord.Y, 2));
                    exportList.Add(new ExportOneDim(method.Name, (uint)method.IterationCount, coord,
                        castFunction.Min, method.Eps, realEps));
                }
                export4.Add(exportList);
            }

            //Запускаем форму
            var form = new TestForm(export1And2, export3,export4);
            form.ShowDialog();
        }

        private void низкаяТочностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchTestForm(1e-2);
        }

        private void высокаяТочностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LaunchTestForm(1e-4);
        }

        private void graph_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (_currFunctionHolder is FunctionHolderTwoDim)
            {
                var cast = (FunctionHolderTwoDim)_currFunctionHolder;
                graph.z0 = cast.F2D(cast.Min.X, cast.Min.Y);
                graph.z1 = trackBar1.Value;

            }
            else if (_currFunctionHolder4 != null)
            {
                graph.z0 = _currFunctionHolder4.F2D(_currFunctionHolder4.Min.X, _currFunctionHolder4.Min.Y);
                graph.z1 = trackBar1.Value;
            }
        }


    }
}