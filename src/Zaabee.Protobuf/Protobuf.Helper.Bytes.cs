namespace Zaabee.Protobuf;

public static partial class ProtobufHelper
{
    /// <summary>
    /// Serialize the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value)
    {
        using var ms = ToStream(value);
        return ms.ReadToEnd();
    }

    /// <summary>
    /// Serialize the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] ToBytes(object? value)
    {
        using var ms = ToStream(value);
        return ms.ReadToEnd();
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[] bytes)
    {
        if (bytes.IsNullOrEmpty()) return default;
        using var ms = new MemoryStream(bytes);
        return FromStream<TValue>(ms);
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[] bytes)
    {
        if (bytes.IsNullOrEmpty()) return default;
        using var ms = new MemoryStream(bytes);
        return FromStream(type, ms);
    }
}