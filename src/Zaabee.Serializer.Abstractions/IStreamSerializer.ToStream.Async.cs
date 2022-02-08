namespace Zaabee.Serializer.Abstractions;

public partial interface IStreamSerializer
{
    /// <summary>
    /// Serialize to stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Task<MemoryStream> ToStreamAsync<TValue>(TValue? value);
    
    /// <summary>
    /// Serialize to stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Task<MemoryStream> ToStreamAsync(Type type, object? value);
}