namespace Zaabee.Binary;

public static partial class BinarySerializer
{
    /// <summary>
    /// Pack the object into a memory stream and return a bytes contains the stream contents.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static byte[] Serialize(object obj) => Pack(obj).ToArray();

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(byte[] bytes) => (T)Deserialize(bytes);

    /// <summary>
    /// Initializes a new memory stream based on the bytes and unpack it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static object Deserialize(byte[] bytes)
    {
        using var ms = new MemoryStream(bytes);
        return Unpack(ms);
    }
}