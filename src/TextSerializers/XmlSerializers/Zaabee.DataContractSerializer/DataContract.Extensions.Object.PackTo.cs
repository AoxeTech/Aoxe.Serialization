namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        DataContractHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        DataContractHelper.Pack(type, value, stream);
}
