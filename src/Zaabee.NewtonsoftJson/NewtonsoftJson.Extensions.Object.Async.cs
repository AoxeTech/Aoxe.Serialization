namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static async Task<MemoryStream> ToStreamAsync<TValue>(this TValue value,
        JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        await NewtonsoftJsonHelper.PackAsync(value, settings, encoding);

    public static async Task<MemoryStream> ToStreamAsync(this object? value, Type type,
        JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        await NewtonsoftJsonHelper.PackAsync(type, value, settings, encoding);

    public static async Task PackToAsync<TValue>(this TValue value, Stream? stream,
        JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        await NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding);

    public static async Task PackToAsync(this object? value, Type type, Stream? stream,
        JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        await NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding);
}