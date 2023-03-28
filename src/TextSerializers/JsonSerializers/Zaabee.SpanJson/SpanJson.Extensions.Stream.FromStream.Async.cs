namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.FromStreamAsync<TValue>(stream, cancellationToken);

    public static Task<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.FromStreamAsync(type, stream, cancellationToken);
}