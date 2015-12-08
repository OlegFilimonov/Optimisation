// ReSharper disable InconsistentNaming
namespace Optimisation.Базовые_и_вспомогательные
{
    /// <summary>
    ///     Класс, хранящий функции для тестирования
    /// </summary>
    public class FunctionHolderOneDim : FunctionHolder
    {
        public FunctionHolderOneDim(Function1D f, Function1D df, string name, double min, Function1D d2f = null)
        {
            F = f;
            Df = df;
            Name = name;
            Min = min;
            D2F = d2f;
        }

        public double Min { get; }
    }
}