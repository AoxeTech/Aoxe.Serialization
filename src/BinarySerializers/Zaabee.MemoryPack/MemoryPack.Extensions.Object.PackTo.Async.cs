namespace Zaabee.MemoryPack;

public static partial class MemoryPackExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MemoryPackHelper.PackAsync(value, stream, options, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Type type, Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MemoryPackHelper.PackAsync(type, value, stream, options, cancellationToken);
}