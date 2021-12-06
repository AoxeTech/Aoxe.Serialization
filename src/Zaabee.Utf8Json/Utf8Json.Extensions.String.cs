namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static TValue? FromJson<TValue>(this string json, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Deserialize<TValue>(json, resolver);

    public static object? FromJson(this string json, Type type, IJsonFormatterResolver resolver = null) =>
        Utf8JsonHelper.Deserialize(type, json, resolver);
}