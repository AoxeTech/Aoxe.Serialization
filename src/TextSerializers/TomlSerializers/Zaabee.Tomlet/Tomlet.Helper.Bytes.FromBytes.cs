namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(
        byte[]? bytes,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) where TValue : class, new() =>
        bytes is null || bytes.Length is 0
            ? default
            : FromToml<TValue>(bytes.GetString(encoding ?? Defaults.Utf8Encoding), tomlSerializerOptions);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromBytes(
        Type type,
        byte[]? bytes,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromToml(type, bytes.GetString(encoding ?? Defaults.Utf8Encoding), tomlSerializerOptions);
}