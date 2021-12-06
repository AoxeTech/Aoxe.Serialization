namespace Zaabee.MsgPack;

public static partial class MsgPackSerializer
{
    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<TValue>(TValue value)
    {
        using var ms = Pack(value);
        return ms.ReadToEnd();
    }

    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object? value)
    {
        using var ms = Pack(type, value);
        return ms.ReadToEnd();
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return Unpack<TValue>(ms);
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return Unpack(type, ms);
    }
}