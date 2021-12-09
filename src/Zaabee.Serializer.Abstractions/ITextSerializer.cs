namespace Zaabee.Serializer.Abstractions;

public interface ITextSerializer : IBytesSerializer
{
    /// <summary>
    /// If the value is null must return a string.Empty.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string SerializeToString<TValue>(TValue? value);

    /// <summary>
    /// If the text is null or white space must return the default value of T.
    /// </summary>
    /// <param name="text"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? DeserializeFromString<TValue>(string? text);

    /// <summary>
    /// If the value is null must return a string.Empty.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string SerializeToString(Type type, object? value);

    /// <summary>
    /// If the string is null or white space must return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="text"></param>
    /// <returns></returns>
    object? DeserializeFromString(Type type, string? text);
}