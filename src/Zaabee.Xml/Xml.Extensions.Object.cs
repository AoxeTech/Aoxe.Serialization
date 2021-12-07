namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) =>
        XmlHelper.Serialize(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        XmlHelper.Serialize(type, value);

    public static Stream ToStream<TValue>(this TValue? value) =>
        XmlHelper.Pack(value);

    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        XmlHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        XmlHelper.Pack(type, value, stream);

    public static Stream Pack(this object? value, Type type) =>
        XmlHelper.Pack(type, value);

    public static string ToXml<TValue>(this TValue? value) =>
        XmlHelper.SerializeToXml(value);

    public static string ToXml(this object? value, Type type) =>
        XmlHelper.SerializeToXml(type, value);

    public static void ToXml<TValue>(this TValue? value, TextWriter? textWriter) =>
        XmlHelper.Serialize(textWriter, value);

    public static void ToXml(this object? value, Type type, TextWriter? textWriter) =>
        XmlHelper.Serialize(type, textWriter, value);

    public static void ToXml<TValue>(this TValue? value, XmlWriter? xmlWriter) =>
        XmlHelper.Serialize(xmlWriter, value);

    public static void ToXml(this object? value, Type type, XmlWriter? xmlWriter) =>
        XmlHelper.Serialize(type, xmlWriter, value);
}