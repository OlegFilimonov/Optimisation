using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;

namespace CORE.Многомерные
{
    public class HookeJeevesPs : OptimisationMethod
    {
        private readonly double _rho;

        public HookeJeevesPs(double rho = 0.5): base("Хук-Дживс [Pattern Search]", 1e-5, null, null)
        {
            _rho = rho;
        }

        public override void Execute()
        {
            var nvars = Fh.Point.Count;
            var x0 = Fh.Point; //Стартовая точка
            IterationCount = 0;
            var delta = new DenseVector(nvars);
            for (var i = 0; i < nvars; i++)
            {
                delta[i] = _rho;
            }
            DenseVector originalDelta = delta;

            while (delta.AbsoluteMinimum() > Eps && IterationCount < MaxIterations)
            {
                Vector<double> x1 = ExplanotorySearch(x0, delta);

                if (Fh.Y(x1) < Fh.Y(x0))
                { //x1 лучше чем x0
                    delta = originalDelta;
                    while (true)
                    {
                        Vector<double> x2 = x0  + 2* (x1 - x0);
                        x2 = ExplanotorySearch(x2, delta);

                        if (Fh.Y(x2) < Fh.Y(x1))
                        {
                            //х2 лучше чем х1
                            x0 = x1;
                            x1 = x2;
                        }
                        else
                        {
                            //x2 хуже чем х1
                            x0 = x1;
                            break;
                        }
                    }
                }
                else
                { // x1 хуже чем х0
                    delta /= 2;
                }
                IterationCount++;
            }
            Answer = x0;
        }

        /// <summary>
        /// Передаются ссылки, point и delta будут изменены 
        /// </summary>
        /// <param name="delta"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private Vector<double> ExplanotorySearch( Vector<double> point, Vector<double> delta)
        {
            var nvars = delta.Count;
            var prevbest = Fh.Y(point);
            var z = new DenseVector(nvars);

            point.CopyTo(z);

            int i;
            var minf = prevbest;

            for (i = 0; i < nvars; i++)
            {
                z[i] = point[i] + delta[i];
                var ftmp = Fh.Y(z);
                if (ftmp < minf)
                    minf = ftmp;
                else
                {
                    z[i] = point[i]  -delta[i];
                    ftmp = Fh.Y(z);
                    if (ftmp < minf)
                        minf = ftmp;
                    else
                    {
                        z[i] = point[i];
                    }
                }
            }

            return z;
        }
    }
}
