namespace Aoxe.Serializer.Abstractions;

public partial interface IBytesSerializer : IStreamSerializer
{
    /// <summary>
    /// If the bytes is null or empty will return the default value of T.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue? FromBytes<TValue>(byte[]? bytes);

    /// <summary>
    /// If the bytes is null or empty will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    object? FromBytes(Type type, byte[]? bytes);
}
