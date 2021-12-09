namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<MemoryStream> ToStreamAsync<TValue>(TValue? value, Encoding encoding, Options? options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, encoding, options, cancellationToken);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> ToStreamAsync(object? value, Encoding encoding, Options? options = null,
        CancellationToken cancellationToken = default)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, encoding, options, cancellationToken);
        return ms;
    }
}