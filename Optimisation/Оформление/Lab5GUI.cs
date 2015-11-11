using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jace;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Многомерные;

namespace Optimisation.Оформление
{

    partial class MainForm
    {
        private readonly List<MultiDimMethod> _multiDimMethods5 = new List<MultiDimMethod>();
        private int _varCount;
        private Delegate _currFunction5;
        private MultiDimMethod _currMethod5;

        private void Initilize5()
        {
            PopulateMethods5();
            epsBox5.Enabled = true;
            startingBox5.Enabled = true;
            methodList5.Enabled = true;
        }

        private void PopulateMethods5()
        {
            double eps;
            try
            {
                eps = double.Parse(epsBox5.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " +
                                exception.Message);

                eps = 1e-5;
                epsBox5.Text = "1e-5";
            }
            Vector<double> startVector = new DenseVector(_varCount);
            try
            {
                string text = startingBox5.Text;
                string[] textValues = text.Split(',');
                for (int i = 0; i < _varCount; i++)
                {
                    startVector[i] = double.Parse(textValues[i]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " +
                                exception.Message);
                startVector.Clear();
            }

            _multiDimMethods5.Add(new Partan1Method(eps,_currFunction5,startVector));

            foreach (var method in _multiDimMethods5)
            {
                methodList5.Items.Add(method.Name);
            }
        }

        private void methodList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList5.SelectedIndex == -1) return;
            _currMethod5 = _multiDimMethods5[methodList5.SelectedIndex];
            MakeMethod5(_currMethod5);
        }

        private void MakeMethod5(MultiDimMethod method)
        {
            method.FH.F = _currFunction5;

            double eps;
            try
            {
                eps = double.Parse(epsBox5.Text);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " +
                                exception.Message);

                eps = 1e-5;
                epsBox5.Text = "1e-5";
            }
            Vector<double> startVector = new DenseVector(_varCount);
            try
            {
                string text = startingBox5.Text;
                string[] textValues = text.Split(',');
                for (int i = 0; i < _varCount; i++)
                {
                    startVector[i] = double.Parse(textValues[i]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Неверно введены начальные данные для метода, выбраны стандартные\nОшибка: " +
                                exception.Message);
                startVector.Clear();
            }
            method.FH.Point = startVector;

            //Точность
            method.Eps = eps;

            //Делаем свена
            method.SetSven4Interval();

            //Делаем сам метод
            method.Execute();

            //Вывод, Двуменрная функция
            var coord = method.Answer;
            answerBox5.Text = coord.ToString();
            iterBox5.Text = Convert.ToString(method.IterationCount);
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var engine = new CalculationEngine();
            var formulaString = formulaBox.Text;
            string report;
            try
            {
                switch (_varCount)
                {
                    case 1:
                        _currFunction5 = (Func<double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    case 2:
                        _currFunction5 = (Func<double, double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Parameter("x2", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    case 3:
                        _currFunction5 = (Func<double, double,double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Parameter("x2", DataType.FloatingPoint)
                    .Parameter("x3", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    case 4:
                        _currFunction5 = (Func<double, double,double,double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Parameter("x2", DataType.FloatingPoint)
                    .Parameter("x3", DataType.FloatingPoint)
                    .Parameter("x4", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    default:
                        throw new Exception("Переменных может быть от 1 до 4 включительно");
                }
                var vars = "f(";
                for (var k = _varCount; k > 0; k--)
                {
                    vars += (k==1)?$"x{k})":$"x{k},";
                }
                report = $"Введенная функция успешно парсирована:\n{vars}={formulaString}";
                if(_multiDimMethods5.Count == 0)
                Initilize5();
            }
            catch (Exception exp)
            {
                report = $"Ошибка парсинга. Проверьте введенное выражение.\nТекст ошибки: {exp.Message}";
            }
            MessageBox.Show(report);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var index = 0;
            var str = formulaBox.Text;
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
            label29.Text = $"Обнаруженно переменных: {_varCount}";

            var startingPointText = "";

            for (var i = 0; i < _varCount; i++)
            {
                startingPointText += "0,";
            }
            if(_varCount>0)
            startingPointText = startingPointText.Remove(startingPointText.Length - 1);

            startingBox5.Text = startingPointText;
        }
    }
}
