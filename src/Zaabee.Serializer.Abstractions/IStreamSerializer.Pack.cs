namespace Zaabee.Serializer.Abstractions;

public partial interface IStreamSerializer
{
    /// <summary>
    /// Serialize the value and pack to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    void Pack<TValue>(TValue? value, Stream? stream);

    /// <summary>
    /// Serialize the value and pack to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="stream"></param>
    /// <returns></returns>
    void Pack(Type type, object? value, Stream? stream);
}
