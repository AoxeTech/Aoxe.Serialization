namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static T ReadXml<T>(this TextReader textReader) =>
        XmlHelper.Deserialize<T>(textReader);

    public static object ReadXml(this TextReader textReader, Type type) =>
        XmlHelper.Deserialize(type, textReader);
}