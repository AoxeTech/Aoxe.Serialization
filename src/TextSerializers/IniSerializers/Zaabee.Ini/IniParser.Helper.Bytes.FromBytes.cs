namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Deserialize from bytes.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[]? bytes, Encoding? encoding = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromStream<TValue>(bytes.ToMemoryStream(), encoding);

    /// <summary>
    /// Deserialize from bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[]? bytes, Encoding? encoding = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromStream(type, bytes.ToMemoryStream(), encoding);
}