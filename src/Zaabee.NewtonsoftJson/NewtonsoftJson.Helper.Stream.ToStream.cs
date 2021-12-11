namespace Zaabee.NewtonsoftJson;

public static partial class NewtonsoftJsonHelper
{
    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    public static MemoryStream ToStream<TValue>(TValue? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        Pack(value, ms, settings, encoding);
        return ms;
    }

    /// <summary>
    /// Serialize the object to string, encode it to bytes and write to the stream.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="settings"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static MemoryStream ToStream(Type type, object? value, JsonSerializerSettings? settings = null,
        Encoding? encoding = null)
    {
        var ms = new MemoryStream();
        Pack(type, value, ms, settings, encoding);
        return ms;
    }
}