namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static TValue? FromStream<TValue>(
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = MessagePackSerializer.Deserialize<TValue>(stream, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static object? FromStream(
        Type type,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null or { CanSeek: true, Length: 0 })
            return default;
        var result = MessagePackSerializer.Deserialize(type, stream, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}
