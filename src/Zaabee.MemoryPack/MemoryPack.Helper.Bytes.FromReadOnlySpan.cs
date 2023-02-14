namespace Zaabee.MemoryPack;

public partial class MemoryPackHelper
{
    public static TValue? FromBytes<TValue>(
        ReadOnlySpan<byte> bytes,
        MemoryPackSerializerOptions? options = null) =>
        bytes.Length is 0
            ? default
            : MemoryPackSerializer.Deserialize<TValue>(bytes, options);

    public static object? FromBytes(
        Type type,
        ReadOnlySpan<byte> bytes,
        MemoryPackSerializerOptions? options = null) =>
        bytes.Length is 0
            ? default
            : MemoryPackSerializer.Deserialize(type, bytes, options);
}