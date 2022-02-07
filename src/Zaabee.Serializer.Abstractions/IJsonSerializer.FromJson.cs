namespace Zaabee.Serializer.Abstractions;

public partial interface IJsonSerializer : ITextSerializer
{
    /// <summary>
    /// If the json is null or white space will return the default value of T.
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromJson<TValue>(string? json);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    object? FromJson(Type type, string? json);
}