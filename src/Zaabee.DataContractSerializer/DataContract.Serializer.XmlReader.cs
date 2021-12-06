namespace Zaabee.DataContractSerializer;

public static partial class DataContractSerializer
{
    /// <summary>
    /// Deserializes the XML document contained by the specified XmlReader.
    /// </summary>
    /// <param name="xmlReader"></param>
    /// <param name="verifyObjectName"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(XmlReader xmlReader, bool verifyObjectName = true) =>
        (TValue?)Deserialize(typeof(TValue), xmlReader, verifyObjectName);

    /// <summary>
    /// Deserializes the XML document contained by the specified XmlReader.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="xmlReader"></param>
    /// <param name="verifyObjectName"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, XmlReader xmlReader, bool verifyObjectName = true) =>
        GetSerializer(type).ReadObject(xmlReader, verifyObjectName);
}