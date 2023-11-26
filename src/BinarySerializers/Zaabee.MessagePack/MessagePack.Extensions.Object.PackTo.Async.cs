namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.PackAsync(value, stream, options, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Type type,
        Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => MessagePackHelper.PackAsync(type, value, stream, options, cancellationToken);
}
