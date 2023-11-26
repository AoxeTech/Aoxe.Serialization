namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static byte[] ToBytes<TValue>(
        TValue? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackSerializer.Serialize(value, options, cancellationToken);

    public static byte[] ToBytes(
        Type type,
        object? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackSerializer.Serialize(type, value, options, cancellationToken);
}
