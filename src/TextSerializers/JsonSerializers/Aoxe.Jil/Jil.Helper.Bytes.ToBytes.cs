namespace Aoxe.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(
        TValue? value,
        Options? options = null,
        Encoding? encoding = null
    ) => ToJson(value, options).GetBytes(encoding ?? Defaults.Utf8Encoding);

    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(
        object? value,
        Options? options = null,
        Encoding? encoding = null
    ) => ToJson(value, options).GetBytes(encoding ?? Defaults.Utf8Encoding);
}
