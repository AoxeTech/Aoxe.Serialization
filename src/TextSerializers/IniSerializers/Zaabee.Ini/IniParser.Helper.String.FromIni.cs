namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Deserialize from ini.
    /// </summary>
    /// <param name="ini"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromIni<TValue>(string? ini, Encoding? encoding = null) =>
        ini.IsNullOrWhiteSpace()
            ? default
            : FromBytes<TValue>((encoding ?? DefaultEncoding).GetBytes(ini!));

    /// <summary>
    /// Deserialize from ini.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="ini"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromIni(Type type, string? ini, Encoding? encoding = null) =>
        ini.IsNullOrWhiteSpace()
            ? default
            : FromBytes(type, (encoding ?? DefaultEncoding).GetBytes(ini!));
}