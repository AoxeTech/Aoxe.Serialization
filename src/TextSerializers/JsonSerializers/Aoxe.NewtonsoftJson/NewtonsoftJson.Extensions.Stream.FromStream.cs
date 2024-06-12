namespace Aoxe.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static TValue? FromStream<TValue>(
        this Stream? stream,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.FromStream<TValue>(stream, settings, encoding);

    public static object? FromStream(
        this Stream? stream,
        Type type,
        JsonSerializerSettings? settings = null,
        Encoding? encoding = null
    ) => NewtonsoftJsonHelper.FromStream(type, stream, settings, encoding);
}
