using Avalonia;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 任意相等于第一个转换器
/// </summary>
public class AnyEqualsFirstMultiConverter
    : AnyEqualsFirstConverter<object, AnyEqualsFirstMultiConverter> { }

/// <summary>
/// 任意相等于第一个转换器
/// </summary>
/// <typeparam name="T">值类型</typeparam>
/// <typeparam name="TConverter">转换器类型</typeparam>
public abstract class AnyEqualsFirstConverter<T, TConverter>
    : InvertibleMultiValueConverterBase<TConverter>
    where TConverter : AnyEqualsFirstConverter<T, TConverter>, new()
{
    /// <inheritdoc/>
    public override object? Convert(
        IList<object?> values,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (values.Count <= 1)
            return false;
        var first = values[0];
        if (first == UnsetValue)
            return false;
        if (IsInverted)
            return values.Skip(1).Any(o => o?.Equals(first) is not true);
        else
            return values.Skip(1).Any(o => o?.Equals(first) is true);
    }
}
