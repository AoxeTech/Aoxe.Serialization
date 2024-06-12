namespace Aoxe.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static byte[] ToBytes<TValue>(this TValue? value) => DataContractHelper.ToBytes(value);

    public static byte[] ToBytes(this object? value, Type type) =>
        DataContractHelper.ToBytes(type, value);
}
