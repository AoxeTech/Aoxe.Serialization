namespace Zaabee.Utf8Json;

public static partial class Utf8JsonExtensions
{
    public static string ToJson<TValue>(this TValue? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToJson(value, resolver);

    public static string ToJson(this object? value, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToJson(value, resolver);

    public static string ToJson(this object? value, Type type, IJsonFormatterResolver? resolver = null) =>
        Utf8JsonHelper.ToJson(type, value, resolver);
}