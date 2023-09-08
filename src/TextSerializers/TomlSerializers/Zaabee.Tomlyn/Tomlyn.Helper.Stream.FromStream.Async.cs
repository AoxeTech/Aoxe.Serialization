namespace Zaabee.Tomlyn;

public static partial class TomlynHelper
{
    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <param name="sourcePath"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
        where TValue : class, new()
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var toml = (await stream.ReadToEndAsync(cancellationToken)).GetString(encoding ?? Defaults.Utf8Encoding);
        var result = FromToml<TValue>(toml, sourcePath, tomlModelOptions);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="sourcePath"></param>
    /// <param name="tomlModelOptions"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask<TomlTable?> FromStreamAsync(
        Stream? stream,
        string? sourcePath = null,
        TomlModelOptions? tomlModelOptions = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var toml = (await stream.ReadToEndAsync(cancellationToken)).GetString(encoding ?? Defaults.Utf8Encoding);
        var result = FromToml(toml, sourcePath, tomlModelOptions);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}