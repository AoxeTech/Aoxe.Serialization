namespace Zaabee.Xml;

public static partial class XmlHelper
{
    /// <summary>
    /// Deserializes the XML document contained by the specified TextReader.
    /// </summary>
    /// <param name="textReader"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(TextReader? textReader) =>
        textReader is null
            ? default
            : (TValue?)Deserialize(typeof(TValue), textReader);

    /// <summary>
    /// Deserializes the XML document contained by the specified TextReader.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="textReader"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, TextReader? textReader) =>
        textReader is null
            ? default
            : GetSerializer(type).Deserialize(textReader);
}