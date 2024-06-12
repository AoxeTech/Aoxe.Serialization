namespace Aoxe.Utf8Json;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Deserialize the json to an instance of the <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromJson<TValue>(string? json, IJsonFormatterResolver? resolver = null) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : JsonSerializer.Deserialize<TValue>(json, resolver);

    /// <summary>
    /// Deserialize the json to an instance of the <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object? FromJson(
        Type type,
        string? json,
        IJsonFormatterResolver? resolver = null
    ) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : JsonSerializer.NonGeneric.Deserialize(type, json, resolver);
}
