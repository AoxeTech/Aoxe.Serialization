namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static async Task PackAsync<TValue>(TValue value, Stream? stream, IJsonFormatterResolver resolver = null)
    {
        if(value is not null && stream is not null)
            await Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static async Task<Stream> PackAsync<TValue>(TValue value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Stream.Null
            : await Utf8JsonSerializer.PackAsync(value, resolver ?? DefaultJsonFormatterResolver);

    public static async Task PackAsync(object? value, Stream? stream, IJsonFormatterResolver resolver = null)
    {
        if(value is not null && stream is not null)
            await Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static async Task<Stream> PackAsync(object? value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Stream.Null
            : await Utf8JsonSerializer.PackAsync(value, resolver ?? DefaultJsonFormatterResolver);

    public static async Task PackAsync(Type type, object? value, Stream? stream, IJsonFormatterResolver resolver = null)
    {
        if(value is not null && stream is not null)
            await Utf8JsonSerializer.PackAsync(type, value, stream, resolver ?? DefaultJsonFormatterResolver);
    }

    public static async Task<Stream> PackAsync(Type type, object? value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Stream.Null
            : await Utf8JsonSerializer.PackAsync(type, value, resolver ?? DefaultJsonFormatterResolver);

    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream, IJsonFormatterResolver resolver = null) =>
        stream.IsNullOrEmpty()
            ? default
            : await Utf8JsonSerializer.UnpackAsync<TValue>(stream, resolver ?? DefaultJsonFormatterResolver);

    public static async Task<object?> UnpackAsync(Type type, Stream? stream, IJsonFormatterResolver? resolver = null) =>
        stream.IsNullOrEmpty()
            ? default
            : await Utf8JsonSerializer.UnpackAsync(type, stream, resolver ?? DefaultJsonFormatterResolver);
}