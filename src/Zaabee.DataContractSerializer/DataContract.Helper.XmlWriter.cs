namespace Zaabee.DataContractSerializer;

public static partial class DataContractHelper
{
    public static void Serialize<TValue>(XmlWriter? xmlWriter, TValue? value)
    {
        if (xmlWriter is null) return;
        DataContractSerializer.Serialize(xmlWriter, value);
    }

    public static void Serialize(Type type, XmlWriter? xmlWriter, object? value)
    {
        if (xmlWriter is null) return;
        DataContractSerializer.Serialize(type, xmlWriter, value);
    }
}