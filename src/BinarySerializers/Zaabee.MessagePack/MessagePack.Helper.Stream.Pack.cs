namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static void Pack<TValue>(
        TValue? value,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        MessagePackSerializer.Serialize(stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static void Pack(
        Type type,
        object? value,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        MessagePackSerializer.Serialize(type, stream, value, options, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
