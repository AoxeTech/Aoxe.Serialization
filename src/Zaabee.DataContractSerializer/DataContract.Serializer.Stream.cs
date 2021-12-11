namespace Zaabee.DataContractSerializer;

public static partial class DataContractSerializer
{
    private static readonly ConcurrentDictionary<Type, System.Runtime.Serialization.DataContractSerializer>
        SerializerCache = new();

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream Pack<TValue>(TValue? value) =>
        Pack(typeof(TValue), value);

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using a memory stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MemoryStream Pack(Type type, object? value)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms);
        return ms;
    }

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream) =>
        Pack(typeof(TValue), value, stream);

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        GetSerializer(type).WriteObject(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    /// <summary>
    /// Deserializes the XML document contained by the specified stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Unpack<TValue>(Stream? stream) =>
        (TValue?)Unpack(typeof(TValue), stream)!;

    /// <summary>
    /// Deserializes the XML document contained by the specified stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? Unpack(Type type, Stream? stream)
    {
        var result = GetSerializer(type).ReadObject(stream);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    private static System.Runtime.Serialization.DataContractSerializer GetSerializer(Type type) =>
        SerializerCache.GetOrAdd(type, new System.Runtime.Serialization.DataContractSerializer(type));
}