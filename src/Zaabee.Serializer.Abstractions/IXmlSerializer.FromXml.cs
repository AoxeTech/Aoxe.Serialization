namespace Zaabee.Serializer.Abstractions;

public partial interface IXmlSerializer : ITextSerializer
{
}

public static partial class XmlSerializerExtension
{
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