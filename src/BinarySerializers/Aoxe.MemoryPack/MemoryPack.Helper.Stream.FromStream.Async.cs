namespace Aoxe.MemoryPack;

public static partial class MemoryPackHelper
{
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = await MemoryPackSerializer.DeserializeAsync<TValue>(
            stream,
            options,
            cancellationToken
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static async ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        MemoryPackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = await MemoryPackSerializer.DeserializeAsync(
            type,
            stream,
            options,
            cancellationToken
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
