namespace HKW.HKWAvalonia.Converters;

public abstract class AllEqualsValueConverterBase<T, TConverter> : MultiValueConverterBase<TConverter>
    where TConverter : MultiValueConverterBase<TConverter>, new() { }
