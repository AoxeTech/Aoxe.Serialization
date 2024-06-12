namespace Aoxe.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => SystemTextJsonHelper.FromStreamAsync<TValue>(stream, options, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        JsonSerializerOptions? options = null,
        CancellationToken cancellationToken = default
    ) => SystemTextJsonHelper.FromStreamAsync(type, stream, options, cancellationToken);
}
