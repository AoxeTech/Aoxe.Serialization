namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static byte[] ToBytes<TValue>(this TValue value) =>
        DataContractHelper.Serialize(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        DataContractHelper.Serialize(type, value);

    public static Stream ToStream<TValue>(this TValue value) =>
        DataContractHelper.Pack(value);

    public static void PackTo<TValue>(this TValue value, Stream? stream) =>
        DataContractHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        DataContractHelper.Pack(type, value, stream);

    public static Stream Pack(this object? value, Type type) =>
        DataContractHelper.Pack(type, value);

    public static string ToXml<TValue>(this TValue value) =>
        DataContractHelper.SerializeToXml(value);

    public static string ToXml(this object? value, Type type) =>
        DataContractHelper.SerializeToXml(type, value);

    public static void ToXml<TValue>(this TValue value, XmlWriter xmlWriter) =>
        DataContractHelper.Serialize(xmlWriter, value);

    public static void ToXml(this object? value, Type type, XmlWriter xmlWriter) =>
        DataContractHelper.Serialize(type, xmlWriter, value);
}