namespace Zaabee.MessagePack;

public static partial class MessagePackCSharpSerializer
{
    public static byte[] Serialize<TValue>(TValue value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackSerializer.Serialize(value, options, cancellationToken);

    public static byte[] Serialize(Type type, object? value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackSerializer.Serialize(type, value, options, cancellationToken);

    public static TValue? Deserialize<TValue>(ReadOnlyMemory<byte> bytes, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackSerializer.Deserialize<TValue>(bytes, options, cancellationToken);

    public static object? Deserialize(Type type, ReadOnlyMemory<byte> bytes,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
        MessagePackSerializer.Deserialize(type, bytes, options, cancellationToken);
}