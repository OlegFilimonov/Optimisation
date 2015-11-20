using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using MathNet.Numerics.LinearAlgebra.Storage;
using Optimisation.Многомерные;

namespace Optimisation.Оформление
{
    partial class MainForm
    {

        private void executeButton_Click(object sender, EventArgs e)
        {
            GenericNewton method;
            Vector<double> start;

            if (func19RadioButton.Checked)
            {
                start = new DenseVector(2);
                start[0] = -2;
                start[1] = -2;
                method = new GenericNewton(start, 19);
            }
            else
            {
                start = new DenseVector(3);
                start[0] = 4;
                start[1] = -1;
                start[2] = 2;
                method = new GenericNewton(start,20);
            }
            
            method.Execute();

            //Вывод, Двуменрная функция
            var coord = method.Answer;
            answerBox6.Text = coord.ToString();
            iterBox6.Text = Convert.ToString(method.IterationCount);
        }
    }
}
