namespace Zaabee.ZeroFormatter;

public static partial class ZeroSerializer
{
    /// <summary>
    /// Serializes the object to a memory stream and return it.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static Stream Pack<TValue>(TValue value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static Stream Pack(Type type, object? value)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object to the stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue value, Stream? stream)
    {
        ZeroFormatterSerializer.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serializes the object to the stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserializes from the specified stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream)
    {
        var result = ZeroFormatterSerializer.Deserialize<TValue>(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Deserializes from the specified stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream)
    {
        var result = ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}