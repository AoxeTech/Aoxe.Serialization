namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static void WriteXml<TValue>(this XmlWriter? xmlWriter, TValue? value) =>
        DataContractHelper.Serialize(xmlWriter, value);

    public static void WriteXml(this XmlWriter? xmlWriter, Type type, object? value) =>
        DataContractHelper.Serialize(type, xmlWriter, value);
}