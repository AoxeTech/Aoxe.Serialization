namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        DataContractHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        DataContractHelper.FromBytes(type, bytes);
}
