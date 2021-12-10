namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream,
        IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.FromStreamAsync<TValue>(stream, resolver);

    public static Task<object?> FromStreamAsync(this Stream? stream, Type type,
        IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.FromStreamAsync(type, stream, resolver);
}