namespace Aoxe.MessagePack;

public static partial class MessagePackExtensions
{
    public static void PackBy<TValue>(
        this Stream? stream,
        TValue? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.Pack(value, stream, options, cancellationToken);

    public static void PackBy(
        this Stream? stream,
        Type type,
        object? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.Pack(type, value, stream, options, cancellationToken);
}
