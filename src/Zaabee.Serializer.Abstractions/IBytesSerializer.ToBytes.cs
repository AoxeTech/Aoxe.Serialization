namespace Zaabee.Serializer.Abstractions;

public partial interface IBytesSerializer
{
    /// <summary>
    /// Serialize to bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    byte[] ToBytes<TValue>(TValue? value);

    /// <summary>
    /// Serialize to bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    byte[] ToBytes(Type type, object? value);
}