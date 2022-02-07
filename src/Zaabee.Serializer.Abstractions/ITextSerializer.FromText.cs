namespace Zaabee.Serializer.Abstractions;

public partial interface ITextSerializer : IBytesSerializer
{
    /// <summary>
    /// If the text is null or white space will return the default value of T.
    /// </summary>
    /// <param name="text"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromText<TValue>(string? text);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    object? FromText(Type type, string? text);
}