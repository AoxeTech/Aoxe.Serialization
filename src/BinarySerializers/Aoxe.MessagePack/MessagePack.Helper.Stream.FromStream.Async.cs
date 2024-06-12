namespace Aoxe.MessagePack;

public static partial class MessagePackHelper
{
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = await MessagePackSerializer.DeserializeAsync<TValue>(
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
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = await MessagePackSerializer.DeserializeAsync(
            type,
            stream,
            options,
            cancellationToken
        );
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
