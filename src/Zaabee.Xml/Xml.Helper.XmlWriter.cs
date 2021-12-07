namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static void Serialize<TValue>(XmlWriter? xmlWriter, TValue? value)
    {
        if (xmlWriter is null || value is null) return;
        XmlSerializer.Serialize(xmlWriter, value);
    }

    public static void Serialize(Type type, XmlWriter? xmlWriter, object? value)
    {
        if (xmlWriter is null || value is null) return;
        XmlSerializer.Serialize(type, xmlWriter, value);
    }
}