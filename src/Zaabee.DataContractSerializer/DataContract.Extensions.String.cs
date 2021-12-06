namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromXml<TValue>(this string str) =>
        DataContractHelper.Deserialize<TValue>(str);

    public static object? FromXml(this string str, Type type) =>
        DataContractHelper.Deserialize(type, str);
}