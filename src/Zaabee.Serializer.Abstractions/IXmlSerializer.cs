namespace Zaabee.Serializer.Abstractions;

public interface IXmlSerializer : ITextSerializer
{
    /// <summary>
    /// Serialize to xml.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToXml<TValue>(TValue? value);

    /// <summary>
    /// If the xml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="xml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromXml<TValue>(string? xml);

    /// <summary>
    /// Serialize to xml.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToXml(Type type, object? value);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <returns></returns>
    object? FromXml(Type type, string? xml);
}