namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<MemoryStream> PackAsync<T>(T? t, Options? options, Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(t, ms, options, encoding, cancellationToken);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task PackAsync<T>(T? t, Stream stream, Options? options, Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        await Serialize(t, options, encoding).WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> PackAsync(object? obj, Options? options, Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(obj, ms, options, encoding, cancellationToken);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task PackAsync(object? obj, Stream stream, Options? options, Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        await Serialize(obj, options, encoding).WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static async Task<T> UnpackAsync<T>(Stream stream, Options? options, Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        var result = Deserialize<T>(encoding.GetString(await stream.ReadToEndAsync(cancellationToken)), options);
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
    public static async Task<object> UnpackAsync(Type type, Stream stream, Options? options, Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync(cancellationToken)), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}