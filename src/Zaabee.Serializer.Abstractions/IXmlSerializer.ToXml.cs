namespace Zaabee.Serializer.Abstractions;

public partial interface IXmlSerializer
{
}

public static partial class XmlSerializerExtension
{
    /// <summary>
    /// Serialize to xml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToXml<TValue>(this IXmlSerializer serializer, TValue? value) =>
        serializer.ToText(value);

    /// <summary>
    /// Serialize to xml.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToXml(this IXmlSerializer serializer, Type type, object? value) =>
        serializer.ToText(type, value);
}