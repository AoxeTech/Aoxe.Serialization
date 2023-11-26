namespace Zaabee.Serializer.Abstractions;

public interface IXmlSerializer : ITextSerializer { }

public static class XmlSerializerExtension
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

    /// <summary>
    /// If the xml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="xml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromXml<TValue>(this IXmlSerializer serializer, string? xml) =>
        serializer.FromText<TValue>(xml);

    /// <summary>
    /// If the xml is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <returns></returns>
    public static object? FromXml(this IXmlSerializer serializer, Type type, string? xml) =>
        serializer.FromText(type, xml);
}
