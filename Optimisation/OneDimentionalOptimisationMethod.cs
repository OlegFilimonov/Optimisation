using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Optimisation
{
    public abstract class OneDimentionalOptimisationMethod
    {
        private List<double> startingPoints = new List<double>(2);

        public delegate double function(double x);

        private List<double> sven(function f)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            double a, b;
            
            List<double> ans = new List<double>(2);
            //ans.Add(a);
            //ans.Add(b);
            return ans;
        }

        protected OneDimentionalOptimisationMethod(function f)
        {
            startingPoints = sven(f);
        }
    }
}
