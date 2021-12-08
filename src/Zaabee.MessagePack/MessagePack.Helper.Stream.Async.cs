namespace Zaabee.MessagePack;

public static partial class MessagePackHelper
{
    public static async Task<MemoryStream> PackAsync<TValue>(TValue value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? new MemoryStream()
            : await MessagePackCSharpSerializer.PackAsync(value, options ?? DefaultOptions, cancellationToken);

    public static async Task PackAsync<TValue>(TValue value, Stream? stream,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default)
    {
        if(value is not null && stream is not null)
            await MessagePackCSharpSerializer.PackAsync(value, stream, options ?? DefaultOptions, cancellationToken);
    }

    public static async Task<MemoryStream> PackAsync(Type type, object? value, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        await MessagePackCSharpSerializer.PackAsync(type, value, options ?? DefaultOptions, cancellationToken);

    public static async Task PackAsync(Type type, object? value, Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        await MessagePackCSharpSerializer.PackAsync(type, value, stream, options ?? DefaultOptions, cancellationToken);

    public static async ValueTask<TValue?> UnpackAsync<TValue>(Stream? stream, MessagePackSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream.IsNullOrEmpty()
            ? default
            : await MessagePackCSharpSerializer.UnpackAsync<TValue>(stream, options ?? DefaultOptions, cancellationToken);

    public static async ValueTask<object?> UnpackAsync(Type type, Stream? stream,
        MessagePackSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        await MessagePackCSharpSerializer.UnpackAsync(type, stream, options ?? DefaultOptions, cancellationToken);
}