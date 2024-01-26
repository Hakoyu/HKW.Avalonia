namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 全部相等于值转换器基类
/// </summary>
/// <typeparam name="T">值类型</typeparam>
/// <typeparam name="TConverter">转换器类型</typeparam>
public abstract class AllEqualsValueConverterBase<T, TConverter>
    : MultiValueConverterBase<TConverter>
    where TConverter : MultiValueConverterBase<TConverter>, new() { }
