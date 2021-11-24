namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    /// <summary>
    /// Serializes an object into a MemoryStream.Will return an empty MemoryStream when the obj is null.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static MemoryStream Pack(object? obj) =>
        obj is null ? new MemoryStream() : BinarySerializer.Pack(obj);

    /// <summary>
    /// Serializes the object, or graph of objects with the specified top (root), to the given stream.
    /// When the obj or the stream is null, it will not be processed.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="stream"></param>
    public static void Pack(object? obj, Stream? stream)
    {
        if (obj is null || stream is null) return;
        BinarySerializer.Pack(obj, stream);
    }

    /// <summary>
    /// Deserializes a stream into a generic object.Will return default value of T when the stream is null or empty.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? Unpack<T>(Stream? stream) =>
        stream.IsNullOrEmpty() ? default : BinarySerializer.Unpack<T>(stream!);

    /// <summary>
    /// Deserializes a stream into an object graph.Will return null when the stream is null or empty.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? Unpack(Stream? stream) =>
        stream.IsNullOrEmpty() ? null : BinarySerializer.Unpack(stream!);
}