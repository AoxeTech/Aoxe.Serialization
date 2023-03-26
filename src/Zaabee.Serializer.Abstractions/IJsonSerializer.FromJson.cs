namespace Zaabee.Serializer.Abstractions;

public partial interface IJsonSerializer : ITextSerializer
{
}

public static partial class JsonSerializerExtension
{
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