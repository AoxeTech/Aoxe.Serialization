namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) =>
        SharpSerializerHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        SharpSerializerHelper.ToBytes(type, value);
}