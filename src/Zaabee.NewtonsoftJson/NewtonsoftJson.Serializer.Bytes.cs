namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonSerializer
{
    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] Serialize<TValue>(TValue value, Encoding encoding, JsonSerializerSettings? settings = null) =>
        encoding.GetBytes(SerializeToJson(value, settings));

    /// <summary>
    /// Serialize the object to json string and encode it into bytes used the encoding.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] Serialize(Type type, object? value, Encoding encoding, JsonSerializerSettings? settings = null) =>
        encoding.GetBytes(SerializeToJson(type, value, settings));

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="bytes"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static TValue? Deserialize<TValue>(byte[] bytes, Encoding encoding, JsonSerializerSettings? settings = null) =>
        (TValue) Deserialize(typeof(TValue), bytes, encoding, settings);

    /// <summary>
    /// Use encoding to decode the bytes into string and deserialize it.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static object? Deserialize(Type type, byte[] bytes, Encoding encoding, JsonSerializerSettings? settings = null) =>
        Deserialize(type, encoding.GetString(bytes), settings);
}