namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? ReadXml<TValue>(this XmlDictionaryReader? xmlDictionaryReader) =>
        DataContractHelper.Deserialize<TValue>(xmlDictionaryReader);

    public static object? ReadXml(this XmlDictionaryReader? xmlDictionaryReader, Type type) =>
        DataContractHelper.Deserialize(type, xmlDictionaryReader);
}