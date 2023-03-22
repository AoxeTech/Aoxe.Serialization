namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(value, stream, options, cancellationToken);

    public static Task PackByAsync(this Stream? stream, Type type, object? value,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(type, value, stream, options, cancellationToken);
}