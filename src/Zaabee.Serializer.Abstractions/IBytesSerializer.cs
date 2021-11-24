namespace Zaabee.Serializer.Abstractions;

public interface IBytesSerializer : IStreamSerializer
{
    /// <summary>
    /// If the value is null must return empty bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    byte[] SerializeToBytes<T>(T value);

    /// <summary>
    /// If the bytes is null or empty must return the default value of T.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    T? DeserializeFromBytes<T>(byte[]? bytes);

    /// <summary>
    /// If the value is null must return empty bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    byte[] SerializeToBytes(Type type, object? value);

    /// <summary>
    /// If the bytes is null or empty must return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    object? DeserializeFromBytes(Type type, byte[]? bytes);
}