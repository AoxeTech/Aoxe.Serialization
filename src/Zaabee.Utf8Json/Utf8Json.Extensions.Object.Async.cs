namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static async Task<Stream> ToStreamAsync<TValue>(this TValue value, IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(value, resolver);

    public static async Task<Stream> ToStreamAsync(this object? value, IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(value, resolver);

    public static async Task<Stream> ToStreamAsync(this object? value, Type type,
        IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(type, value, resolver);

    public static async Task PackToAsync<TValue>(this TValue value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static async Task PackToAsync(this object? value, Stream? stream, IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static async Task PackToAsync(this object? value, Type type, Stream? stream,
        IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(type, value, stream, resolver);
}