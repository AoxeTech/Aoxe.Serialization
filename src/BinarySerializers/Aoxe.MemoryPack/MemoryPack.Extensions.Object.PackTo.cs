namespace Aoxe.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.Pack(value, stream, options);

    public static void PackTo(
        this object? value,
        Type type,
        Stream? stream,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.Pack(type, value, stream, options);
}
