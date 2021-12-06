namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static byte[] Serialize<TValue>(TValue value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Array.Empty<byte>()
            : MessagePackCSharpSerializer.Serialize(value, options ?? DefaultOptions, cancellationToken);

    public static byte[] Serialize(Type type, object? value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Array.Empty<byte>()
            : MessagePackCSharpSerializer.Serialize(type, value, options ?? DefaultOptions, cancellationToken);

    public static TValue? Deserialize<TValue>(ReadOnlyMemory<byte> bytes, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        bytes.IsEmpty
            ? default
            : MessagePackCSharpSerializer.Deserialize<TValue>(bytes, options ?? DefaultOptions, cancellationToken);

    public static object? Deserialize(Type type, ReadOnlyMemory<byte> bytes,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
        bytes.IsEmpty
            ? default
            : MessagePackCSharpSerializer.Deserialize(type, bytes, options ?? DefaultOptions, cancellationToken);
}