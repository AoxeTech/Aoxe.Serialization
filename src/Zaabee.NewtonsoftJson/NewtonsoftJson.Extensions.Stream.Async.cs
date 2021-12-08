namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static async Task PackByAsync<TValue>(this Stream? stream, TValue value, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        await NewtonsoftJsonHelper.PackAsync(value, stream, settings, encoding);

    public static async Task PackByAsync(this Stream? stream, Type type, object? value,
        JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        await NewtonsoftJsonHelper.PackAsync(type, value, stream, settings, encoding);

    public static async Task<TValue> UnpackAsync<TValue>(this Stream? stream, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        await NewtonsoftJsonHelper.UnpackAsync<TValue>(stream, settings, encoding);

    public static async Task<object> UnpackAsync(this Stream? stream, Type type,
        JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        await NewtonsoftJsonHelper.UnpackAsync(type, stream, settings, encoding);
}