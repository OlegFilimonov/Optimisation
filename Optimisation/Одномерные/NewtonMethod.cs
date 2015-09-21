namespace Optimisation.Одномерные
{
    public class NewtonMethod:OneDimentionalOptimisationMethod
    {
        public NewtonMethod(function f, function df, double eps, string methodName, int maxIterations = 50) : base(f, df, eps, methodName, maxIterations)
        {
        }

        public override void execute()
        {
            throw new System.NotImplementedException();
        }
    }
}