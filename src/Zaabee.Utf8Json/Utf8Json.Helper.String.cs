namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static string SerializeToJson<TValue>(TValue value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeToJson(value, resolver ?? DefaultJsonFormatterResolver);

    public static string SerializeToJson(object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeToJson(value, resolver ?? DefaultJsonFormatterResolver);

    public static string SerializeToJson(Type type, object? value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeToJson(type, value, resolver ?? DefaultJsonFormatterResolver);

    public static TValue? Deserialize<TValue>(string json, IJsonFormatterResolver resolver = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : Utf8JsonSerializer.Deserialize<TValue>(json, resolver ?? DefaultJsonFormatterResolver);

    public static object? Deserialize(Type type, string json, IJsonFormatterResolver resolver = null) =>
        json.IsNullOrWhiteSpace()
            ? default
            : Utf8JsonSerializer.Deserialize(type, json, resolver ?? DefaultJsonFormatterResolver);
}