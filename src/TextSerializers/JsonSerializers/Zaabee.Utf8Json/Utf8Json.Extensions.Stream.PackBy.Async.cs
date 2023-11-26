namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static ValueTask PackByAsync<TValue>(
        this Stream? stream,
        TValue? value,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static ValueTask PackByAsync(
        this Stream? stream,
        Type type,
        object? value,
        IJsonFormatterResolver? resolver = null
    ) => Utf8JsonHelper.PackAsync(type, value, stream, resolver);
}
