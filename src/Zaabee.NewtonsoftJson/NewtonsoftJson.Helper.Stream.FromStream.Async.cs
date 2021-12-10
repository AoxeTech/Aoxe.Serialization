namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<TValue?> FromStreamAsync<TValue>(Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        stream.IsNullOrEmpty()
            ? default
            : (TValue?)await FromStreamAsync(typeof(TValue), stream, settings, encoding);

    /// <summary>
    /// Read the stream to bytes asynchronously, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task<object?> FromStreamAsync(Type type, Stream? stream,
        JsonSerializerSettings? settings = null, Encoding? encoding = null)
    {
        if (stream.IsNullOrEmpty()) return default;
        var result = FromJson(type, GetString(encoding, await stream.ReadToEndAsync()), settings);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}