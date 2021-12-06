namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue value, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(value, stream, options, cancellationToken);

    public static void PackBy(this Stream? stream, Type type, object? value,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(type, value, stream, options, cancellationToken);

    public static TValue? Unpack<TValue>(this Stream? stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Unpack<TValue>(stream, options, cancellationToken);

    public static object? Unpack(this Stream? stream, Type type, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Unpack(type, stream, options, cancellationToken);
}