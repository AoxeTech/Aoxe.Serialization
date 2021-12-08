namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream Pack<TValue>(TValue? value, Encoding encoding, Options? options = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding, options);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream stream, Encoding encoding, Options? options = null)
    {
        Serialize(value, encoding, options).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static Stream Pack(object? value, Encoding encoding, Options? options = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, encoding, options);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    public static void Pack(object? value, Stream stream, Encoding encoding, Options? options = null)
    {
        Serialize(value, encoding, options).WriteTo(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream, Encoding encoding, Options? options = null)
    {
        var result = Deserialize<TValue>(encoding.GetString(stream.ReadToEnd()), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream, Encoding encoding, Options? options = null)
    {
        var result = Deserialize(type, encoding.GetString(stream.ReadToEnd()), options);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}