namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static Task PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.PackAsync(value, stream, cancellationToken);

    public static Task PackToAsync(
        this object? value,
        Stream? stream,
        CancellationToken cancellationToken = default) =>
        SpanJsonHelper.PackAsync(value, stream, cancellationToken);
}