namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static Task PackByAsync<TValue>(this Stream? stream, TValue? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding);

    public static Task PackByAsync(this Stream? stream, Type type, object? value,
        JsonSerializerSettings? settings = null, Encoding? encoding = null) =>
        NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding);

    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.FromStreamAsync<TValue>(stream, settings, encoding);

    public static Task<object?> FromStreamAsync(this Stream? stream, Type type, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.FromStreamAsync(type, stream, settings, encoding);
}