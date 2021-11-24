namespace Zaabee.Serializer.Abstractions;

public interface ITextSerializer : IBytesSerializer
{
    /// <summary>
    /// If the value is null must return an empty string.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    string SerializeToString<T>(T? value);

    /// <summary>
    /// If the text is null or empty must return the default value of T.
    /// </summary>
    /// <param name="text"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T? DeserializeFromString<T>(string? text);

    /// <summary>
    /// If the value is null must return an empty string.
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