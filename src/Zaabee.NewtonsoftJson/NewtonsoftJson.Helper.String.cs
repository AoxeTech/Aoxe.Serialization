namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    public static string SerializeToJson<TValue>(TValue value, JsonSerializerSettings? settings = null) =>
        NewtonsoftJsonSerializer.SerializeToJson(value, settings ?? DefaultSettings);

    public static string SerializeToJson(Type type, object? value, JsonSerializerSettings? settings = null) =>
        NewtonsoftJsonSerializer.SerializeToJson(type, value, settings ?? DefaultSettings);

    public static TValue? Deserialize<TValue>(string json, JsonSerializerSettings? settings = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : NewtonsoftJsonSerializer.Deserialize<TValue>(json, settings ?? DefaultSettings);

    public static object? Deserialize(Type type, string json, JsonSerializerSettings? settings = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : NewtonsoftJsonSerializer.Deserialize(type, json, settings ?? DefaultSettings);
}