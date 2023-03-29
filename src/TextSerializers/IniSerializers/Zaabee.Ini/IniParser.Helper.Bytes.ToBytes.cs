namespace Zaabee.Ini;

public static partial class IniParserHelper
{
    /// <summary>
    /// Serialize the object to ini bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value, Encoding? encoding = null) =>
        ToStream(value, encoding).ToArray();

    /// <summary>
    /// Serialize the object to ini bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(object? value, Encoding? encoding = null) =>
        ToStream(value, encoding).ToArray();

    /// <summary>
    /// Serialize the object to ini bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value, Encoding? encoding = null) =>
        ToStream(type, value, encoding).ToArray();
}