namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<MemoryStream> PackAsync<TValue>(TValue value, Encoding encoding,
        JsonSerializerSettings? settings)
    {
        var ms = new MemoryStream();
        await PackAsync(value, ms, encoding, settings);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task<MemoryStream> PackAsync(Type type, object? value, Encoding encoding,
        JsonSerializerSettings? settings)
    {
        var ms = new MemoryStream();
        await PackAsync(type, value, ms, encoding, settings);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task PackAsync<TValue>(TValue value, Stream stream, Encoding encoding,
        JsonSerializerSettings? settings)
    {
        await Serialize(value, encoding, settings).WriteToAsync(stream, CancellationToken.None);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write asynchronously to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task PackAsync(Type type, object? value, Stream stream, Encoding encoding, JsonSerializerSettings? settings)
    {
        await Serialize(type, value, encoding, settings).WriteToAsync(stream, CancellationToken.None);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream, Encoding encoding,
        JsonSerializerSettings? settings = null) =>
        (TValue?)await UnpackAsync(typeof(TValue), stream, encoding, settings);

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task<object?> UnpackAsync(Type type, Stream? stream, Encoding encoding,
        JsonSerializerSettings? settings = null)
    {
        var result = Deserialize(type, encoding.GetString(await stream.ReadToEndAsync()), settings);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}