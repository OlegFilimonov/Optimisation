﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Jace;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Многомерные;
using Optimisation.Одномерные;

namespace Optimisation.Оформление
{
    partial class MainForm
    {
        private readonly List<MultiDimMethod> _multiDimMethods5 = new List<MultiDimMethod>();
        private Delegate _currFunction5;
        private MultiDimMethod _currMethod5;
        private readonly List<Function5> _functionList5 = new List<Function5>();
        private int _varCount;

        private void Initilize5()
        {
            PopulateMethods5();
            PopulateFunctions5();
            epsBox5.Enabled = true;
            startingBox5.Enabled = true;
            methodList5.Enabled = true;
        }

        private void PopulateFunctions5()
        {
            if (_functionList5.Count == 0)
            {
                _functionList5.Add(new Function5("(x1-1)^2+(x2-3)^2+4*(x3+5)^2", "4,-1,2", 20));
                _functionList5.Add(new Function5("8*x1^2+4*x1*x2+5*x2^2", "10,10", 21));
                _functionList5.Add(new Function5("4*(x1-5)^2+(x2-6)^2", "8,9", 22));
                _functionList5.Add(new Function5("-12*x2+4*x1^2+4*x2^2-4*x1*x2", "1,0", 27));
                _functionList5.Add(new Function5("100*(x2-x1^3)^2+(1-x1)^2", "-1.2,1", 32));

                foreach (var function5 in _functionList5)
                {
                    formulaBox.Items.Add($"{function5.Function}");
                }
            }
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
                var text = startingBox5.Text;
                var textValues = text.Split(',');
                for (var i = 0; i < _varCount; i++)
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

            _multiDimMethods5.Add(new Partan1Method(eps, _currFunction5, startVector));
            _multiDimMethods5.Add(new KvasiNewton(eps, _currFunction5, startVector));
            _multiDimMethods5.Add(new GradMethod(eps, _currFunction5, startVector));

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
                var text = startingBox5.Text;
                var textValues = text.Split(',');
                for (var i = 0; i < _varCount; i++)
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
            //method.SetSven4Interval();

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
                //Func<Dictionary<string,double>,double> formula = enh
                //for(int i=0;i<_varCount,i++)
                //{

                //}


                var vars = "f(";
                for (var k = 0; k < _varCount; k++)
                {
                    vars += (k == 1) ? $"x{k})" : $"x{k},";
                }
                report = $"Введенная функция успешно парсирована:\n{vars}={formulaString}";
                if (_multiDimMethods5.Count == 0)
                    Initilize5();
            }
            catch (Exception exp)
            {
                report = $"Ошибка парсинга. Проверьте введенное выражение.\nТекст ошибки: {exp.Message}";
                MessageBox.Show(report);
            }
        }

        private void formulaBox_TextChanged(object sender, EventArgs e)
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
        }

        private void formulaBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            startingBox5.Text = _functionList5[formulaBox.SelectedIndex].Start;
            button1_Click(null, null);
        }
    }
}