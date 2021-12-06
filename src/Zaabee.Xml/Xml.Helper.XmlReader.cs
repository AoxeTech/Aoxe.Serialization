namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static TValue? Deserialize<TValue>(XmlReader xmlReader) =>
        xmlReader is null ? default : XmlSerializer.Deserialize<TValue>(xmlReader);

    public static object? Deserialize(Type type, XmlReader xmlReader) =>
        type is null || xmlReader is null ? null : XmlSerializer.Deserialize(type, xmlReader);
}