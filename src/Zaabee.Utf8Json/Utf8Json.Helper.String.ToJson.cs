namespace Zaabee.Utf8Json;

public static partial class Utf8JsonHelper
{
    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToJson<TValue>(TValue? value, IJsonFormatterResolver? resolver = null) =>
        JsonSerializer.ToJsonString(value, resolver);

    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static string ToJson(object? value, IJsonFormatterResolver? resolver = null) =>
        JsonSerializer.NonGeneric.ToJsonString(value, resolver);

    /// <summary>
    /// Serialize the value to json string.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="resolver"></param>
    /// <returns></returns>
    public static string ToJson(Type type, object? value, IJsonFormatterResolver? resolver = null) =>
        JsonSerializer.NonGeneric.ToJsonString(type, value, resolver);
}