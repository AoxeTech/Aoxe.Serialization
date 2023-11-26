namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="settings"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromJson<TValue>(string? json, JsonSerializerSettings? settings = null) =>
        json.IsNullOrEmpty() ? default : JsonConvert.DeserializeObject<TValue>(json!, settings);

    /// <summary>
    /// Deserializes the JSON to the specified .NET type using <see cref="JsonSerializerSettings"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static object? FromJson(
        Type type,
        string? json,
        JsonSerializerSettings? settings = null
    ) => json.IsNullOrEmpty() ? default : JsonConvert.DeserializeObject(json!, type, settings);
}
