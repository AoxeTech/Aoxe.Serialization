namespace Aoxe.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static byte[] ToBytes<TValue>(
        this TValue? value,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.ToBytes(value, settings, encoding);

    public static byte[] ToBytes(
        this object? value,
        Type type,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.ToBytes(type, value, settings, encoding);
}
