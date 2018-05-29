using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using CORE;
using CORE.Многомерные;
using CORE.Одномерные;
using CORE.Одномерные_цепочки;
using Jace;
using MaterialSkin;
using MaterialSkin.Controls;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace OptimisationCat
{
    public partial class MainForm : MaterialForm
    {
        private readonly List<OneDimMethod> _alphaMethods = new List<OneDimMethod>();
        private readonly List<string> _functions = new List<string>();
        private readonly MaterialSkinManager _materialSkinManager;
        private readonly List<OptimisationMethod> _methods = new List<OptimisationMethod>();
        private bool _alphaMethodChosen;
        private OneDimMethod _currAlphaMethod;

        private Func<Vector<double>, double> _currFunction;
        private OptimisationMethod _currMethod;

        private bool _functionChosen;
        private bool _methodChosen;
        private int _varCount;

        public MainForm()
        {
            InitializeComponent();
            PopulateFunctions();
            PopulateMethods();
            PopulateAlphaMethods();
            _materialSkinManager = MaterialSkinManager.Instance;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200, TextShade.WHITE);
        }

        private void UpdateForm()
        {
            calculateButton.Enabled = _functionChosen && _methodChosen;
            testAllButton.Enabled = _functionChosen;
        }

        #region populating combo boxes

        private void PopulateAlphaMethods()
        {
            //заполняем наш список
            _alphaMethods.Add(new GoldenRatio1(null));
            _alphaMethods.Add(new GoldenRatio2(null));
            _alphaMethods.Add(new Dichotomy(null));
            _alphaMethods.Add(new Fibonacci1(null));
            _alphaMethods.Add(new Fibonacci2(null));
            _alphaMethods.Add(new Bolzano(null, null));
            _alphaMethods.Add(new Extrapolation(null));
            _alphaMethods.Add(new Paul(null, null));
            _alphaMethods.Add(new Dsk(null));
            _alphaMethods.Add(new BoostedDavidon(null, null));
            _alphaMethods.Add(new SvennDihNewt());
            _alphaMethods.Add(new SvennBolzGr1());
            _alphaMethods.Add(new SvennBolzFib2());
            _alphaMethods.Add(new Fib1Dsk());
            _alphaMethods.Add(new Fib2Dsk());
            _alphaMethods.Add(new DihPaul());
            _alphaMethods.Add(new BolzPaul());
            _alphaMethods.Add(new Gr1Extr());
            _alphaMethods.Add(new DihDav());
            _alphaMethods.Add(new ExtrDav());
            _alphaMethods.Add(new Gr2Paul());

            foreach (var alphaMethod in _alphaMethods) alphaMethodComboBox.Items.Add(alphaMethod.Name);
        }

        private void PopulateMethods()
        {
//            _methods.Add(new Partan1());
//            _methods.Add(new KvasiNewton());
//            _methods.Add(new Msg());
//            _methods.Add(new GenericNewton());
            _methods.Add(new HookeJeeves());
            _methods.Add(new HookeJeevesPs());

            foreach (var method in _methods) methodComboBox.Items.Add(method.Name);
        }

        private void PopulateFunctions()
        {
            _functions.Add("10: x1^2+3*x2^2+2*x1*x2");
            _functions.Add("11: 100*(x2-x1^2)^2+(1-x1)^2");
            _functions.Add("12: -12*x2+4*x1^2+4*x2^2-4*x1*x2");
            _functions.Add("13: (x1-2)^4+(x1-2*x2)^2");
            _functions.Add("14: 4*(x1-5)^2+(x2-6)^2");
            _functions.Add("15: (x1-2)^4+(x1-2*x2)^2");
            _functions.Add("19: 100*(x2-x1^2)^2+(1-x1)^2");
            _functions.Add("20: (x1-1)^2+(x2-3)^2+4*(x3+5)^2");
            _functions.Add("21: 8*x1^2+4*x1*x2+5*x2^2");
            _functions.Add("22: 4*(x1-5)^2+(x2-6)^2");
            _functions.Add("27: -12*x2+4*x1^2+4*x2^2-4*x1*x2");
            _functions.Add("32: 100*(x2-x1^3)^2+(1-x1)^2");

            // ReSharper disable once CoVariantArrayConversion
            functionComboBox.Items.AddRange(_functions.ToArray());
        }

        #endregion

        #region Events

        /// <summary>
        ///     Загрузка формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            materialCheckBox1_CheckedChanged(null, null);
            UpdateForm();
        }

        /// <summary>
        ///     Изменение темы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            switch (materialCheckBox1.Checked)
            {
                case false:
                    _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                    break;
                case true:
                    _materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
                    break;
            }
        }

        /// <summary>
        ///     GRAPH BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void graphButton_Click(object sender, EventArgs e)
        {
            var func = _functions[functionComboBox.SelectedIndex];
            if (func.Contains(':'))
                func = func.Remove(0, func.IndexOf(':') + 1);
            //Запускаем форму
            var form = new GraphForm(func);
            _materialSkinManager.AddFormToManage(form);
            form.ShowDialog();
        }

        /// <summary>
        ///     CALCULATE BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            _currMethod.AlphaMethod = null;
            Vector<double> start = new DenseVector(_varCount);
            try
            {
                var text = startingPointTextBox.Text;
                var textValues = text.Split(',');
                for (var i = 0; i < _varCount; i++) start[i] = double.Parse(textValues[i]);
            }
            catch (Exception)
            {
                start.Clear();
            }

            var fh = new FunctionHolder(_currFunction, start);
            _currMethod.Fh = fh;
            if (_alphaMethodChosen)
            {
                _currAlphaMethod.F = fh.AlphaFunction;
                _currAlphaMethod.Df = fh.AlphaDiffFunction;
                _currMethod.AlphaMethod = _currAlphaMethod;
            }

            double eps;
            try
            {
                eps = double.Parse(precisionTextBox.Text);
            }
            catch (Exception)
            {
                eps = 1e-5;
                precisionTextBox.Text = @"1e-5";
            }

            _currMethod.Eps = eps;
            //Делаем сам метод
            var sw = Stopwatch.StartNew();
            _currMethod.Execute();
            sw.Stop();
            //Вывод, Двуменрная функция
            var coord = _currMethod.Answer;
            answerTextBox.Text = @"Answer:" + Environment.NewLine + coord.ToString();
            iterationTextBox.Text = Convert.ToString("Iterations: " + _currMethod.IterationCount);
            timeTextBox.Text = @"Time (ms):" + Environment.NewLine +
                               (sw.ElapsedMilliseconds == 0 ? "<1" : sw.ElapsedMilliseconds.ToString());
        }

        /// <summary>
        ///     выбираем альфа метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void alphaMethodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currAlphaMethod = _alphaMethods[alphaMethodComboBox.SelectedIndex];
            _alphaMethodChosen = true;
        }

        /// <summary>
        ///     Выбираем метод
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void methodComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currMethod = _methods[methodComboBox.SelectedIndex];
            _methodChosen = true;
            UpdateForm();
        }

        /// <summary>
        ///     Выбираем функцию и парсим ее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var functionText = functionComboBox.Text;

            try
            {
                ParseFunction(functionText);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Ошибка парсинга: " + exception.Message);
            }
            finally
            {
                UpdateForm();
            }
        }

        /// <summary>
        ///     Парсим функцию
        /// </summary>
        /// <param name="functionText"></param>
        private void ParseFunction(string functionText)
        {
            if (functionText.Contains(':'))
                functionText = functionText.Remove(0, functionText.IndexOf(':') + 1);

            var index = 0;
            _varCount = 0;

            while (index != -1)
            {
                index = functionText.IndexOf("x", index, StringComparison.Ordinal);
                if (index == -1) break;
                try
                {
                    int num;
                    if (int.TryParse(functionText.Substring(index + 1, 1), out num))
                        _varCount = _varCount < num ? num : _varCount;

                    index++;
                }
                catch (Exception)
                {
                    index++;
                }
            }

            var engine = new CalculationEngine();
            var formula = engine.Build(functionText);

            //кастим на нужную функцию
            _currFunction = doubles =>
            {
                var variables = new Dictionary<string, double>();
                for (var i = 0; i < doubles.Count; i++) variables.Add($"x{i + 1}", doubles[i]);

                return formula(variables);
            };

            _functionChosen = true;
            UpdateForm();
        }

        /// <summary>
        ///     Нажатие enter -> парсинг функции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void functionComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter) ParseFunction(functionComboBox.Text);
        }

        /// <summary>
        ///     Выбор функции
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void functionComboBox_TextChanged(object sender, EventArgs e)
        {
        }

        /// <summary>
        ///     Нажатие кнопки "TEST ALL"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            var exports = new List<TestExport>(_functions.Count * _methods.Count);
            foreach (var function in _functions)
            {
                ParseFunction(function);
                foreach (var method in _methods)
                {
                    _currMethod = method;
                    _currMethod.AlphaMethod = null;
                    Vector<double> start = new DenseVector(_varCount);
                    try
                    {
                        var text = startingPointTextBox.Text;
                        var textValues = text.Split(',');
                        for (var i = 0; i < _varCount; i++) start[i] = double.Parse(textValues[i]);
                    }
                    catch (Exception)
                    {
                        start.Clear();
                    }

                    var fh = new FunctionHolder(_currFunction, start);
                    _currMethod.Fh = fh;
                    if (_alphaMethodChosen)
                    {
                        _currAlphaMethod.F = fh.AlphaFunction;
                        _currAlphaMethod.Df = fh.AlphaDiffFunction;
                        _currMethod.AlphaMethod = _currAlphaMethod;
                    }

                    double eps;
                    try
                    {
                        eps = double.Parse(precisionTextBox.Text);
                    }
                    catch (Exception)
                    {
                        eps = 1e-5;
                        precisionTextBox.Text = @"1e-5";
                    }

                    _currMethod.Eps = eps;
                    //Делаем сам метод
                    var sw = Stopwatch.StartNew();
                    _currMethod.Execute();
                    sw.Stop();
                    //Вывод, Двуменрная функция
                    var coord = _currMethod.Answer;
                    var vectorString = coord.ToVectorString().Replace("\r\n"," ");
                    exports.Add(new TestExport(method.Name, function,
                        vectorString,
                        method.IterationCount.ToString(), sw.ElapsedMilliseconds.ToString(), eps.ToString()));
                }
            }

            var testForm = new TestForm(exports);
            _materialSkinManager.AddFormToManage(testForm);
            testForm.ShowDialog();
        }

        #endregion
    }
}