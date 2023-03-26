namespace Zaabee.Serializer.Abstractions;

public partial interface IJsonSerializer
{
}

public static partial class JsonSerializerExtension
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
}