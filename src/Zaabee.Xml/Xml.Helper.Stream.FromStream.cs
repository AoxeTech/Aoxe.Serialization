namespace Zaabee.Xml;

public static partial class XmlHelper
{
    /// <summary>
    /// Deserializes the XML document contained by the specified stream.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromStream<TValue>(Stream? stream) =>
        stream.IsNullOrEmpty()
            ? default
            : (TValue?)FromStream(typeof(TValue), stream);

    /// <summary>
    /// Deserializes the XML document contained by the specified stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    public static object? FromStream(Type type, Stream? stream)
    {
        if (stream.IsNullOrEmpty()) return default;
        var result = GetSerializer(type).Deserialize(stream!);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}