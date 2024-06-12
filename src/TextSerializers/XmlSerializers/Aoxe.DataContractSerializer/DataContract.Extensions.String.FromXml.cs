namespace Aoxe.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromXml<TValue>(this string? xml) =>
        DataContractHelper.FromXml<TValue>(xml);

    public static object? FromXml(this string? xml, Type type) =>
        DataContractHelper.FromXml(type, xml);
}
