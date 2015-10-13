using System;
using System.Collections.Generic;
using Optimisation.Базовые_и_вспомогательные;
using Optimisation.Одномерные_цепочки;

namespace Optimisation.Оформление
{
    public partial class MainForm
    {
        private readonly List<OneDimMethod> _oneDimentionalMethods2 = new List<OneDimMethod>();

        private void PopulateMethods2()
        {
            _oneDimentionalMethods2.Add(new SvennDihNewt());
            _oneDimentionalMethods2.Add(new SvennBolzGr1());
            _oneDimentionalMethods2.Add(new SvennBolzFib2());
            _oneDimentionalMethods2.Add(new Fib1Dsk());
            _oneDimentionalMethods2.Add(new Fib2Dsk());
            _oneDimentionalMethods2.Add(new DihPaul());
            _oneDimentionalMethods2.Add(new BolzPaul());
            _oneDimentionalMethods2.Add(new Gr1Extr());
            _oneDimentionalMethods2.Add(new DihDav());
            _oneDimentionalMethods2.Add(new ExtrDav());
            _oneDimentionalMethods2.Add(new Gr2Paul());

            //заполняем выпадающий список
            foreach (var method in _oneDimentionalMethods2)
            {
                methodList2.Items.Add(method.MethodName);
            }
        }

        private void Initilize2()
        {
            PopulateMethods2();
        }


        private void functionList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (functionList2.SelectedIndex == -1) return;
            graph.ResetRange();
            _currFunctionHolder = _testingFunctions[functionList2.SelectedIndex];
            MakeFunction(_currFunctionHolder);
        }

        private void methodList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (methodList2.SelectedIndex == -1) return;
            _currMethod = _oneDimentionalMethods2[methodList2.SelectedIndex];
            MakeMethod(_currMethod);
        }
    }
}