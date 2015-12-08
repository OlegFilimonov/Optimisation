using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jace;
using Jace.Execution;

namespace Optimisation.Оформление
{

    partial class MainForm
    {
        private int _varCount;
        private Delegate function;

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
                        function = (Func<double, double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    case 2:
                        function = (Func<double, double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Parameter("x2", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    case 3:
                        function = (Func<double, double,double, double>)engine.Formula(formulaString)
                    .Parameter("x1", DataType.FloatingPoint)
                    .Parameter("x2", DataType.FloatingPoint)
                    .Parameter("x3", DataType.FloatingPoint)
                    .Result(DataType.FloatingPoint)
                    .Build();
                        break;
                    case 4:
                        function = (Func<double, double,double,double, double>)engine.Formula(formulaString)
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
        }
    }
}
