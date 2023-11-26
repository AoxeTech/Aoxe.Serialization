namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value) =>
        SharpSerializerHelper.Pack(value, stream);

    public static void PackBy(this Stream? stream, Type type, object? value) =>
        SharpSerializerHelper.Pack(type, value, stream);
}
