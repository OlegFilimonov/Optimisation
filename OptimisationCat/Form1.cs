using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Jace;
using MaterialSkin;
using MaterialSkin.Controls;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Многомерные;
using Optimisation.Одномерные;
using Optimisation.Одномерные_цепочки;

namespace OptimisationCat
{
    public partial class Form1 : MaterialForm
    {
        private readonly MaterialSkinManager _materialSkinManager;
        private bool _alphaMethodChosen;
        private int _varCount;

        private readonly List<OneDimMethod> _alphaMethods = new List<OneDimMethod>();
        private OneDimMethod _currAlphaMethod;

        private Func<Vector<double>, double> _currFunction;
        private MultiDimMethod _currMethod;

        private bool _functionChosen;
        private readonly List<string> _functions = new List<string>();
        private bool _methodChosen;
        private readonly List<MultiDimMethod> _methods = new List<MultiDimMethod>();

        public Form1()
        {
            InitializeComponent();
            PopulateFunctions();
            PopulateMethods();
            PopulateAlphaMethods();
            _materialSkinManager = MaterialSkinManager.Instance;
            _materialSkinManager.AddFormToManage(this);
            _materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo800, Primary.Indigo900, Primary.Indigo500,
                Accent.LightBlue200, TextShade.WHITE);
        }

        private void updateForm()
        {
            showGraphButton.Enabled = _functionChosen;
            calculateButton.Enabled = _functionChosen && _methodChosen;
            testAllButton.Enabled = _functionChosen;
        }

        #region populating combo boxes

        private void PopulateAlphaMethods()
        {
            //заполняем наш список
            _alphaMethods.Add(new GoldenRatioMethod1(null));
            _alphaMethods.Add(new GoldenRatioMethod2(null));
            _alphaMethods.Add(new DichotomyMethod(null));
            _alphaMethods.Add(new FibonacciMethod1(null));
            _alphaMethods.Add(new FibonacciMethod2(null));
            _alphaMethods.Add(new BolzanoMethod(null, null));
            _alphaMethods.Add(new ExtrapolationMethod(null));
            _alphaMethods.Add(new PaulMethod(null, null));
            _alphaMethods.Add(new DskMethod(null));
            _alphaMethods.Add(new DavidonMethod(null, null));
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

            foreach (var alphaMethod in _alphaMethods)
            {
                alphaMethodComboBox.Items.Add(alphaMethod.Name);
            }
        }

        private void PopulateMethods()
        {
            _methods.Add(new Partan1Method());
            _methods.Add(new KvasiNewton());
            _methods.Add(new GradMethod());
            _methods.Add(new GenericNewton());

            foreach (var method in _methods)
            {
                methodComboBox.Items.Add(method.Name);
            }
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

            functionComboBox.Items.AddRange(_functions.ToArray());
        }

        #endregion

        #region Events

        private void Form1_Load(object sender, EventArgs e)
        {
            materialCheckBox1_CheckedChanged(null, null);
            updateForm();
        }

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
        /// TEST ALL BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void testAllButton_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// SHOW GRAPH BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showGraphButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// CALCULATE BUTTON CLICK
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e)
        {
            Vector<double> start = new DenseVector(_varCount);
            try
            {
                var text = startingPointTextBox.Text;
                var textValues = text.Split(',');
                for (var i = 0; i < _varCount; i++)
                {
                    start[i] = double.Parse(textValues[i]);
                }
            }
            catch (Exception)
            {
                start.Clear();
            }
            var fh = new FunctionHolderMultiDim(_currFunction,start);
            _currMethod.FH = fh;
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
            _currMethod.Execute();

            //Вывод, Двуменрная функция
            var coord = _currMethod.Answer;
            answerTextBox.Text = "Answer:\r\n"+coord.ToString();
            iterationTextBox.Text = Convert.ToString("Iterations: "+_currMethod.IterationCount);
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
            updateForm();
        }

        /// <summary>
        ///     Выбираем функцию и парсим ее
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void functionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var functionText = functionComboBox.Text;
            if (functionText.Contains(':'))
                functionText = functionText.Remove(0, functionText.IndexOf(':') + 1);
            try
            {
                ParseFunction(functionText);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                updateForm();
            }
        }

        /// <summary>
        ///     Парсим функцию
        /// </summary>
        /// <param name="functionText"></param>
        private void ParseFunction(string functionText)
        {
            var engine = new CalculationEngine();
            var formula = engine.Build(functionText);

            //кастим на нужную функцию
            _currFunction = doubles =>
            {
                var variables = new Dictionary<string, double>();
                for (var i = 0; i < doubles.Count; i++)
                {
                    variables.Add($"x{i+1}", doubles[i]);
                }
                return formula(variables);
            };
            
            _functionChosen = true;
            updateForm();
        }

        #endregion

        private void functionComboBox_TextChanged(object sender, EventArgs e)
        {
            var index = 0;
            var str = functionComboBox.Text;
            _varCount = 0;

            while (index != -1)
            {
                index = str.IndexOf("x", index, StringComparison.Ordinal);
                if (index == -1) break;
                try
                {
                    int num;
                    if (int.TryParse(str.Substring(index + 1, 1), out num))
                    {
                        _varCount = (_varCount < num) ? num : _varCount;
                    }
                    index++;
                }
                catch (Exception)
                {
                    index++;
                }
            }
        }
    }
}