namespace Zaabee.Serializer.Abstractions;

public partial interface IStreamSerializer
{
    /// <summary>
    /// If the stream is null or empty will return the default value of T.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Task<TValue?> FromStreamAsync<TValue>(Stream? stream);

    /// <summary>
    /// If the stream is null or empty will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    Task<object?> FromStreamAsync(Type type, Stream? stream);
}