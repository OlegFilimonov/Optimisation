using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные
{
    class Function5
    {
        public string Function { get; }
        public string Start { get; }
        public int Num { get; }

        public Function5(string function, string start, int num)
        {
            Function = function;
            Start = start;
            Num = num;
        }
    }
}
