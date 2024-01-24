using Avalonia.Data.Converters;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public abstract class ValueConverterBase<TConverter> : ConverterBase, IValueConverter
    where TConverter : ValueConverterBase<TConverter>, new()
{
    private static readonly Lazy<TConverter> InstanceConstructor =
        new(() => new TConverter(), LazyThreadSafetyMode.PublicationOnly);

    public static TConverter Instance => InstanceConstructor.Value;

    public abstract object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    );

    public virtual object? ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        throw new NotSupportedException(
            $"Converter '{GetType().Name}' does not support backward conversion."
        );
    }

    object? IValueConverter.Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return Convert(value, targetType, parameter, SelectCulture(() => culture));
    }

    object? IValueConverter.ConvertBack(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        return ConvertBack(value, targetType, parameter, SelectCulture(() => culture));
    }
}
