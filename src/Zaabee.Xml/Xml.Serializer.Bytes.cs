namespace Zaabee.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Serialize the object to a memory stream and return a bytes contain the stream content.
    /// </summary>
    /// <param name="t"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<T>(T t) => Serialize(typeof(T), t);

    /// <summary>
    /// Serialize the object to a memory stream and return a bytes contain the stream content.
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
    /// Initialize a memory stream by the bytes and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(byte[] bytes) => (T)Deserialize(typeof(T), bytes);

    /// <summary>
    /// Initialize a memory stream by the bytes and deserialize it.
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