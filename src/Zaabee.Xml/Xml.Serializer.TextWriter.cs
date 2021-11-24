namespace Zaabee.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified TextWriter.
    /// </summary>
    /// <param name="textWriter"></param>
    /// <param name="obj"></param>
    /// <typeparam name="T"></typeparam>
    public static void Serialize<T>(TextWriter textWriter, object obj) =>
        Serialize(typeof(T), textWriter, obj);

    /// <summary>
    /// Serializes the specified object and writes the XML document to a file using the specified TextWriter.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="textWriter"></param>
    /// <param name="obj"></param>
    public static void Serialize(Type type, TextWriter textWriter, object obj) =>
        GetSerializer(type).Serialize(textWriter, obj);
}