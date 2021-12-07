namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static TValue? Deserialize<TValue>(TextReader? textReader) =>
        textReader is null
            ? default
            : XmlSerializer.Deserialize<TValue>(textReader);

    public static object? Deserialize(Type type, TextReader? textReader) =>
        textReader is null
            ? default
            : XmlSerializer.Deserialize(type, textReader);
}