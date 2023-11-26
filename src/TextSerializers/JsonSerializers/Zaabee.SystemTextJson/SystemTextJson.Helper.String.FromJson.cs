namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonHelper
{
    /// <summary>
    /// Parse the text representing a single JSON value into a <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromJson<TValue>(string? json, JsonSerializerOptions? options = null) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : JsonSerializer.Deserialize<TValue>(json!, options);

    /// <summary>
    /// Parse the text representing a single JSON value into a <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? FromJson(
        Type type,
        string? json,
        JsonSerializerOptions? options = null
    ) =>
        string.IsNullOrWhiteSpace(json)
            ? default
            : JsonSerializer.Deserialize(json!, type, options);
}
