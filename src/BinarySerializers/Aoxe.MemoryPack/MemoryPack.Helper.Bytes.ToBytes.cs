namespace Aoxe.MemoryPack;

public static partial class MemoryPackHelper
{
    public static byte[] ToBytes<TValue>(
        TValue? value,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackSerializer.Serialize(value, options);

    public static byte[] ToBytes(
        Type type,
        object? value,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackSerializer.Serialize(type, value, options);
}
