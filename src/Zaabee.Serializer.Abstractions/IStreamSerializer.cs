namespace Zaabee.Serializer.Abstractions;

public interface IStreamSerializer
{
    /// <summary>
    /// Serialize to stream.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Stream ToStream<TValue>(TValue? value);

    /// <summary>
    /// If the stream is null or empty will return the default value of T.
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromStream<TValue>(Stream? stream);

    /// <summary>
    /// Serialize to stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    Stream ToStream(Type type, object? value);

    /// <summary>
    /// If the stream is null or empty will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    object? FromStream(Type type, Stream? stream);
}