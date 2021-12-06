namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    public static Task<MemoryStream> PackAsync<TValue>(TValue? value, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Task.FromResult(new MemoryStream())
            : SystemTextJsonSerializer.PackAsync(value, options ?? DefaultJsonSerializerOptions, cancellationToken);

    public static Task<MemoryStream> PackAsync(Type type, object? value, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null
            ? Task.FromResult(new MemoryStream())
            : SystemTextJsonSerializer.PackAsync(type, value, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static Task PackAsync<TValue>(TValue? value, Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null || stream is null
            ? Task.CompletedTask
            : SystemTextJsonSerializer.PackAsync(value, stream, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static Task PackAsync(Type type, object? value, Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        value is null || stream is null
            ? Task.CompletedTask
            : SystemTextJsonSerializer.PackAsync(type, value, stream, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static Task<TValue?> UnpackAsync<TValue>(Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream is null || stream.Length is 0
            ? Task.FromResult(default(TValue?))
            : SystemTextJsonSerializer.UnpackAsync<TValue>(stream!, options ?? DefaultJsonSerializerOptions,
                cancellationToken);

    public static Task<object?> UnpackAsync(Type type, Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        stream is null || stream.Length is 0
            ? Task.FromResult(default(object?))
            : SystemTextJsonSerializer.UnpackAsync(type, stream!, options ?? DefaultJsonSerializerOptions,
                cancellationToken);
}