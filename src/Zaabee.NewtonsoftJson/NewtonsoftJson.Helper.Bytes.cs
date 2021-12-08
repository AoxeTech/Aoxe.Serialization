namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    public static byte[] Serialize<TValue>(TValue value, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonSerializer.Serialize(value, encoding ?? DefaultEncoding, settings ?? DefaultSettings);

    public static byte[] Serialize(Type type, object? value, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        value is null
            ? Array.Empty<byte>()
            : NewtonsoftJsonSerializer.Serialize(type, value, encoding ?? DefaultEncoding, settings ?? DefaultSettings);

    public static TValue? Deserialize<TValue>(byte[] bytes, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Deserialize<TValue>(bytes, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);

    public static object? Deserialize(Type type, byte[] bytes, JsonSerializerSettings? settings = null,
        Encoding encoding = null) =>
        bytes.IsNullOrEmpty()
            ? default
            : NewtonsoftJsonSerializer.Deserialize(type, bytes, encoding ?? DefaultEncoding,
                settings ?? DefaultSettings);
}