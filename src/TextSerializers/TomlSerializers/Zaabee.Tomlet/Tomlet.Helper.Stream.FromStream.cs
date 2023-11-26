namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = FromToml<TValue>(
            stream.ReadToEnd().GetString(encoding ?? Defaults.Utf8Encoding),
            tomlSerializerOptions
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromStream(
        Type type,
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = FromToml(
            type,
            stream.ReadToEnd().GetString(encoding ?? Defaults.Utf8Encoding),
            tomlSerializerOptions
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
