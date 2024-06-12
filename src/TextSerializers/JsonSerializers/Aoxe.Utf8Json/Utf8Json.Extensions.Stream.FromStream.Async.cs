namespace Aoxe.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static ValueTask<TValue?> FromStreamAsync<TValue>(
        this Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.FromStreamAsync<TValue>(stream, resolver);

    public static ValueTask<object?> FromStreamAsync(
        this Stream? stream,
        Type type,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.FromStreamAsync(type, stream, resolver);
}
