namespace Optimisation.Одномерные.Цепочки
{
    public class svenn_bolz_gr1: OneDimentionalOptimisationMethod
    {
        public svenn_bolz_gr1(function f, function df, double eps, string methodName, int maxIterations = 50) : base(f, df, eps, methodName, maxIterations)
        {
        }

        public override void execute()
        {
            throw new System.NotImplementedException();
        }
    }
}