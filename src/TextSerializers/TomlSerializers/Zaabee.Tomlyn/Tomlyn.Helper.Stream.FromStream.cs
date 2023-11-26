namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(
        Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    )
        where TValue : class, new()
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = FromToml<TValue>(
            stream.ReadToEnd().GetString(encoding ?? Defaults.Utf8Encoding),
            sourcePath,
            tomlModelOptions
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static TomlTable? FromStream(
        Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = FromToml(
            stream.ReadToEnd().GetString(encoding ?? Defaults.Utf8Encoding),
            sourcePath,
            tomlModelOptions
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
