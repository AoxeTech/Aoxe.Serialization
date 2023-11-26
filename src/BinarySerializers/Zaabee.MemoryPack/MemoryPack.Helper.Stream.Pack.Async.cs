namespace Zaabee.MemoryPack;

public static partial class MemoryPackHelper
{
    public static async ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await MemoryPackSerializer.SerializeAsync(stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask PackAsync(
        Type type,
        object? value,
        Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await MemoryPackSerializer.SerializeAsync(type, stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
