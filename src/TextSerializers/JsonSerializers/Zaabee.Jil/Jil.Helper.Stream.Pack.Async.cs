namespace Zaabee.Jil;

public static partial class JilHelper
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
    public static async ValueTask PackAsync<TValue>(TValue? value, Stream? stream = null, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is null) return;
        await ToBytes(value, options, encoding).WriteToAsync(stream, cancellationToken);
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
    public static async ValueTask PackAsync(object? value, Stream? stream = null, Options? options = null,
        Encoding? encoding = null, CancellationToken cancellationToken = default)
    {
        if (stream is null) return;
        await ToBytes(value, options, encoding).WriteToAsync(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}