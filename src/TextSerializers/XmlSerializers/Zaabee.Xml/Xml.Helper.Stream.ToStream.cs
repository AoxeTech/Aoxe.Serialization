namespace Zaabee.Xml;

public static partial class XmlHelper
{
    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using a memory stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value) => ToStream(typeof(TValue), value);

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using a memory stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(Type type, object? value)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms);
        return ms;
    }
}
