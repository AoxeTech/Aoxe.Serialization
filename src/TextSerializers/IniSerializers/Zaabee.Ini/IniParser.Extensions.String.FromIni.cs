namespace Zaabee.Ini;

public static partial class IniParserExtensions
{
    public static TValue? FromIni<TValue>(this string? ini, Encoding? encoding = null) =>
        IniParserHelper.FromIni<TValue>(ini, encoding);

    public static object? FromIni(this string? ini, Type type, Encoding? encoding = null) =>
        IniParserHelper.FromIni(type, ini, encoding);
}