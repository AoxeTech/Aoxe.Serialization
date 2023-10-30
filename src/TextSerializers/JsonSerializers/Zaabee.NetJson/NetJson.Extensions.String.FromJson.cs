namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static TValue? FromJson<TValue>(this string? json, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromJson<TValue>(json, settings);

    public static object? FromJson(this string? json, Type type, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.FromJson(type, json, settings);
}