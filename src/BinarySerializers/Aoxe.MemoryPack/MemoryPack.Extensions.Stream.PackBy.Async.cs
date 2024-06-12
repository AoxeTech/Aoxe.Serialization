namespace Aoxe.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static ValueTask PackByAsync<TValue>(
        this Stream? stream,
        TValue? value,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MemoryPackHelper.PackAsync(value, stream, options, cancellationToken);

    public static ValueTask PackByAsync(
        this Stream? stream,
        Type type,
        object? value,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MemoryPackHelper.PackAsync(type, value, stream, options, cancellationToken);
}
