namespace Zaabee.Jil;

public static partial class JilHelper
{
    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(
        byte[]? bytes,
        Options? options = null,
        Encoding? encoding = null
    ) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromJson<TValue>(bytes.GetString(encoding ?? Defaults.Utf8Encoding), options);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="options"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromBytes(
        Type type,
        byte[]? bytes,
        Options? options = null,
        Encoding? encoding = null
    ) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromJson(type, bytes.GetString(encoding ?? Defaults.Utf8Encoding), options);
}
