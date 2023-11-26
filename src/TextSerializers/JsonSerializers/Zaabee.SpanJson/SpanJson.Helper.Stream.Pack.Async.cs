namespace Zaabee.SpanJson;

public static partial class SpanJsonHelper
{
    public static async ValueTask PackAsync<TValue>(
        TValue? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await JsonSerializer.Generic.Utf8.SerializeAsync(value, stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }

    public static async ValueTask PackAsync(
        object? value,
        Stream? stream,
        CancellationToken cancellationToken = default
    )
    {
        if (stream is null)
            return;
        await JsonSerializer.NonGeneric.Utf8.SerializeAsync(value, stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
    }
}
