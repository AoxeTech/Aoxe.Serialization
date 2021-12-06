namespace Zaabee.Utf8Json;

public static partial class Utf8JsonSerializer
{
    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string SerializeToJson<TValue>(TValue value, IJsonFormatterResolver resolver) =>
        JsonSerializer.ToJsonString(value, resolver);

    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static string SerializeToJson(object? value, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.ToJsonString(value, resolver);

    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static string SerializeToJson(Type type, object? value, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.ToJsonString(type, value, resolver);

    /// <summary>
    /// Deserialize the json to an instance of the <typeparamref name="T"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(string json, IJsonFormatterResolver resolver) =>
        JsonSerializer.Deserialize<TValue>(json, resolver);

    /// <summary>
    /// Deserialize the json to an instance of the <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, string json, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.Deserialize(type, json, resolver);
}