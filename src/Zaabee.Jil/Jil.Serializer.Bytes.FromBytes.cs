namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[] bytes, Encoding encoding, Options? options = null) =>
        FromJson<TValue>(encoding.GetString(bytes), options);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[] bytes, Encoding encoding, Options? options = null) =>
        FromJson(type, encoding.GetString(bytes), options);
}