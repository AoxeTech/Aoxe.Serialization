namespace Zaabee.DataContractSerializer;

public static partial class DataContractExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        DataContractHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        DataContractHelper.Pack(type, value, stream);

    public static TValue? Unpack<TValue>(this Stream? stream) =>
        DataContractHelper.Unpack<TValue>(stream);

    public static object? Unpack(this Stream? stream, Type type) =>
        DataContractHelper.Unpack(type, stream);
}