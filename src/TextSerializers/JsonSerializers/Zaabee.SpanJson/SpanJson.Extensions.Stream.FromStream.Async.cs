namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.FromStreamAsync<TValue>(stream, cancellationToken);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.FromStreamAsync(type, stream, cancellationToken);
}