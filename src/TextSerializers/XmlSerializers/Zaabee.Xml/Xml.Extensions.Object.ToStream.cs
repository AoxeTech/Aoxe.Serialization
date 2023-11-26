namespace Zaabee.Xml;

public static partial class XmlExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value) => XmlHelper.ToStream(value);

    public static MemoryStream ToStream(this object? value, Type type) =>
        XmlHelper.ToStream(type, value);
}
