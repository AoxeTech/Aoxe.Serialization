namespace Zaabee.Xml;

public static partial class XmlHelper
{
    public static void Serialize<T>(XmlWriter xmlWriter, T t)
    {
        if (xmlWriter is null || t is null) return;
        XmlSerializer.Serialize(xmlWriter, t);
    }

    public static void Serialize(Type type, XmlWriter xmlWriter, object obj)
    {
        if (type is null || xmlWriter is null || obj is null) return;
        XmlSerializer.Serialize(type, xmlWriter, obj);
    }
}