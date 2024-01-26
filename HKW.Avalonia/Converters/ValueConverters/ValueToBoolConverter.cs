using Avalonia;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 值到布尔转换器
/// </summary>
/// <typeparam name="T">值类型</typeparam>
public class ValueToBoolConverter<T>
    : ReversibleValueToBoolConverterBase<T, ValueToBoolConverter<T>>
{
    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> TrueValueProperty = AvaloniaProperty.Register<
        ValueToBoolConverter<T>,
        T
    >(nameof(TrueValue));

    /// <summary>
    /// 为真时的值
    /// </summary>
    public override T TrueValue
    {
        get => GetValue(TrueValueProperty);
        set => SetValue(TrueValueProperty, value);
    }

    /// <summary>
    ///
    /// </summary>
    public static readonly StyledProperty<T> FalseValueProperty = AvaloniaProperty.Register<
        ValueToBoolConverter<T>,
        T
    >(nameof(FalseValue));

    /// <summary>
    /// 为假时的值
    /// </summary>
    public override T FalseValue
    {
        get => GetValue(FalseValueProperty);
        set => SetValue(FalseValueProperty, value);
    }
}

/// <summary>
/// 值到布尔转换器
/// </summary>
public class ValueToBoolConverter : ValueToBoolConverter<object> { }
