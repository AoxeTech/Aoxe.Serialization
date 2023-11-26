namespace Zaabee.Tomlet;

public static partial class TomletHelper
{
    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var toml = (await stream.ReadToEndAsync(cancellationToken)).GetString(
            encoding ?? Defaults.Utf8Encoding
        );
        var result = FromToml<TValue>(toml, tomlSerializerOptions);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="tomlSerializerOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        TomlSerializerOptions? tomlSerializerOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var toml = (await stream.ReadToEndAsync(cancellationToken)).GetString(
            encoding ?? Defaults.Utf8Encoding
        );
        var result = FromToml(type, toml, tomlSerializerOptions);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
