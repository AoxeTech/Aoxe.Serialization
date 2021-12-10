namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static TValue? FromJson<TValue>(this string json, JsonSerializerSettings? settings = null) =>
        NewtonsoftJsonHelper.FromJson<TValue>(json, settings);

    public static object? FromJson(this string json, Type type, JsonSerializerSettings? settings = null) =>
        NewtonsoftJsonHelper.FromJson(type, json, settings);
}