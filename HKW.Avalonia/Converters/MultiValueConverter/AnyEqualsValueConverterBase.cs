namespace HKW.HKWAvalonia.Converters;

public abstract class AnyEqualsValueConverterBase<T, TConverter>
    : MultiValueConverterBase<TConverter>
    where TConverter : MultiValueConverterBase<TConverter>, new() { }
