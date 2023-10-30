namespace Zaabee.NetJson;

public static partial class Utf8JsonExtensions
{
    public static string ToJson<TValue>(this TValue? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToJson(value, settings);

    public static string ToJson(this object? value, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToJson(value, settings);

    public static string ToJson(this object? value, Type type, NetJSONSettings? settings = null) =>
        Utf8JsonHelper.ToJson(type, value, settings);
}