namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes<TValue>(TValue? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        ToJson(value, settings).GetBytes(encoding);

    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] ToBytes(Type type, object? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null) =>
        ToJson(type, value, settings).GetBytes(encoding);
}