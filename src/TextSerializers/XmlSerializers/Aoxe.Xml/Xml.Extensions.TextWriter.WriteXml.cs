namespace Aoxe.Xml;

public static partial class XmlExtensions
{
    public static void WriteXml<TValue>(this TextWriter? textWriter, TValue? value) =>
        XmlHelper.Serialize(textWriter, value);

    public static void WriteXml(this TextWriter? textWriter, Type type, object? value) =>
        XmlHelper.Serialize(type, textWriter, value);
}
