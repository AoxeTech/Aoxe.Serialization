namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        DataContractHelper.Deserialize<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        DataContractHelper.Deserialize(type, bytes);
}