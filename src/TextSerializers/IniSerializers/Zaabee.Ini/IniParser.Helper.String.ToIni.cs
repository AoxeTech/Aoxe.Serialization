namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Serialize to ini.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToIni<TValue>(TValue? value, Encoding? encoding = null) =>
        (encoding ?? Defaults.Utf8Encoding).GetString(ToBytes(value));

    /// <summary>
    /// Serialize to ini.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string ToIni(object? value, Encoding? encoding = null) =>
        (encoding ?? Defaults.Utf8Encoding).GetString(ToBytes(value));

    /// <summary>
    /// Serialize to ini.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string ToIni(Type type, object? value, Encoding? encoding = null) =>
        (encoding ?? Defaults.Utf8Encoding).GetString(ToBytes(type, value));
}