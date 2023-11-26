namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static void Serialize<TValue>(this TValue? value, XmlWriter? xmlWriter) =>
        DataContractHelper.Serialize(xmlWriter, value);

    public static void Serialize(this object? value, Type type, XmlWriter? xmlWriter) =>
        DataContractHelper.Serialize(type, xmlWriter, value);

    public static void Serialize<TValue>(
        this TValue? value,
        XmlDictionaryWriter? xmlDictionaryWriter
    ) => DataContractHelper.Serialize(xmlDictionaryWriter, value);

    public static void Serialize(
        this object? value,
        Type type,
        XmlDictionaryWriter? xmlDictionaryWriter
    ) => DataContractHelper.Serialize(type, xmlDictionaryWriter, value);
}
