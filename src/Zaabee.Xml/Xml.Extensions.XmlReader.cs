namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static TValue? ReadXml<TValue>(this XmlReader? xmlReader) =>
        XmlHelper.Deserialize<TValue>(xmlReader);

    public static object? ReadXml(this XmlReader? xmlReader, Type type) =>
        XmlHelper.Deserialize(type, xmlReader);
}