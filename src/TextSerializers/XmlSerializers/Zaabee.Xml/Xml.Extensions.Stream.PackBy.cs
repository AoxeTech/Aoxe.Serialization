namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        XmlHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        XmlHelper.Pack(type, value, stream);
}
