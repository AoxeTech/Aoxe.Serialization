namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static ValueTask PackToAsync<TValue>(
        this TValue? value,
        Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static ValueTask PackToAsync(
        this object? value,
        Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static ValueTask PackToAsync(
        this object? value,
        Type type,
        Stream? stream,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.PackAsync(type, value, stream, resolver);
}
