namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static string ToXml<TValue>(this TValue? value) =>
        XmlHelper.ToXml(value);

    public static string ToXml(this object? value, Type type) =>
        XmlHelper.ToXml(type, value);
}