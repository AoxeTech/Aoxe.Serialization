namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) => XmlHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value, Type type) => XmlHelper.ToBytes(type, value);
}
