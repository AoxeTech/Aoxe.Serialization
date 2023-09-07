namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? FromBytes<TValue>(byte[]? bytes, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : (TValue?)FromBytes(typeof(TValue), bytes, settings, encoding ?? Defaults.Utf8Encoding);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? FromBytes(Type type, byte[]? bytes, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        bytes is null || bytes.Length is 0
            ? default
            : FromJson(type, bytes.GetString(encoding ?? Defaults.Utf8Encoding), settings);
}