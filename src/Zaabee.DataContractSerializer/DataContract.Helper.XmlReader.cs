namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    public static TValue? Deserialize<TValue>(XmlReader? xmlReader) =>
        xmlReader is null ? default : DataContractSerializer.Deserialize<TValue>(xmlReader);

    public static object? Deserialize(Type type, XmlReader? xmlReader) =>
        xmlReader is null ? null : DataContractSerializer.Deserialize(type, xmlReader);
}