namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task PackAsync<TValue>(TValue? value, Stream stream, Encoding encoding, Options? options = null,
        CancellationToken cancellationToken = default)
    {
        await ToBytes(value, encoding, options).WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task PackAsync(object? value, Stream stream, Encoding encoding, Options? options = null,
        CancellationToken cancellationToken = default)
    {
        await ToBytes(value, encoding, options).WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}