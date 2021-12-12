namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static string ToXml<TValue>(this TValue? value) =>
        DataContractHelper.ToXml(value);

    public static string ToXml(this object? value, Type type) =>
        DataContractHelper.ToXml(type, value);
}