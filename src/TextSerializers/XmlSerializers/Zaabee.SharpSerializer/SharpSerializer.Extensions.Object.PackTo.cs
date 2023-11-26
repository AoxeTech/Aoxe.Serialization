namespace Zaabee.SharpSerializer;

public static partial class DataContractExtensions
{
    public static void PackTo<TValue>(this TValue? value, Stream? stream) =>
        SharpSerializerHelper.Pack(value, stream);

    public static void PackTo(this object? value, Type type, Stream? stream) =>
        SharpSerializerHelper.Pack(type, value, stream);
}
