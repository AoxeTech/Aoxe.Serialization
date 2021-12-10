namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value,
        JsonSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.PackAsync(value, stream, options, cancellationToken);

    public static Task PackByAsync(this Stream? stream, Type type, object? value,
        JsonSerializerOptions? options = null, CancellationToken cancellationToken = default) =>
        SystemTextJsonHelper.PackAsync(type, value, stream, options, cancellationToken);
}