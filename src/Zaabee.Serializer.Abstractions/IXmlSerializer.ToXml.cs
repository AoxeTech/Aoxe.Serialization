namespace Zaabee.Serializer.Abstractions;

public partial interface IXmlSerializer
{
    /// <summary>
    /// Serialize to xml.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToXml<TValue>(TValue? value);
    
    /// <summary>
    /// Serialize to xml.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToXml(Type type, object? value);
}