namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonExtensions
{
    public static TValue? FromJson<TValue>(this string json, JsonSerializerSettings? settings = null) =>
        NewtonsoftJsonHelper.Deserialize<TValue>(json, settings);

    public static object? FromJson(this string json, Type type, JsonSerializerSettings? settings = null) =>
        NewtonsoftJsonHelper.Deserialize(type, json, settings);
}