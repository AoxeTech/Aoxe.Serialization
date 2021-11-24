namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static byte[] ToBytes<T>(this T t, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Serialize(t, options, cancellationToken);

    public static MemoryStream ToStream<T>(this T t, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(t, options, cancellationToken);

    public static void PackTo<T>(this T t, Stream stream, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(t, stream, options, cancellationToken);

    public static byte[] ToBytes(this object obj, Type type, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Serialize(type, obj, options, cancellationToken);

    public static MemoryStream ToStream(this object obj, Type type, MessagePackSerializerOptions options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(type, obj, options, cancellationToken);

    public static void PackTo(this object obj, Type type, Stream stream,
        MessagePackSerializerOptions options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(type, obj, stream, options, cancellationToken);
}