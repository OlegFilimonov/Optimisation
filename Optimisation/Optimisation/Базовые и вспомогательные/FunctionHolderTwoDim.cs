using System.Drawing;

namespace Optimisation.Базовые_и_вспомогательные
{
    public class FunctionHolderTwoDim : FunctionHolder
    {
        private readonly Function2D _dfx1;
        private readonly Function2D _dfx2;
        //Двумерная функция

        public FunctionHolderTwoDim(PointF start, PointF min, PointF dir, Function2D f2D, Function2D dfx1, Function2D dfx2,
            string name)
        {
            Start = start;
            Min = min;
            Dir = dir;
            F2D = f2D;
            _dfx1 = dfx1;
            _dfx2 = dfx2;
            F = Af;
            Df = Adf;
            Name = name;
        }

        public PointF Start { get; set; }

        public PointF Min { get; private set; }

        private PointF Dir { get; }

        private Function2D F2D { get; }

        private double Af(double alpha)
        {
            var offset = GetOffset(alpha);
            return F2D(offset.X, offset.Y);
        }

        private double Adf(double alpha)
        {
            var offset = GetOffset(alpha);
            return Dir.X*_dfx1(offset.X, offset.Y) + Dir.Y*_dfx2(offset.X, offset.Y);
        }

        public PointF GetOffset(double alpha)
        {
            return new PointF(
                Start.X + (float) (Dir.X*alpha),
                Start.Y + (float) (Dir.Y*alpha)
                );
        }
    }
}