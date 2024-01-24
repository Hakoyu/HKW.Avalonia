using Avalonia.Data.Converters;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public abstract class MultiValueConverterBase<TConverter> : ConverterBase, IMultiValueConverter
    where TConverter : MultiValueConverterBase<TConverter>, new()
{
    private static readonly Lazy<TConverter> InstanceConstructor =
        new(() => new TConverter(), LazyThreadSafetyMode.PublicationOnly);

    public static TConverter Instance => InstanceConstructor.Value;

    public abstract object? Convert(
        IList<object?> value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    );

    object? IMultiValueConverter.Convert(
        IList<object?> value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return Convert(value, targetType, parameter, SelectCulture(() => culture));
    }
}
