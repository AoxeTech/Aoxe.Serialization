namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static byte[] ToBytes<TValue>(this TValue value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Serialize(value, options, cancellationToken);

    public static Stream ToStream<TValue>(this TValue value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(value, options, cancellationToken);

    public static void PackTo<TValue>(this TValue value, Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(value, stream, options, cancellationToken);

    public static byte[] ToBytes(this object? value, Type type, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Serialize(type, value, options, cancellationToken);

    public static Stream ToStream(this object? value, Type type, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(type, value, options, cancellationToken);

    public static void PackTo(this object? value, Type type, Stream? stream,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.Pack(type, value, stream, options, cancellationToken);
}