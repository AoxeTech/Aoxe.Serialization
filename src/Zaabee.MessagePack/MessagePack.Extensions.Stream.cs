namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static void PackBy<T>(this Stream stream, T obj, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(obj, stream, options, cancellationToken);

    public static void PackBy(this Stream stream, Type type, object obj,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(type, obj, stream, options, cancellationToken);

    public static T Unpack<T>(this Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Unpack<T>(stream, options, cancellationToken);

    public static object Unpack(this Stream stream, Type type, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Unpack(type, stream, options, cancellationToken);
}