namespace Zaabee.Serializer.Abstractions;

public partial interface IStreamSerializer
{
    /// <summary>
    /// Serialize to stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    MemoryStream ToStream<TValue>(TValue? value);

    /// <summary>
    /// Serialize to stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    MemoryStream ToStream(Type type, object? value);
}
