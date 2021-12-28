namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    /// <summary>
    /// Deserializes a stream into a generic object.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue? FromStream<TValue>(Stream? stream) =>
        stream is null || stream.CanSeek && stream.Length is 0
            ? default
            : (TValue?)FromStream(stream);

    /// <summary>
    /// Deserializes a stream into an object graph.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? FromStream(Stream? stream)
    {
        if (stream is null || stream.CanSeek && stream.Length is 0) return default;
        _binaryFormatter ??= new BinaryFormatter();
        var result = _binaryFormatter.Deserialize(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}