namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static TValue? Deserialize<TValue>(XmlReader? xmlReader) =>
        xmlReader is null
            ? default
            : XmlSerializer.Deserialize<TValue>(xmlReader);

    public static object? Deserialize(Type type, XmlReader? xmlReader) =>
        xmlReader is null
            ? default
            : XmlSerializer.Deserialize(type, xmlReader);
}