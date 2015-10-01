using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Optimisation.Одномерные;

namespace Optimisation.Базовые_и_вспомогательные
{
    public abstract class Function
    {
        protected function f;
        protected function df;
        protected function d2f;
        protected string name;

        public function F
        {
            get { return f; }
            set { f = value; }
        }

        public function Df
        {
            get { return df; }
            set { df = value; }
        }

        public function D2F
        {
            get { return d2f; }
            set { d2f = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
