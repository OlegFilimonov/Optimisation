namespace Optimisation.Базовые_и_вспомогательные
{
    public abstract class FunctionHolder
    {
        public Function1D F { get; protected set; }

        public Function1D Df { get; protected set; }

        public Function1D D2F { get; protected set; }

        public string Name { get; protected set; }
    }
}