namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static TValue? FromBytes<TValue>(this byte[]? bytes) =>
        SharpSerializerHelper.FromBytes<TValue>(bytes);

    public static object? FromBytes(this byte[]? bytes, Type type) =>
        SharpSerializerHelper.FromBytes(type, bytes);
}