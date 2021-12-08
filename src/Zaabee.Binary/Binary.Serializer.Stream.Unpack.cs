namespace Zaabee.Binary;

public static partial class BinarySerializer
{
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