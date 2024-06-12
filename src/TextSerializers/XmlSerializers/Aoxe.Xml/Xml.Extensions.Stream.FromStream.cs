namespace Aoxe.Xml;

public static partial class XmlExtensions
{
    public static TValue? FromStream<TValue>(this Stream? stream) =>
        XmlHelper.FromStream<TValue>(stream);

    public static object? FromStream(this Stream? stream, Type type) =>
        XmlHelper.FromStream(type, stream);
}
