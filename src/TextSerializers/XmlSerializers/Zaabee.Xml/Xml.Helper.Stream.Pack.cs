namespace Zaabee.Xml;

public static partial class XmlHelper
{
    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Pack<TValue>(TValue? value, Stream? stream)
    {
        if (stream is null) return;
        Pack(typeof(TValue), value, stream);
    }

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    public static void Pack(Type type, object? value, Stream? stream)
    {
        if (stream is null) return;
        GetSerializer(type).Serialize(stream, value);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}