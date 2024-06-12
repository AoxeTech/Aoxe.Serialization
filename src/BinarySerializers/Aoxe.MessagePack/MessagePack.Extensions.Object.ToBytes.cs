namespace Aoxe.MessagePack;

public static partial class MessagePackExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.ToBytes(value, options, cancellationToken);

    public static byte[] ToBytes(
        this object? value,
        Type type,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.ToBytes(type, value, options, cancellationToken);
}
