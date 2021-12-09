namespace Zaabee.Jil;

public static partial class JilSerializer
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
    public static async Task<TValue?> FromStreamAsync<TValue>(Stream stream, Encoding encoding,
        Options? options = null, CancellationToken cancellationToken = default)
    {
        var result = FromJson<TValue>(encoding.GetString(await stream.ReadToEndAsync(cancellationToken)), options);
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
    public static async Task<object?> FromStreamAsync(Type type, Stream stream, Encoding encoding,
        Options? options = null, CancellationToken cancellationToken = default)
    {
        var result = FromJson(type, encoding.GetString(await stream.ReadToEndAsync(cancellationToken)), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}