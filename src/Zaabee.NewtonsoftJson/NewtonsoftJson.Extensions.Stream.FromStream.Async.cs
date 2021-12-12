namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static Task<TValue?> FromStreamAsync<TValue>(this Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.FromStreamAsync<TValue>(stream, settings, encoding);

    public static Task<object?> FromStreamAsync(this Stream? stream, Type type, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.FromStreamAsync(type, stream, settings, encoding);
}