namespace Zaabee.MsgPack;

public static partial class MsgPackSerializer
{
    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<T>(T t)
    {
        using var ms = Pack(t);
        return ms.ToArray();
    }

    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object obj)
    {
        using var ms = Pack(type, obj);
        return ms.ToArray();
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return Unpack<T>(ms);
    }

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object Deserialize(Type type, byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return Unpack(type, ms);
    }
}