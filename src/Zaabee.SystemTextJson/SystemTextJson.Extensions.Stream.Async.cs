namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static async Task PackByAsync<TValue>(this Stream? stream, TValue? value,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.PackAsync(value, stream, options, cancellationToken);

    public static async Task PackByAsync(this Stream? stream, Type type, object? value,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.PackAsync(type, value, stream, options, cancellationToken);

    public static async Task<TValue?> UnpackAsync<TValue>(this Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        await SystemTextJsonHelper.UnpackAsync<TValue>(stream, options, cancellationToken);

    public static async Task<object?> UnpackAsync(this Stream? stream, Type type, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.UnpackAsync(type, stream, options, cancellationToken);
}