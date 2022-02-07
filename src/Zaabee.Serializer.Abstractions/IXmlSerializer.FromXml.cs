namespace Zaabee.Serializer.Abstractions;

public partial interface IXmlSerializer : ITextSerializer
{
    /// <summary>
    /// If the xml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="xml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromXml<TValue>(string? xml);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xml"></param>
    /// <returns></returns>
    object? FromXml(Type type, string? xml);
}