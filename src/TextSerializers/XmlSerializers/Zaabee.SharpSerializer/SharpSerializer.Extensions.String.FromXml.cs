namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromXml<TValue>(this string? xml) =>
        SharpSerializerHelper.FromXml<TValue>(xml);

    public static object? FromXml(this string? xml, Type type) =>
        SharpSerializerHelper.FromXml(type, xml);
}