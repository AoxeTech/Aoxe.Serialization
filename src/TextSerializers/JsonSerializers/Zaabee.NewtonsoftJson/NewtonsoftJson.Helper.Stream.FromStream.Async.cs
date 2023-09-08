namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : (TValue?)await FromStreamAsync(typeof(TValue), stream, settings, encoding ?? Defaults.Utf8Encoding,
                cancellationToken);

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null,
        CancellationToken cancellationToken = default)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var bytes = await stream.ReadToEndAsync(cancellationToken);
        var result = FromJson(type, bytes.GetString(encoding ?? Defaults.Utf8Encoding), settings);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}