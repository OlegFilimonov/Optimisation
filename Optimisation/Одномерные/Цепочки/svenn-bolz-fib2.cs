using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimisation.Одномерные.Цепочки
{
    class svenn_bolz_fib2: OneDimentionalOptimisationMethod
    {
        public svenn_bolz_fib2(function f, function df, double eps, string methodName, int maxIterations = 50) : base(f, df, eps, methodName, maxIterations)
        {
        }

        public override void execute()
        {
            throw new NotImplementedException();
        }
    }
}
