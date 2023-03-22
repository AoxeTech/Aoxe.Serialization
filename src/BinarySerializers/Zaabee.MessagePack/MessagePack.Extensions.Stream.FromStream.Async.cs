namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(this Stream? stream,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(this Stream? stream, Type type,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.FromStreamAsync(type, stream, options, cancellationToken);
}