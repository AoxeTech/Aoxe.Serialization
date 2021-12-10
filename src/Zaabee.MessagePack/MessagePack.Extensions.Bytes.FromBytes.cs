namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static TValue? FromBytes<TValue>(this ReadOnlyMemory<byte> bytes, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.FromBytes<TValue>(bytes, options, cancellationToken);

    public static object? FromBytes(this ReadOnlyMemory<byte> bytes, Type type, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.FromBytes(type, bytes, options, cancellationToken);
}