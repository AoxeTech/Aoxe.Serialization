namespace Zaabee.SystemTextJson;

public static partial class SystemTextJsonSerializer
{
    /// <summary>
    /// Convert the provided value into a <see cref="System.String"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string SerializeToJson<TValue>(TValue? value, JsonSerializerOptions? options) =>
        JsonSerializer.Serialize(value, options);

    /// <summary>
    /// Convert the provided value into a <see cref="System.String"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string SerializeToJson(Type type, object? value, JsonSerializerOptions? options) =>
        JsonSerializer.Serialize(value, type, options);

    /// <summary>
    /// Parse the text representing a single JSON value into a <typeparamref name="TValue"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(string json, JsonSerializerOptions? options) =>
        JsonSerializer.Deserialize<TValue>(json, options);

    /// <summary>
    /// Parse the text representing a single JSON value into a <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, string json, JsonSerializerOptions? options) =>
        JsonSerializer.Deserialize(json, type, options);
}