namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static string SerializeToXml<T>(T t) =>
        XmlSerializer.SerializeToXml(t);

    public static string SerializeToXml(Type type, object obj) =>
        XmlSerializer.SerializeToXml(type, obj);

    public static T Deserialize<T>(string xml) =>
        xml.IsNullOrWhiteSpace()
            ? (T) typeof(T).GetDefaultValue()
            : XmlSerializer.Deserialize<T>(xml);

    public static object Deserialize(Type type, string xml) =>
        type is null || xml.IsNullOrWhiteSpace()
            ? null
            : XmlSerializer.Deserialize(type, xml);
}