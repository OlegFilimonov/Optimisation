using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPlotLibrary;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные;
using Optimisation.Одномерные.Цепочки;
using Optimisation.Одномерные_цепочки;

namespace Optimisation
{
    public partial class MainForm
    {
        private List<OneDimMethod> oneDimentionalMethods2 = new List<OneDimMethod>();

        private void populateMethods2()
        {
            oneDimentionalMethods2.Add(new svenn_dih_newt());
            oneDimentionalMethods2.Add(new svenn_bolz_gr1());
            oneDimentionalMethods2.Add(new svenn_bolz_fib2());
            oneDimentionalMethods2.Add(new fib1_dsk());
            oneDimentionalMethods2.Add(new fib2_dsk());
            oneDimentionalMethods2.Add(new dih_paul());
            oneDimentionalMethods2.Add(new bolz_paul());
            oneDimentionalMethods2.Add(new gr1_extr());
            oneDimentionalMethods2.Add(new dih_dav());
            oneDimentionalMethods2.Add(new extr_dav());
            oneDimentionalMethods2.Add(new gr2_paul());
        }
    }
}
