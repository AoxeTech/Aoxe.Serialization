namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    public static Stream Pack<TValue>(TValue value, JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonSerializer.Pack(value, encoding ?? DefaultEncoding, settings ?? DefaultSettings);

    public static Stream Pack(Type type, object? value, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        value is null
            ? Stream.Null
            : NewtonsoftJsonSerializer.Pack(type, value, encoding ?? DefaultEncoding, settings ?? DefaultSettings);

    public static void Pack<TValue>(TValue value, Stream? stream, JsonSerializerSettings? settings = null, Encoding encoding = null)
    {
        if (value is null || stream is null) return;
        NewtonsoftJsonSerializer.Pack(value, stream, encoding ?? DefaultEncoding, settings ?? DefaultSettings);
    }

    public static void Pack(Type type, object? value, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding encoding = null)
    {
        if (value is null || stream is null) return;
        NewtonsoftJsonSerializer.Pack(type, value, stream, encoding ?? DefaultEncoding, settings ?? DefaultSettings);
    }

    public static TValue? Unpack<TValue>(Stream? stream, JsonSerializerSettings? settings = null, Encoding encoding = null) =>
        stream.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Unpack<TValue>(stream, encoding ?? DefaultEncoding, settings ?? DefaultSettings);

    public static object? Unpack(Type type, Stream? stream, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        stream.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Unpack(type, stream, encoding ?? DefaultEncoding, settings ?? DefaultSettings);
}