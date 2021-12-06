namespace Zaabee.Serializer.Abstractions;

public interface IStreamSerializer
{
    /// <summary>
    /// If the value is null must return a Stream.Null.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Stream? SerializeToStream<TValue>(TValue? value);

    /// <summary>
    /// If the stream is null or empty must return the default value of T.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? DeserializeFromStream<TValue>(Stream? stream);

    /// <summary>
    /// If the value is null must return a Stream.Null.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Stream? SerializeToStream(Type type, object? value);

    /// <summary>
    /// If the stream is null or empty must return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    object? DeserializeFromStream(Type type, Stream? stream);
}