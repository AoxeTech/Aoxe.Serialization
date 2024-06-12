namespace Aoxe.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static void WriteXml<TValue>(
        this XmlDictionaryWriter? xmlDictionaryWriter,
        TValue? value
    ) => DataContractHelper.Serialize(xmlDictionaryWriter, value);

    public static void WriteXml(
        this XmlDictionaryWriter? xmlDictionaryWriter,
        Type type,
        object? value
    ) => DataContractHelper.Serialize(type, xmlDictionaryWriter, value);
}
