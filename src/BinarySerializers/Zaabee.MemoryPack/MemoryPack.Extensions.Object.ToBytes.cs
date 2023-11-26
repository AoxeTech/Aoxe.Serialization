namespace Zaabee.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.ToBytes(value, options);

    public static byte[] ToBytes(
        this object? value,
        Type type,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.ToBytes(type, value, options);
}
