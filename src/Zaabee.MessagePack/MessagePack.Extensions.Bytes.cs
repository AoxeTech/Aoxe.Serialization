namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static TValue? FromBytes<TValue>(this byte[] bytes, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Deserialize<TValue>(bytes, options, cancellationToken);

    public static object? FromBytes(this byte[] bytes, Type type, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Deserialize(type, bytes, options, cancellationToken);
}