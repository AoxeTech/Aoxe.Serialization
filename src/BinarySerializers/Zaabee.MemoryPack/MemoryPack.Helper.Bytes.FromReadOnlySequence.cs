namespace Zaabee.MemoryPack;

public static partial class MemoryPackHelper
{
    public static TValue? FromBytes<TValue>(
        ReadOnlySequence<byte> bytes,
        MemoryPackSerializerOptions? options = null) =>
        bytes.Length is 0
            ? default
            : MemoryPackSerializer.Deserialize<TValue>(bytes, options);

    public static object? FromBytes(
        Type type,
        ReadOnlySequence<byte> bytes,
        MemoryPackSerializerOptions? options = null) =>
        bytes.Length is 0
            ? default
            : MemoryPackSerializer.Deserialize(type, bytes, options);
}