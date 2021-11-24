namespace Zaabee.ZeroFormatter;

public static partial class ZeroSerializer
{
    /// <summary>
    /// Serializes the object to a memory stream and return it.
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static MemoryStream Pack<T>(T t)
    {
        var ms = new MemoryStream();
        Pack(t, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object to a memory stream and return it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static MemoryStream Pack(Type type, object obj)
    {
        var ms = new MemoryStream();
        Pack(type, obj, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object to the stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
    public static void Pack<T>(T t, Stream stream)
    {
        ZeroFormatterSerializer.Serialize(stream, t);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Serializes the object to the stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object obj, Stream stream)
    {
        ZeroFormatterSerializer.NonGeneric.Serialize(type, stream, obj);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserializes from the specified stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Unpack<T>(Stream stream)
    {
        var result = ZeroFormatterSerializer.Deserialize<T>(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    /// <summary>
    /// Deserializes from the specified stream,the stream will be try seek to the beginning position.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object Unpack(Type type, Stream stream)
    {
        var result = ZeroFormatterSerializer.NonGeneric.Deserialize(type, stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}