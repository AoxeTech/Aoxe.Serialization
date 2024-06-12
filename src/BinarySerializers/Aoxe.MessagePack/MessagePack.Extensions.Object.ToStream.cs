namespace Aoxe.MessagePack;

public static partial class MessagePackExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.Pack(value, stream, options, cancellationToken);

    public static void PackTo(
        this object? value,
        Type type,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.Pack(type, value, stream, options, cancellationToken);
}
