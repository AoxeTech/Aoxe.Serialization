namespace Zaabee.Binary;

public static partial class BinarySerializer
{
    [ThreadStatic] private static BinaryFormatter? _binaryFormatter;

    /// <summary>
    /// Serializes an object into a MemoryStream.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static MemoryStream Pack(object obj)
    {
        var ms = new MemoryStream();
        Pack(obj, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object, or graph of objects with the specified top (root), to the given stream.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    public static void Pack(object obj, Stream stream)
    {
        _binaryFormatter ??= new BinaryFormatter();
        _binaryFormatter.Serialize(stream, obj);
        stream.TrySeek(0, SeekOrigin.Begin);
    }


    /// <summary>
    /// Deserializes a stream into a generic object.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Unpack<T>(Stream stream) => (T)Unpack(stream);

    /// <summary>
    /// Deserializes a stream into an object graph.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object Unpack(Stream stream)
    {
        _binaryFormatter ??= new BinaryFormatter();
        var result = _binaryFormatter.Deserialize(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}