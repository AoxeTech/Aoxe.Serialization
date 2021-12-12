namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static Task PackToAsync<TValue>(this TValue? value, Stream? stream,
        IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static Task PackToAsync(this object? value, Stream? stream,
        IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static Task PackToAsync(this object? value, Type type, Stream? stream,
        IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.PackAsync(type, value, stream, resolver);
}