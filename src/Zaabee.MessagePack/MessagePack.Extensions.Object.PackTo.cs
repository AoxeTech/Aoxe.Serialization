namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static Stream ToStream<TValue>(this TValue? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.ToStream(value, options, cancellationToken);

    public static Stream ToStream(this object? value, Type type, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.ToStream(type, value, options, cancellationToken);
}