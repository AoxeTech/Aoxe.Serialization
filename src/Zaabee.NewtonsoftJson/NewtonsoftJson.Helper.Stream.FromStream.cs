namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : (TValue?)FromStream(typeof(TValue), stream, settings, encoding);

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null)
    {
        if (stream is null || stream.CanSeek && stream.Length is 0) return default;
        var result = FromJson(type, stream.ReadToEnd().GetString(encoding), settings);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}