namespace Zaabee.Jil;

public static partial class JilSerializer
{
    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value, Encoding encoding, Options? options = null) =>
        encoding.GetBytes(ToJson(value, options));

    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(object? value, Encoding encoding, Options? options = null) =>
        encoding.GetBytes(ToJson(value, options));
}