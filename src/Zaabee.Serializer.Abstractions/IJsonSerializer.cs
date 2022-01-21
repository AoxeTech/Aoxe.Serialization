namespace Zaabee.Serializer.Abstractions;

public interface IJsonSerializer : ITextSerializer
{
    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToJson<TValue>(TValue? value);

    /// <summary>
    /// If the json is null or white space will return the default value of T.
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromJson<TValue>(string? json);

    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToJson(Type type, object? value);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    object? FromJson(Type type, string? json);
}