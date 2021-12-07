namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static Task<MemoryStream> ToStreamAsync<TValue>(this TValue value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(value, options, cancellationToken);

    public static Task<MemoryStream> ToStreamAsync(this object? value, Type type,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(type, value, options, cancellationToken);

    public static Task PackToAsync<TValue>(this TValue value, Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(value, stream, options, cancellationToken);

    public static Task PackToAsync(this object? value, Type type, Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        MessagePackHelper.PackAsync(type, value, stream, options, cancellationToken);
}