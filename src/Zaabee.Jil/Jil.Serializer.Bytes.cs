namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="t"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static byte[] Serialize<T>(T? t, Options? options, Encoding encoding) =>
        encoding.GetBytes(SerializeToJson(t, options));

    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] Serialize(object? obj, Options? options, Encoding encoding) =>
        encoding.GetBytes(SerializeToJson(obj, options));

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Deserialize<T>(byte[] bytes, Options? options, Encoding encoding) =>
        Deserialize<T>(encoding.GetString(bytes), options);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object Deserialize(Type type, byte[] bytes, Options? options, Encoding encoding) =>
        Deserialize(type, encoding.GetString(bytes), options);
}