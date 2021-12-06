namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static Task PackAsync<TValue>(TValue value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        value is null || stream is null
            ? Task.CompletedTask
            : Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);

    public static Task<MemoryStream> PackAsync<TValue>(TValue value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Task.FromResult(new MemoryStream())
            : Utf8JsonSerializer.PackAsync(value, resolver ?? DefaultJsonFormatterResolver);

    public static Task PackAsync(object? value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        value is null || stream is null
            ? Task.CompletedTask
            : Utf8JsonSerializer.PackAsync(value, stream, resolver ?? DefaultJsonFormatterResolver);

    public static Task<MemoryStream> PackAsync(object? value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Task.FromResult(new MemoryStream())
            : Utf8JsonSerializer.PackAsync(value, resolver ?? DefaultJsonFormatterResolver);

    public static Task PackAsync(Type type, object? value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        value is null || stream is null
            ? Task.CompletedTask
            : Utf8JsonSerializer.PackAsync(type, value, stream, resolver ?? DefaultJsonFormatterResolver);

    public static Task<MemoryStream> PackAsync(Type type, object? value, IJsonFormatterResolver resolver = null) =>
        value is null
            ? Task.FromResult(new MemoryStream())
            : Utf8JsonSerializer.PackAsync(type, value, resolver ?? DefaultJsonFormatterResolver);

    public static Task<TValue> UnpackAsync<TValue>(Stream? stream, IJsonFormatterResolver resolver = null) =>
        stream.IsNullOrEmpty()
            ? Task.FromResult(default(TValue))
            : Utf8JsonSerializer.UnpackAsync<TValue>(stream, resolver ?? DefaultJsonFormatterResolver);

    public static Task<object?> UnpackAsync(Type type, Stream? stream, IJsonFormatterResolver? resolver = null) =>
        stream.IsNullOrEmpty()
            ? Task.FromResult(default(object))
            : Utf8JsonSerializer.UnpackAsync(type, stream, resolver ?? DefaultJsonFormatterResolver);
}