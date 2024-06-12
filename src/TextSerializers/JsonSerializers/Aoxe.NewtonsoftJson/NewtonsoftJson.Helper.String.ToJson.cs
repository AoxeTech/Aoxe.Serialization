namespace Aoxe.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Serializes the specified object to a JSON string using a type, formatting and <see cref="JsonSerializerSettings"/>.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static string ToJson<TValue>(TValue? value, JsonSerializerSettings? settings = null) =>
        JsonConvert.SerializeObject(value, typeof(TValue), settings);

    /// <summary>
    /// Serializes the specified object to a JSON string using a type, formatting and <see cref="JsonSerializerSettings"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <returns></returns>
    public static string ToJson(
        Type type,
        object? value,
        JsonSerializerSettings? settings = null
    ) => JsonConvert.SerializeObject(value, type, settings);
}
