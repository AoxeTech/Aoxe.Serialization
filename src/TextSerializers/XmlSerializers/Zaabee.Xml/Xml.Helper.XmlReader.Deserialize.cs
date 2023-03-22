namespace Zaabee.Xml;

public static partial class XmlHelper
{
    /// <summary>
    /// Deserializes the XML document contained by the specified XmlReader.
    /// </summary>
    /// <param name="xmlReader"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(XmlReader? xmlReader) =>
        xmlReader is null
            ? default
            : (TValue?)Deserialize(typeof(TValue), xmlReader);

    /// <summary>
    /// Deserializes the XML document contained by the specified XmlReader.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xmlReader"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, XmlReader? xmlReader) =>
        xmlReader is null
            ? default
            : GetSerializer(type).Deserialize(xmlReader);
}