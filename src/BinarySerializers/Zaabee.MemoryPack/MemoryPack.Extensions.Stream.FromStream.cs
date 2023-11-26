namespace Zaabee.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromStream<TValue>(stream, options);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        MemoryPackSerializerOptions? options = null
    ) => MemoryPackHelper.FromStream(type, stream, options);
}
