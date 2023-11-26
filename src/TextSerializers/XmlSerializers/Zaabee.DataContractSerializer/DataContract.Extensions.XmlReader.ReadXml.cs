namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? ReadXml<TValue>(this XmlReader? xmlReader) =>
        DataContractHelper.Deserialize<TValue>(xmlReader);

    public static object? ReadXml(this XmlReader? xmlReader, Type type) =>
        DataContractHelper.Deserialize(type, xmlReader);
}
