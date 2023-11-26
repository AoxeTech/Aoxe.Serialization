namespace Zaabee.SpanJson;

public static partial class SpanJsonExtensions
{
    public static ValueTask PackByAsync<TValue>(
        this Stream? stream,
        TValue? value,
        CancellationToken cancellationToken = default
    ) => SpanJsonHelper.PackAsync(value, stream, cancellationToken);

    public static ValueTask PackByAsync(
        this Stream? stream,
        object? value,
        CancellationToken cancellationToken = default
    ) => SpanJsonHelper.PackAsync(value, stream, cancellationToken);
}
