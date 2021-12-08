namespace Zaabee.MessagePack;

public static partial class MessagePackExtensions
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(this TValue value,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        await MessagePackHelper.PackAsync(value, options, cancellationToken);

    public static async Task<MemoryStream> ToStreamAsync(this object? value, Type type,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        await MessagePackHelper.PackAsync(type, value, options, cancellationToken);

    public static async Task PackToAsync<TValue>(this TValue value, Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        await MessagePackHelper.PackAsync(value, stream, options, cancellationToken);

    public static async Task PackToAsync(this object? value, Type type, Stream? stream,
        MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        await MessagePackHelper.PackAsync(type, value, stream, options, cancellationToken);
}