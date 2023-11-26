namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static void Serialize<TValue>(this TValue? value, TextWriter? textWriter) =>
        XmlHelper.Serialize(textWriter, value);

    public static void Serialize(this object? value, Type type, TextWriter? textWriter) =>
        XmlHelper.Serialize(type, textWriter, value);

    public static void Serialize<TValue>(this TValue? value, XmlWriter? xmlWriter) =>
        XmlHelper.Serialize(xmlWriter, value);

    public static void Serialize(this object? value, Type type, XmlWriter? xmlWriter) =>
        XmlHelper.Serialize(type, xmlWriter, value);
}
