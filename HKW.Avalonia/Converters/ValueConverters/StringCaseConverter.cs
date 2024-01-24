using System;
using System.Globalization;

namespace HKW.HKWAvalonia.Converters;

/// <summary>
/// Changes capitalization of a string.
/// </summary>
/// <example>
/// Convert a string to lower case:
/// Text="{Binding Text, Converter={StaticResource StringCaseConverter}, ConverterParameter=L}}"
///
/// Convert a string to upper case:
/// Text="{Binding Text, Converter={StaticResource StringCaseConverter}, ConverterParameter=U}}"
///
/// Convert a string to title case:
/// Text="{Binding Text, Converter={StaticResource StringCaseConverter}, ConverterParameter=T}}"
/// </example>
public class StringCaseConverter : ValueConverterBase<StringCaseConverter>
{
    public override object? Convert(
        object? value,
        Type targetType,
        object? parameter,
        CultureInfo culture
    )
    {
        if (value is string stringValue)
        {
            var stringParameter = $"{parameter}";

            return stringParameter switch
            {
                "U" or "u" => culture.TextInfo.ToUpper(stringValue),
                "L" or "l" => culture.TextInfo.ToLower(stringValue),
                "T" or "t" => culture.TextInfo.ToTitleCase(stringValue),
                _
                    => throw new ArgumentException(
                        $"Parameter '{stringParameter}' is not valid",
                        nameof(parameter)
                    ),
            };
        }

        return UnsetValue;
    }
}
