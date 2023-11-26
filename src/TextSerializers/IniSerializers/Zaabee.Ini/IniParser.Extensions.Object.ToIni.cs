namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static string ToIni<TValue>(this TValue? value, Encoding? encoding = null) =>
        IniParserHelper.ToIni(value, encoding);

    public static string ToIni(this object? value, Encoding? encoding = null) =>
        IniParserHelper.ToIni(value, encoding);

    public static string ToIni(this object? value, Type type, Encoding? encoding = null) =>
        IniParserHelper.ToIni(type, value, encoding);
}
