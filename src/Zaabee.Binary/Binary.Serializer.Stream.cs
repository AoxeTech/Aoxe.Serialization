namespace Zaabee.Binary;

public static partial class BinarySerializer
{
    [ThreadStatic] private static BinaryFormatter? _binaryFormatter;

    /// <summary>
    /// Serializes an object into a MemoryStream.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static Stream Pack(object value)
    {
        var ms = new MemoryStream();
        Pack(value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the object, or graph of objects with the specified top (root), to the given stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void Pack(object value, Stream stream)
    {
        _binaryFormatter ??= new BinaryFormatter();
        _binaryFormatter.Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserializes a stream into a generic object.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue Unpack<TValue>(Stream stream) =>
        (TValue)Unpack(stream);

    /// <summary>
    /// Deserializes a stream into an object graph.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object Unpack(Stream stream)
    {
        _binaryFormatter ??= new BinaryFormatter();
        var result = _binaryFormatter.Deserialize(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}