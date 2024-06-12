namespace Aoxe.MessagePack;

public static partial class MessagePackExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.FromStream<TValue>(stream, options, cancellationToken);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.FromStream(type, stream, options, cancellationToken);
}
