namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        XmlHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        XmlHelper.Pack(type, value, stream);
}
