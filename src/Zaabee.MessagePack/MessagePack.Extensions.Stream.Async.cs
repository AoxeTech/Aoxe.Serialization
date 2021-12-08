namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static async Task PackByAsync<TValue>(this Stream? stream, TValue value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(value, stream, options, cancellationToken);

    public static async Task PackByAsync(this Stream? stream, Type type, object? value,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(type, value, stream, options, cancellationToken);

    public static ValueTask<TValue?> UnpackAsync<TValue>(this Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.UnpackAsync<TValue>(stream, options, cancellationToken);

    public static ValueTask<object?> UnpackAsync(this Stream? stream, Type type,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        MessagePackHelper.UnpackAsync(type, stream, options, cancellationToken);
}