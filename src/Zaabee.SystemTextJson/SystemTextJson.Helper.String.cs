namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    public static string SerializeToJson<TValue>(TValue? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonSerializer.SerializeToJson(value, options ?? DefaultJsonSerializerOptions);

    public static string SerializeToJson(Type type, object? value, JsonSerializerOptions? options = null) =>
        SystemTextJsonSerializer.SerializeToJson(type, value, options ?? DefaultJsonSerializerOptions);

    public static TValue? Deserialize<TValue>(string? json, JsonSerializerOptions? options = null) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : SystemTextJsonSerializer.Deserialize<TValue>(json, options ?? DefaultJsonSerializerOptions);

    public static object? Deserialize(Type type, string? json, JsonSerializerOptions? options = null) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : SystemTextJsonSerializer.Deserialize(type, json, options ?? DefaultJsonSerializerOptions);
}