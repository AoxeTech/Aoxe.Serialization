namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static Stream Pack<TValue>(TValue value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Stream.Null
            : Utf8JsonSerializer.Pack(value, resolver ?? DefaultJsonFormatterResolver);

    public static void Pack<TValue>(TValue value, Stream? stream, IJsonFormatterResolver resolver = null)
    {
        if (value is null || stream is null) return;
        Utf8JsonSerializer.Pack(value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static Stream Pack(object? value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Stream.Null
            : Utf8JsonSerializer.Pack(value, resolver ?? DefaultJsonFormatterResolver);

    public static void Pack(object? value, Stream? stream, IJsonFormatterResolver resolver = null)
    {
        if (value is null || stream is null) return;
        Utf8JsonSerializer.Pack(value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static Stream Pack(Type type, object? value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Stream.Null
            : Utf8JsonSerializer.Pack(type, value, resolver ?? DefaultJsonFormatterResolver);

    public static void Pack(Type type, object? value, Stream? stream, IJsonFormatterResolver resolver = null)
    {
        if (value is null || stream is null) return;
        Utf8JsonSerializer.Pack(type, value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static TValue? Unpack<TValue>(Stream? stream, IJsonFormatterResolver resolver = null) =>
        stream.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Unpack<TValue>(stream, resolver ?? DefaultJsonFormatterResolver);

    public static object? Unpack(Type type, Stream? stream, IJsonFormatterResolver resolver = null) =>
        stream.IsNullOrEmpty()
            ? default
            : Utf8JsonSerializer.Unpack(type, stream, resolver ?? DefaultJsonFormatterResolver);
}