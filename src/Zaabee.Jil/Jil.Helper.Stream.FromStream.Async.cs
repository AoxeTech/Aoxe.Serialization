namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is null || stream.CanSeek && stream.Length is 0) return default;
        var json = (await stream.ReadToEndAsync(cancellationToken)).GetString(encoding);
        var result = FromJson<TValue>(json, options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<object?> FromStreamAsync(Type type, Stream? stream, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is null || stream.CanSeek && stream.Length is 0) return default;
        var json = (await stream.ReadToEndAsync(cancellationToken)).GetString(encoding);
        var result = FromJson(type, json, options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}