namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static string SerializeToXml<TValue>(TValue? value) =>
        XmlSerializer.SerializeToXml(value);

    public static string SerializeToXml(Type type, object? value) =>
        XmlSerializer.SerializeToXml(type, value);

    public static TValue? Deserialize<TValue>(string? xml) =>
        xml.IsNullOrWhiteSpace()
            ? default
            : XmlSerializer.Deserialize<TValue>(xml!);

    public static object? Deserialize(Type type, string? xml) =>
        xml.IsNullOrWhiteSpace()
            ? default
            : XmlSerializer.Deserialize(type, xml!);
}