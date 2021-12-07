namespace Zaabee.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified XmlWriter.
    /// </summary>
    /// <param name="xmlWriter"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    public static void Serialize<TValue>(XmlWriter xmlWriter, TValue? value) =>
        Serialize(typeof(TValue), xmlWriter, value);

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified XmlWriter.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xmlWriter"></param>
    /// <param name="value"></param>
    public static void Serialize(Type type, XmlWriter xmlWriter, object? value) =>
        GetSerializer(type).Serialize(xmlWriter, value);
}