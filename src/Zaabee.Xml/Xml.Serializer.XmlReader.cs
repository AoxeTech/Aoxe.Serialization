namespace Zaabee.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Deserializes the XML document contained by the specified XmlReader.
    /// </summary>
    /// <param name="xmlReader"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(XmlReader xmlReader) => (TValue) Deserialize(typeof(TValue), xmlReader);

    /// <summary>
    /// Deserializes the XML document contained by the specified XmlReader.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xmlReader"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, XmlReader xmlReader) =>
        GetSerializer(type).Deserialize(xmlReader);
}