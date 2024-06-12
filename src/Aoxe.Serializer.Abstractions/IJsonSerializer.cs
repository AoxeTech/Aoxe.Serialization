namespace Aoxe.Serializer.Abstractions;

public interface IJsonSerializer : ITextSerializer { }

public static class JsonSerializerExtension
{
    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static string ToJson<TValue>(this IJsonSerializer serializer, TValue? value) =>
        serializer.ToText(value);

    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToJson(this IJsonSerializer serializer, Type type, object? value) =>
        serializer.ToText(type, value);

    /// <summary>
    /// If the json is null or white space will return the default value of T.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="json"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromJson<TValue>(this IJsonSerializer serializer, string? json) =>
        serializer.FromText<TValue>(json);

    /// <summary>
    /// If the json is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="serializer"></param>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    public static object? FromJson(this IJsonSerializer serializer, Type type, string? json) =>
        serializer.FromText(type, json);
}
