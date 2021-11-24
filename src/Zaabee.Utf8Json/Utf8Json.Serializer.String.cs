namespace Zaabee.Utf8Json;

public static partial class Utf8JsonSerializer
{
    /// <summary>
    /// Serialize the obj to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string SerializeToJson<T>(T value, IJsonFormatterResolver resolver) =>
        JsonSerializer.ToJsonString(value, resolver);

    /// <summary>
    /// Serialize the obj to json string.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static string SerializeToJson(object obj, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.ToJsonString(obj, resolver);

    /// <summary>
    /// Serialize the obj to json string.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static string SerializeToJson(Type type, object obj, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.ToJsonString(type, obj, resolver);

    /// <summary>
    /// Deserialize the json to an instance of the <typeparamref name="T"/>.
    /// </summary>
    /// <param name="json"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(string json, IJsonFormatterResolver resolver) =>
        JsonSerializer.Deserialize<T>(json, resolver);

    /// <summary>
    /// Deserialize the json to an instance of the <paramref name="type"/>.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static object Deserialize(Type type, string json, IJsonFormatterResolver resolver) =>
        JsonSerializer.NonGeneric.Deserialize(type, json, resolver);
}