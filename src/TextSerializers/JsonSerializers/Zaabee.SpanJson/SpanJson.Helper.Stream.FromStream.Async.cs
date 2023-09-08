namespace Zaabee.SpanJson;

public static partial class SpanJsonHelper
{
    public static async ValueTask<TValue?> FromStreamAsync<TValue>(
        Stream? stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = await JsonSerializer.Generic.Utf8.DeserializeAsync<TValue>(stream, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }

    public static async ValueTask<object?> FromStreamAsync(
        Type type,
        Stream? stream,
        CancellationToken cancellationToken = default)
    {
        if (stream is null or { CanSeek: true, Length: 0 }) return default;
        var result = await JsonSerializer.NonGeneric.Utf8.DeserializeAsync(stream, type, cancellationToken);
        stream.TrySeek(0, SeekOrigin.Begin);
        return result;
    }
}