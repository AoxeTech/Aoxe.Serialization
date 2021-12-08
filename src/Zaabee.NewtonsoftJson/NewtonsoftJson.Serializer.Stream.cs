namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream Pack<TValue>(TValue value, Encoding encoding, JsonSerializerSettings? settings = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding, settings);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static Stream Pack(Type type, object? value, Encoding encoding, JsonSerializerSettings? settings = null)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, encoding, settings);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue value, Stream? stream, Encoding encoding, JsonSerializerSettings? settings = null)
    {
        Serialize(value, encoding, settings).WriteTo(stream);
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
    public static void Pack(Type type, object? value, Stream stream, Encoding encoding, JsonSerializerSettings? settings)
    {
        Serialize(type, value, encoding, settings).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream, Encoding encoding, JsonSerializerSettings? settings = null) =>
        (TValue?) Unpack(typeof(TValue), stream, encoding, settings);

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream, Encoding encoding, JsonSerializerSettings? settings = null)
    {
        var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), settings);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}