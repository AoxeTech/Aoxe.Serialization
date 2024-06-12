namespace Aoxe.Xml;

public static partial class XmlExtensions
{
    public static TValue? ReadXml<TValue>(this TextReader? textReader) =>
        XmlHelper.Deserialize<TValue>(textReader);

    public static object? ReadXml(this TextReader? textReader, Type type) =>
        XmlHelper.Deserialize(type, textReader);
}
