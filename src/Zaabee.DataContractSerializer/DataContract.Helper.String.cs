namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    public static string SerializeToXml<TValue>(TValue? value) =>
        DataContractSerializer.SerializeToXml(value);

    public static string SerializeToXml(Type type, object? value) =>
        DataContractSerializer.SerializeToXml(type, value);

    public static TValue? Deserialize<TValue>(string? xml) =>
        xml.IsNullOrWhiteSpace()
            ? default
            : DataContractSerializer.Deserialize<TValue>(xml!);

    public static object? Deserialize(Type type, string? xml) =>
        xml.IsNullOrWhiteSpace()
            ? default
            : DataContractSerializer.Deserialize(type, xml!);
}