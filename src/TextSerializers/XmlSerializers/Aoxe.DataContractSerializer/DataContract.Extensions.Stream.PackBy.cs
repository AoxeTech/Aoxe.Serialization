namespace Aoxe.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        DataContractHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        DataContractHelper.Pack(type, value, stream);
}
