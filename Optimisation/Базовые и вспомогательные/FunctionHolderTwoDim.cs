using System.Drawing;

namespace Optimisation.Базовые_и_вспомогательные
{
    public class FunctionHolderTwoDim : FunctionHolder
    {
        private readonly Function2D _dfx1;
        private readonly Function2D _dfx2;

        public PointF Dir;

        public PointF Min;

        public PointF Start;

        public FunctionHolderTwoDim(PointF start, PointF min, PointF dir, Function2D f2D, Function2D dfx1,
            Function2D dfx2,
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

        public FunctionHolderTwoDim(PointF start, PointF min, Function2D f2D, Function2D dfx1, Function2D dfx2,
            string name)
        {
            Start = start;
            Min = min;
            F2D = f2D;
            _dfx1 = dfx1;
            _dfx2 = dfx2;
            F = Af;
            Df = Adf;
            Name = name;
            Dir = AntiGrad();
        }

        public Function2D F2D { get; }

        public void invDir()
        {
            Dir.X = -Dir.X;
            Dir.Y = -Dir.Y;
        }

        //Альфа функиця
        private double Af(double alpha)
        {
            var offset = GetOffset(alpha);
            return F2D(offset.X, offset.Y);
        }

        //Альфа производная
        private double Adf(double alpha)
        {
            var offset = GetOffset(alpha);
            return Dir.X*_dfx1(offset.X, offset.Y) + Dir.Y*_dfx2(offset.X, offset.Y);
        }

        //Возвращает точку смещенную на альфа
        public PointF GetOffset(double alpha)
        {
            return new PointF(
                Start.X + (float) (Dir.X*alpha),
                Start.Y + (float) (Dir.Y*alpha)
                );
        }

        //Анти-градиент
        public PointF AntiGrad()
        {
            var x = Start;
            return new PointF((float) -_dfx1(x.X, x.Y), (float) -_dfx2(x.X, x.Y));
        }
    }
}