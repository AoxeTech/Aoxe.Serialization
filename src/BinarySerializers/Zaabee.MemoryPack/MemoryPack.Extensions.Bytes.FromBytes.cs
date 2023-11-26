namespace Zaabee.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static TValue? FromBytes<TValue>(
        this ReadOnlySpan<byte> bytes,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromBytes<TValue>(bytes, options);

    public static object? FromBytes(
        this ReadOnlySpan<byte> bytes,
        Type type,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromBytes(type, bytes, options);

    public static TValue? FromBytes<TValue>(
        this ReadOnlySequence<byte> bytes,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromBytes<TValue>(bytes, options);

    public static object? FromBytes(
        this ReadOnlySequence<byte> bytes,
        Type type,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromBytes(type, bytes, options);

    public static TValue? FromBytes<TValue>(
        this byte[]? bytes,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromBytes<TValue>(bytes, options);

    public static object? FromBytes(
        this byte[]? bytes,
        Type type,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromBytes(type, bytes, options);
}
