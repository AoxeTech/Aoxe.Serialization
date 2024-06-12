namespace Aoxe.Xml;

public static partial class XmlExtensions
{
    public static void WriteXml<TValue>(this XmlWriter? xmlWriter, TValue? value) =>
        XmlHelper.Serialize(xmlWriter, value);

    public static void WriteXml(this XmlWriter? xmlWriter, Type type, object? value) =>
        XmlHelper.Serialize(type, xmlWriter, value);
}
