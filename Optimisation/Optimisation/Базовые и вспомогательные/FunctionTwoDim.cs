using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Optimisation.Одномерные;

namespace Optimisation.Базовые_и_вспомогательные
{
    public class FunctionTwoDim : Function
    {
        private PointF start;
        private PointF min;
        private PointF dir;
        //Двумерная функция
        private function2D f2d;
        private function2D dfx1;
        private function2D dfx2;

        public FunctionTwoDim(PointF start, PointF min, PointF dir, function2D f2D, function2D dfx1, function2D dfx2,string name)
        {
            this.start = start;
            this.min = min;
            this.dir = dir;
            f2d = f2D;
            this.dfx1 = dfx1;
            this.dfx2 = dfx2;
            f = af;
            df = adf;
            this.name = name;
        }

        private double af(double alpha)
        {
            var offset = getOffset(alpha);
            return f2d(offset.X, offset.Y);
        }

        private double adf(double alpha)
        {
            var offset = getOffset(alpha);
            return dir.X*dfx1(offset.X,offset.Y) + dir.Y*dfx2(offset.X,offset.Y);
        }

        public PointF getOffset(double alpha)
        {
            return new PointF(
                start.X + (float)(dir.X * alpha),
                start.Y + (float)(dir.Y * alpha)
                );
        }

        public PointF Start
        {
            get { return start; }
            set { start = value; }
        }

        public PointF Min
        {
            get { return min; }
            set { min = value; }
        }

        public PointF Dir
        {
            get { return dir; }
            set { dir = value; }
        }

        public function2D F2D
        {
            get { return f2d; }
        }
    }

}
