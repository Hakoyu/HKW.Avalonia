using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

public abstract class ConverterBase : AvaloniaObject
{
    public static readonly object UnsetValue = AvaloniaProperty.UnsetValue;

    /// <summary>
    /// Allows to override the default culture used in <seealso cref="IValueConverter"/> for the current converter.
    /// The default override behavior can be configured in <seealso cref="ValueConvertersConfig.DefaultPreferredCulture"/>.
    /// </summary>
    public PreferredCulture PreferredCulture { get; set; } =
        ValueConvertersConfig.DefaultPreferredCulture;

    protected CultureInfo SelectCulture(Func<CultureInfo> converterCulture)
    {
        return PreferredCulture switch
        {
            PreferredCulture.CurrentCulture => CultureInfo.CurrentCulture,
            PreferredCulture.CurrentUICulture => CultureInfo.CurrentUICulture,
            _ => converterCulture(),
        };
    }
}
