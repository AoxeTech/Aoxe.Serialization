namespace Aoxe.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.Pack(value, stream, options);

    public static void PackBy(
        this Stream? stream,
        Type type,
        object? value,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.Pack(type, value, stream, options);
}
