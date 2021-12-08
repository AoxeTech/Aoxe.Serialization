namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{

    public static async Task PackByAsync<TValue>(this Stream? stream, TValue value,
        IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(value, stream, resolver);

    public static async Task PackByAsync(this Stream? stream, Type type, object? value,
        IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.PackAsync(type, value, stream, resolver);

    public static async Task<TValue> UnpackAsync<TValue>(this Stream? stream, IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.UnpackAsync<TValue>(stream, resolver);

    public static async Task<object> UnpackAsync(this Stream? stream, Type type,
        IJsonFormatterResolver resolver = null) =>
        await Utf8JsonHelper.UnpackAsync(type, stream, resolver);
}