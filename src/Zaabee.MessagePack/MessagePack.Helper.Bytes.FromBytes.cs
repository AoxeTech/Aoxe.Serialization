namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static TValue? FromBytes<TValue>(ReadOnlyMemory<byte> bytes, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        bytes.Length is 0
            ? default
            : MessagePackSerializer.Deserialize<TValue>(bytes, options, cancellationToken);

    public static object? FromBytes(Type type, ReadOnlyMemory<byte> bytes,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        bytes.Length is 0
            ? default
            : MessagePackSerializer.Deserialize(type, bytes, options, cancellationToken);
}