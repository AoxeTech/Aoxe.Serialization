namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(
        byte[]? bytes,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) where TValue : class, new() =>
        bytes is null || bytes.Length is 0
            ? default
            : FromToml<TValue>(bytes.GetString(encoding ?? Defaults.Utf8Encoding), sourcePath, tomlModelOptions);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static TomlTable? FromBytes(
        byte[]? bytes,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromToml(bytes.GetString(encoding ?? Defaults.Utf8Encoding), sourcePath, tomlModelOptions);
}