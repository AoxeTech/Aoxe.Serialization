namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        XmlHelper.Deserialize<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        XmlHelper.Deserialize(type, bytes);
}