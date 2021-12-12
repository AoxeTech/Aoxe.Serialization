namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static void PackBy<TValue>(this Stream? stream, TValue? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.Pack(value, stream, settings, encoding);

    public static void PackBy(this Stream? stream, Type type, object? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.Pack(type, value, stream, settings, encoding);
}