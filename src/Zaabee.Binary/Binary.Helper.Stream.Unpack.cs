namespace Zaabee.Binary;

public static partial class BinaryHelper
{
    /// <summary>
    /// Deserializes a stream into a generic object.Will return default value of TValue when the stream is null or empty.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static TValue? Unpack<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinarySerializer.Unpack<TValue>(stream!);

    /// <summary>
    /// Deserializes a stream into an object graph.Will return null when the stream is null or empty.
    /// </summary>
    /// <param name="stream"></param>
    /// <returns></returns>
    [ObsoleteAttribute(@"BinaryFormatter serialization is obsolete and should not be used.
 See https://aka.ms/binaryformatter for more information.")]
    public static object? Unpack(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : BinarySerializer.Unpack(stream!);
}