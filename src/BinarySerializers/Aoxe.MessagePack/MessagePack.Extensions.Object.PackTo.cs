namespace Aoxe.MessagePack;

public static partial class MessagePackExtensions
{
    public static MemoryStream ToStream<TValue>(
        this TValue? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.ToStream(value, options, cancellationToken);

    public static MemoryStream ToStream(
        this object? value,
        Type type,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.ToStream(type, value, options, cancellationToken);
}
