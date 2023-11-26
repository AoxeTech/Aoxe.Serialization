namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static TValue? FromXml<TValue>(this string? str) => XmlHelper.FromXml<TValue>(str);

    public static object? FromXml(this string? str, Type type) => XmlHelper.FromXml(type, str);
}
