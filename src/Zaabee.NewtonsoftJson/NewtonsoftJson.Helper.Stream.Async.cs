namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    public static async Task<MemoryStream> PackAsync<TValue>(TValue value, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        value is null
            ? new MemoryStream()
            : await NewtonsoftJsonSerializer.PackAsync(value, encoding ?? DefaultEncoding, settings ?? DefaultSettings);

    public static async Task<MemoryStream> PackAsync(Type type, object? value, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        value is null
            ? new MemoryStream()
            : await NewtonsoftJsonSerializer.PackAsync(type, value, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);

    public static async Task PackAsync<TValue>(TValue value, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding encoding = null)
    {
        if (value is not null && stream is not null)
            await NewtonsoftJsonSerializer.PackAsync(value, stream, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);
    }

    public static async Task PackAsync(Type type, object? value, Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding encoding = null)
    {
        if (value is not null && stream is not null)
            await NewtonsoftJsonSerializer.PackAsync(type, value, stream, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);
    }

    /// <summary>
    /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static async Task<TValue?> UnpackAsync<TValue>(Stream? stream, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        stream.IsNullOrEmpty()
            ? default
            : await NewtonsoftJsonSerializer.UnpackAsync<TValue>(stream, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);

    /// <summary>
    /// Asynchronously read the stream to bytes, encode it to string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static async Task<object?> UnpackAsync(Type type, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        stream.IsNullOrEmpty()
            ? default
            : await NewtonsoftJsonSerializer.UnpackAsync(type, stream, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);
}