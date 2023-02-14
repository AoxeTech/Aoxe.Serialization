namespace Zaabee.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MemoryPackHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MemoryPackHelper.FromStreamAsync(type, stream, options, cancellationToken);
}