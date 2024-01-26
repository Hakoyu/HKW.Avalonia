namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// 全部为真转换器
/// </summary>
public class AllIsTrueConverter : AllEqualsValueConverter<bool>
{
    /// <inheritdoc/>
    public AllIsTrueConverter()
    {
        Value = true;
    }
}
