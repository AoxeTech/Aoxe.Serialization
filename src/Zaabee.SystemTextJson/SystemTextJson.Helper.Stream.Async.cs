namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    public static async Task<Stream> PackAsync<TValue>(TValue? value, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Stream.Null
            : await SystemTextJsonSerializer.PackAsync(value, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static async Task<Stream> PackAsync(Type type, object? value, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? new MemoryStream()
            : await SystemTextJsonSerializer.PackAsync(type, value, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static async Task PackAsync<TValue>(TValue? value, Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (value is not null && stream is not null)
            await SystemTextJsonSerializer.PackAsync(value, stream, options ?? DefaultJsonSerializerOptions,
                cancellationToken);
    }

    public static async Task PackAsync(Type type, object? value, Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        if (value is not null && stream is not null)
            await SystemTextJsonSerializer.PackAsync(type, value, stream, options ?? DefaultJsonSerializerOptions,
                cancellationToken);
    }

    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream is null || stream.Length is 0
            ? default
            : await SystemTextJsonSerializer.UnpackAsync<TValue>(stream, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static async Task<object?> UnpackAsync(Type type, Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream is null || stream.Length is 0
            ? default
            : await SystemTextJsonSerializer.UnpackAsync(type, stream, options ?? DefaultJsonSerializerOptions,
                cancellationToken);
}