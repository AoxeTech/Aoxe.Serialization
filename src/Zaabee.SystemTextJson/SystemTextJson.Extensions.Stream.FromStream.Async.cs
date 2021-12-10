namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public static Task<object?> FromStreamAsync(this Stream? stream, Type type, JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.FromStreamAsync(type, stream, options, cancellationToken);
}