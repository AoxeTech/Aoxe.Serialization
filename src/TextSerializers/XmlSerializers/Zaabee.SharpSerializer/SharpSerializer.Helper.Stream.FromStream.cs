namespace Zaabee.SharpSerializer;

public static partial class SharpSerializerHelper
{
    /// <summary>
    /// Deserializes the XML document contained by the specified stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream) =>
        stream is null or { CanSeek: true, Length: 0 }
            ? default
            : (TValue?)FromStream(typeof(TValue), stream)!;

    /// <summary>
    /// Deserializes the XML document contained by the specified stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var serializer = new Polenter.Serialization.SharpSerializer(_defaultSettings);
        return serializer.Deserialize(stream);
    }
}