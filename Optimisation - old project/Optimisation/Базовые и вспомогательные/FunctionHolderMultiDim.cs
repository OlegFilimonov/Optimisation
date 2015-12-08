using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.LinearAlgebra;

namespace Optimisation.Базовые_и_вспомогательные
{
    public class FunctionHolderMultiDim
    {
        //Функция
        public Delegate F { get; set; }

        //Рекомендуемая начальная точка
        public Vector<double> Start { get; set; } 

        /// <summary>
        /// Функиця принимающая вектор и возвращающая число
        /// </summary>
        /// <param name="X">вектор</param>
        /// <returns></returns>
        public double Y(Vector<double> X)
        {
            throw new NotImplementedException();
        }
    }
}
