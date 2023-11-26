namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static void PackTo<TValue>(
        this TValue? value,
        Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.Pack(value, stream, settings, encoding);

    public static void PackTo(
        this object? value,
        Type type,
        Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.Pack(type, value, stream, settings, encoding);
}
