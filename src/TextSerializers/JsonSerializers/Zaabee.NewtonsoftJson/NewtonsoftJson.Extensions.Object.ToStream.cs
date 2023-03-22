namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static MemoryStream ToStream<TValue>(this TValue? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.ToStream(value, settings, encoding);

    public static MemoryStream ToStream(this object? value, Type type, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        NewtonsoftJsonHelper.ToStream(type, value, settings, encoding);
}