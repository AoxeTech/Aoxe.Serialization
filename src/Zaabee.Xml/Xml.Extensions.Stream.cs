namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue value) =>
        XmlHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        XmlHelper.Pack(type, value, stream);

    public static TValue? Unpack<TValue>(this Stream? stream) =>
        XmlHelper.Unpack<TValue>(stream);

    public static object? Unpack(this Stream? stream, Type type) =>
        XmlHelper.Unpack(type, stream);
}