namespace Zaabee.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Serialize the object to a memory stream and return a bytes contain the stream content.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<TValue>(TValue value) =>
        Serialize(typeof(TValue), value);

    /// <summary>
    /// Serialize the object to a memory stream and return a bytes contain the stream content.
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
    /// Initialize a memory stream by the bytes and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(byte[] bytes) =>
        (TValue?)Deserialize(typeof(TValue), bytes);

    /// <summary>
    /// Initialize a memory stream by the bytes and deserialize it.
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