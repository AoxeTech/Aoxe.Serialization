namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    /// <summary>
    /// Serializes an object into a MemoryStream.Will return an empty Stream when the value is null.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static Stream Pack(object? value) =>
        value is null ? Stream.Null : BinarySerializer.Pack(value);

    /// <summary>
    /// Serializes the object, or graph of objects with the specified top (root), to the given stream.
    /// When the value or the stream is null, it will not be processed.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static void Pack(object? value, Stream? stream)
    {
        if (value is null || stream is null) return;
        BinarySerializer.Pack(value, stream);
    }

    /// <summary>
    /// Deserializes a stream into a generic object.Will return default value of TValue when the stream is null or empty.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty() ? default! : BinarySerializer.Unpack<TValue>(stream!);

    /// <summary>
    /// Deserializes a stream into an object graph.Will return null when the stream is null or empty.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object Unpack(Stream? stream) =>
        stream.IsNullOrEmpty() ? default! : BinarySerializer.Unpack(stream!);
}