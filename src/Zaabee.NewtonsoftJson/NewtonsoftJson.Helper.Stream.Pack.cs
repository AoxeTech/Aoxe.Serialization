namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null)
    {
        if (stream is null) return;
        ToBytes(value, settings, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    public static void Pack(Type type, object? value, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null)
    {
        if (stream is null) return;
        ToBytes(type, value, settings, encoding).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}