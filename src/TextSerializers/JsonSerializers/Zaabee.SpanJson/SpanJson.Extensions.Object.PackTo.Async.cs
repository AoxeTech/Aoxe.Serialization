namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.PackAsync(value, stream, cancellationToken);

    public static ValueTask PackToAsync(
        this object? value,
        Stream? stream,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.PackAsync(value, stream, cancellationToken);
}