namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonExtensions
{
    public static TValue? FromJson<TValue>(this string? json, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Deserialize<TValue>(json, options);

    public static object? FromJson(this string? json, Type type, JsonSerializerOptions? options = null) =>
        SystemTextJsonHelper.Deserialize(type, json, options);
}