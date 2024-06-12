namespace Aoxe.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static TValue? FromBytes<TValue>(
        this byte[]? bytes,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.FromBytes<TValue>(bytes, settings, encoding);

    public static object? FromBytes(
        this byte[]? bytes,
        Type type,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.FromBytes(type, bytes, settings, encoding);
}
