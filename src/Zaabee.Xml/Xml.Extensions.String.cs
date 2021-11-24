namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static T FromXml<T>(this string str) =>
        XmlHelper.Deserialize<T>(str);

    public static object FromXml(this string str, Type type) =>
        XmlHelper.Deserialize(type, str);
}