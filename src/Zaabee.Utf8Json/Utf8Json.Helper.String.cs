namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    public static string SerializeToJson<T>(T value, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeToJson(value, resolver ?? DefaultJsonFormatterResolver);

    public static string SerializeToJson(object obj, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeToJson(obj, resolver ?? DefaultJsonFormatterResolver);

    public static string SerializeToJson(Type type, object obj, IJsonFormatterResolver resolver = null) =>
        Utf8JsonSerializer.SerializeToJson(type, obj, resolver ?? DefaultJsonFormatterResolver);

    public static T Deserialize<T>(string json, IJsonFormatterResolver resolver = null) =>
        json.IsNullOrWhiteSpace()
            ? (T) typeof(T).GetDefaultValue()
            : Utf8JsonSerializer.Deserialize<T>(json, resolver ?? DefaultJsonFormatterResolver);

    public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver = null) =>
        json.IsNullOrWhiteSpace()
            ? type.GetDefaultValue()
            : Utf8JsonSerializer.Deserialize(type, json, resolver ?? DefaultJsonFormatterResolver);
}